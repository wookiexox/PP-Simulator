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
    private readonly Dictionary<Point, List<IMappable>> _creatures = new();

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

    public abstract void Add(IMappable creature, Point position);

    public abstract void Remove(IMappable creature, Point position);

    public abstract void Move(IMappable creature, Point from, Point to);

    public abstract List<IMappable> At(Point position);

    public abstract List<IMappable> At(int x, int y);
}
