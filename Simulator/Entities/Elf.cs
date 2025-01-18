using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.TextLogic;

namespace Simulator.Entities;

public class Elf : Creature
{
    // get set 
    private int _singCount;
    private int _agility;
    public int Agility
    {
        get { return _agility; }
        init { _agility = Validator.Limiter(value, 0, 10); }
    }



    // informacje
    public override int Power
    {
        get { return 8 * Level + 2 * Agility; }
    }

    public override string Info
    {
        get { return $"[{Agility}]"; }
    }



    // konstruktory
    public Elf() : base("Unknown Elf", 0)
    {
    }

    public Elf(string name = "Unknown Elf", int level = 0, int agility = 0) : base(name, level)
    {
        Agility = agility;
    }



    // akcje
    public void Sing()
    {
        _singCount++;

        if (_singCount % 3 == 0 && _agility < 10)
        {
            _agility = Math.Min(_agility + 1, 10);
        }
    }

    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
    }
}
