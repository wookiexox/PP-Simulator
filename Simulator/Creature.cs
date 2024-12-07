using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Creature
{
    private string _name = "Unknown";
    private int _level;
    public virtual int Power { get; }

    public string Name
    {
        get { return _name; }
        init { _name = Validator.Shortener(value, 3, 20, '#'); }
    } 

    public int Level
    {
        get { return _level; }
        init { _level = Validator.Limiter(value, 0, 10); }
    }




    public Creature(string name, int level)
    {
        Name = name;
        Level = level;
    }
        
    public Creature()
    {

    }




    public virtual void SayHi() { }

    public virtual string Info { get; }

    public void Upgrade()
    {
        if (_level < 10) _level++;
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Name} [{Level}]{Info}";
    }




    public void Go(Direction direction)
    {
        string directionString = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {directionString}");
    }
    
    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directionsString)
    {
        Direction[] directions = DirectionParser.Parse(directionsString);
        Go(directions);
    }




    public class Elf : Creature
    {
        private int _singCount;
        private int _agility;
        public int Agility
        {
            get { return _agility; }
            init { _agility = Validator.Limiter(value, 0, 10); }
        }

        public Elf() : base("Unknown Elf", 0)
        {
        }

        public Elf(string name = "Unknown Elf", int level = 0, int agility = 0) : base(name, level)
        {
            Agility = agility;
        }

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

        public override int Power
        {
            get { return 8 * Level + 2 * Agility; }
        }

        public override string Info
        {
            get { return $"[{Agility}]"; }
        }
    }

    public class Orc : Creature
    {
        private int _huntCount;
        private int _rage;
        public int Rage
        {
            get { return _rage; }
            init { _rage = Validator.Limiter(value, 0, 10); }
        }

        public Orc() : base("Unknown Orc", 1) 
        {
        }

        public Orc(string name = "Unknown Orc", int level = 1, int rage = 0) : base(name, level)
        {
            Rage = rage;
        }
        public void Hunt()
        {
            _huntCount++;

            if (_huntCount % 2 == 0)
            {
                if (_rage == 10) Console.WriteLine($"{Name} is hunting. You've reached the maximum level of Rage.");
                else
                {
                    _rage = Math.Min(_rage + 1, 10);
                    Console.WriteLine($"{Name} is hunting. Rage increased to {Rage}.");
                }
            }
            else Console.WriteLine($"{Name} is hunting.");
        }

        public override void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
        }

        public override int Power
        {
            get { return 7 * Level + 3 * Rage; }
        }

        public override string Info
        {
            get { return $"[{Rage}]"; }
        }
    }
}
