using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

internal class Orc : Creature
{
    // get set
    private int _huntCount;
    private int _rage;
    public int Rage
    {
        get { return _rage; }
        init { _rage = Validator.Limiter(value, 0, 10); }
    }



    // informacje
    public override int Power
    {
        get { return 7 * Level + 3 * Rage; }
    }

    public override string Info
    {
        get { return $"[{Rage}]"; }
    }



    // konstruktory
    public Orc() : base("Unknown Orc", 1)
    {
    }

    public Orc(string name = "Unknown Orc", int level = 1, int rage = 0) : base(name, level)
    {
        Rage = rage;
    }



    // akcje
    public void Hunt()
    {
        _huntCount++;

        if (_huntCount % 2 == 0 && _rage < 10)
        {
            _rage = Math.Min(_rage + 1, 10);
        }
    }
    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
    }
}
