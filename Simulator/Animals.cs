﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

internal class Animals
{
    private string _description = "Unknown";
    private uint _size = 3;
    public uint Size
    {
        get { return _size; }
        init { _size = (uint)Validator.Limiter((int)value, 3, int.MaxValue); }
    }

    public string Description
    {
        get { return _description; }
        init { _description = Validator.Shortener(value, 3, 15, '#'); }
    }

    public Animals(string description, uint size = 3)
    {
        Description = description;
        Size = size;
    }
    public Animals()
    {

    }
    public virtual string Info { get; }

    public override string ToString()
    {
        if (Info != null)
        {
            return $"{GetType().Name.ToUpper()}: {Description} ({Info}) <{Size}>";
        }

        return $"{GetType().Name.ToUpper()}: {Description} <{Size}>";
    }




    public class Birds : Animals
    {
        private Boolean _canFly = true;
        public Boolean CanFly
        {
            get { return _canFly; }
            init { _canFly = value; }
        }

        public override string Info
        {
            get { return CanFly == true ? "fly+" : "fly-"; }
        }
    }
}
