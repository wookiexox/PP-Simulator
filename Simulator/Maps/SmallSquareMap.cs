using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.GameLogic;
using Simulator.TextLogic;

namespace Simulator.Maps;

/// <summary>
/// Small square map with boundaries.
/// </summary>
public class SmallSquareMap : SmallMap
{
    /// <summary>
    /// Map constructor with wall size..
    /// </summary>
    /// <param name="size">Size of square's wall.</param>
    /// <exception cref="ArgumentOutOfRangeException">Threw if size is smaller than 5 or bigger than 20.</exception>
    public SmallSquareMap(int size) : base(size, size) 
    {
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
