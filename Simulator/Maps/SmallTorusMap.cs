using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
    }

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        return new Point(
            (nextPoint.X + SizeX) % SizeX,
            (nextPoint.Y + SizeY) % SizeY
        );
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextDiagonalPoint = p.NextDiagonal(d);
        return new Point(
            (nextDiagonalPoint.X + SizeX) % SizeX,
            (nextDiagonalPoint.Y + SizeY) % SizeY
        );
    }
}
