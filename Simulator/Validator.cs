using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        if (value < min) return min;
        if (value > max) return max;
        return value;
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        string name = value.Trim();
        
        if (value.Length > max)
        {
            name = value.Substring(0, max - 1);
        }
        else if (value.Length < min)
        {
            name = value.PadRight(min, placeholder);
        }

        return char.ToUpper(name[0]) + name.Substring(1);
    }
}
