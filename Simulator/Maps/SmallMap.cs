using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private Dictionary<Point, List<IMappable>> _creatures = new();

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20) throw new ArgumentOutOfRangeException("Both SizeX and SizeY must be smaller than 20.");
    }

    public override void Add(IMappable creature, Point position)
    {
        if (!Exist(position)) throw new ArgumentOutOfRangeException("Position is outside of the map.");
        if (!_creatures.ContainsKey(position)) _creatures[position] = new List<IMappable>();

        _creatures[position].Add(creature);
    }
    public override void Remove(IMappable creature, Point position)
    {
        if (_creatures.ContainsKey(position))
        {
            _creatures[position].Remove(creature);

            if (_creatures[position].Count == 0)
                _creatures.Remove(position);
        }
    }

    public override void Move(IMappable creature, Point from, Point to)
    {
        Remove(creature, from);
        Add(creature, to);
    }

    public override List<IMappable> At(Point position)
    {
        return _creatures.ContainsKey(position) ? _creatures[position] : new List<IMappable>();
    }

    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}
