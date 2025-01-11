using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator;

public class Birds : Animals
{
    // get set
    private Boolean _canFly = true;
    public Boolean CanFly
    {
        get { return _canFly; }
        init { _canFly = value; }
    }


    // informacje
    public override string Info
    {
        get { return CanFly == true ? "fly+" : "fly-"; }
    }


    public override string Go(Direction direction)
    {
        if (Map == null) return "Creature has no map assigned.";

        Point newPosition = Map.Next(Position, direction);
        Point newDiagonalPosition = Map.NextDiagonal(Position, direction);

        if (newPosition != Position && CanFly == false)
        {
            Map.Move(this, Position, newDiagonalPosition);
            Position = newPosition;
        }
        else if (newPosition != Position && CanFly == true)
        {
            Map.Move(this, Position, newPosition);
            Map.Move(this, Position, newPosition);
            Position = newPosition;
        }

        return $"Moved to {Position}";
    }
}
