using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Elf : Creature
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

        if (_singCount % 3 == 0)
        {
            if (_agility == 10) Console.WriteLine($"{Name} is singing. You've reached the maximum level of agility.");
            else
            {
                _agility = Math.Min(_agility + 1, 10);
                Console.WriteLine($"{Name} is singing. Agility increased to {Agility}.");
            }
        }
        else Console.WriteLine($"{Name} is singing.");
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    }
}
