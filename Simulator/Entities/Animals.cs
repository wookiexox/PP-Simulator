using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Simulator.GameLogic;
using Simulator.Maps;
using Simulator.TextLogic;

namespace Simulator.Entities;

public class Animals : IMappable
{
    // get set 
    private string _description = "Unknown";
    private uint _size = 3;
    public uint Size
    {
        get { return _size; }
        init { _size = (uint)Validator.Limiter((int)value, 3, int.MaxValue); }
    }

    public string Description
    {
        get { return _description; }
        init { _description = Validator.Shortener(value, 3, 15, '#'); }
    }


    // konstruktory
    public Animals(string description, uint size = 3)
    {
        Description = description;
        Size = size;
    }
    public Animals()
    {

    }


    public Map? Map { get; set; }
    public Point Position { get; set; }

    public void AssignMap(Map map, Point position)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (!map.Exist(position)) throw new ArgumentOutOfRangeException("Position is outside of the map.");

        Map = map;
        Position = position;
        Map.Add(this, position);
    }

    public virtual string Go(Direction direction)
    {
        if (Map == null) return "Creature has no map assigned.";

        Point newPosition = Map.Next(Position, direction);
        if (newPosition != Position)
        {
            Map.Move(this, Position, newPosition);
            Position = newPosition;
        }

        return $"Moved to {Position}";
    }


    // informacje
    public virtual string? Info { get; }

    public override string ToString()
    {
        if (Info != null)
        {
            return $"{GetType().Name.ToUpper()}: {Description} ({Info}) <{Size}>";
        }

        return $"{GetType().Name.ToUpper()}: {Description} <{Size}>";
    }
}
