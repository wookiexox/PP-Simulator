using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Rectangle
{
    public readonly int X1, Y1, X2, Y2;



    // konstruktory
    public Rectangle(int x1, int y1, int x2, int y2)
    {
        if (x1 == x2 || y1 == y2)
        {
            throw new ArgumentException("Punkty na osi X lub na osi Y nie mogą być takie same (chudy prostokąt).");
        }

        if (x1 > x2)
        {
            (x1, x2) = (x2, x1);
        }
        if (y1 > y2)
        {
            (y1, y2) = (y2, y1);
        }

        X1 = x1;
        X2 = x2;
        Y1 = y1;
        Y2 = y2;
    }

    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y)
    {

    }



    // metody
    public bool Contains(Point p)
    {
        return p.X >= X1 && p.X <= X2 && p.Y >= Y1 && p.Y <= Y2;
    }

    public override string ToString()
    {
        return $"({X1}, {Y1}):({X2}, {Y2})";
    }
}
