﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Animals
{
    public required string Description { get; set; }
    public uint Size { get; set; } = 3;

    public string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}
