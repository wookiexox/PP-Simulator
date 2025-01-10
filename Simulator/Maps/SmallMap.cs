using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    protected SmallMap(int size) : base(size, size)
    {
        if (size > 20)
        {
            throw new ArgumentOutOfRangeException("Both SizeX and SizeY must be smaller than 20.");
        }
    }
}
