﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public readonly struct Point
{
    public readonly int X, Y;
    public Point(int x, int y) => (X, Y) = (x, y);
    public override string ToString() => $"({X}, {Y})";



    // ruch względem osi
    public Point Next(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left: return new Point(X - 1, Y);
            case Direction.Right: return new Point(X + 1, Y);
            case Direction.Up: return new Point(X, Y + 1);
            case Direction.Down: return new Point(X, Y - 1);
        }

        return new Point(X, Y);
    }



    // ruch 45 stopni
    public Point NextDiagonal(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left: return new Point(X - 1, Y + 1);
            case Direction.Right: return new Point(X + 1, Y - 1);
            case Direction.Up: return new Point(X + 1, Y + 1);
            case Direction.Down: return new Point(X - 1, Y - 1);
        }
        
        return new Point(X, Y);
    }
}
