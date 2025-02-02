﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.TextLogic;

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

        if (name.Length > max)
        {
            name = name.Substring(0, max);
        }
        else if (name.Length < min)
        {
            name = name.PadRight(min, placeholder);
        }

        return char.ToUpper(name[0]) + name.Substring(1);
    }
}
