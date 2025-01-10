using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    /*private readonly Dictionary<Point, List<Creature>> _creatures = new();*/

    protected SmallMap(int size) : base(size, size)
    {
        if (size > 20) throw new ArgumentOutOfRangeException("Both SizeX and SizeY must be smaller than 20.");
    }

    /*public void Add(Creature creature, Point position)
    {
        if (!Exist(position)) throw new ArgumentOutOfRangeException("Position is outside of the map.");
        if (!_creatures.ContainsKey(position)) _creatures[position] = new List<Creature>();

        _creatures[position].Add(creature);
    }

    public void Remove(Creature creature, Point position)
    {
        if (_creatures.ContainsKey(position))
        {
            _creatures[position].Remove(creature);
            if (_creatures[position].Count == 0) _creatures.Remove(position);
        }
    }

    public void Move(Creature creature, Point oldPosition, Point newPosition)
    {
        Remove(creature, oldPosition);
        Add(creature, newPosition);
    }

    public List<Creature> At(Point position)
    {
        return _creatures.ContainsKey(position) ? _creatures[position] : new List<Creature>();
    }

    public List<Creature> At(int x, int y)
    {
        return At(new Point(x, y));
    }*/
}
