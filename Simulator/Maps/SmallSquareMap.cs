using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

/// <summary>
/// Small square map with given size
/// </summary>
internal class SmallSquareMap : Map
{
    public int Size { get; }

    /// <summary>
    /// Map constructor with size arg.
    /// </summary>
    /// <param name="size">Size of square's wall.</param>
    /// <exception cref="ArgumentOutOfRangeException">Threw if size is smaller than 5 or bigger than 20.</exception>
    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Bok planszy powinien mieć długośc 5-20.");
        }

        Size = size;
    }

    /// <summary>
    /// Check if point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
    }

    /// <summary>
    /// Next position to a point in a given direction.
    /// If next point is outside of the map, move is not done.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point if it's in map. Else, starting point.</returns>
    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        return Exist(nextPoint) ? nextPoint : p;
    }

    /// <summary>
    /// Next position to a point in a given direction,
    /// but 45 degrees clockwise.
    /// If next point is outside of the map, move is not done.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point if it's in map. Else, starting point.</returns>
    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextDiagonalPoint = p.NextDiagonal(d);
        return Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
    }
}
