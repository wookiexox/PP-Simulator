using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }
    protected readonly Dictionary<Point, List<Creature>> _creatures = new();

    /// <summary>
    /// Construct a map with given walls sizes.
    /// </summary>
    /// <param name="sizeX">Size of the wall on X-axis.</param>
    /// <param name="sizeY">Size of the wall on Y-axis.</param>
    /// <exception cref="ArgumentOutOfRangeException">Threw if any of the walls is smaller than 5.</exception>
    public Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
        {
            throw new ArgumentOutOfRangeException("Both SizeX and SizeY must be at least 5.");
        }

        SizeX = sizeX;
        SizeY = sizeY;
    }

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns>True if in map, else false;</returns>
    public virtual bool Exist(Point p)
    {
        return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
    }

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

    public virtual void Add(Creature creature, Point position)
    {
        if (!_creatures.ContainsKey(position))
            _creatures[position] = new List<Creature>();

        _creatures[position].Add(creature);
    }

    public virtual void Remove(Creature creature, Point position)
    {
        if (_creatures.ContainsKey(position))
        {
            _creatures[position].Remove(creature);

            if (_creatures[position].Count == 0)
                _creatures.Remove(position);
        }
    }

    public virtual void Move(Creature creature, Point from, Point to)
    {
        Remove(creature, from);
        Add(creature, to);
    }

    public virtual List<Creature> At(Point position)
    {
        return _creatures.ContainsKey(position) ? _creatures[position] : new List<Creature>();
    }

    public virtual List<Creature> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}
