using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal abstract class Creature
{
    private string _name = "Unknown";
    private int _level;
    public abstract int Power { get; }

    public string Name
    {
        get { return _name; }
        init
        {
            string trimmedName = value.Trim();

            if (string.IsNullOrEmpty(trimmedName))
            {
                _name = "Unknown";
            }
            else
            {
                if (trimmedName.Length < 3)
                {
                    trimmedName = trimmedName.PadRight(3, '#');
                }
                else if (trimmedName.Length > 25)
                {
                    trimmedName = trimmedName.Substring(0, 25).TrimEnd();
                    if (trimmedName.Length < 3) trimmedName.PadRight(3, '#');
                }

                if (char.IsLower(trimmedName[0]))
                {
                    trimmedName = char.ToUpper(trimmedName[0]) + trimmedName.Substring(1);
                }

                _name = trimmedName;
            }
        }
    }

    public int Level
    {
        get { return _level; }
        init
        {
            if (value < 1)
            {
                _level = 1;
            }
            else if (value > 10)
            {
                _level = 10;
            }
            else _level = value;
        }
    }




    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {

    }




    public abstract void SayHi();

    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }

    public void Upgrade()
    {
        if (_level < 10) _level++;
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
            init
            {
                if (value < 0)
                {
                    _agility = 0;
                }
                else if (value > 10)
                {
                    _agility = 10;
                }
                else _agility = value;
            }
        }

        public Elf() : base("Unknown Elf", 1)
        {
        }

        public Elf(string name = "Unknown Elf", int level = 1, int agility = 1) : base(name, level)
        {
            Agility = agility;
        }

        public void Sing()
        {
            _singCount++;

            if (_singCount % 3 == 0)
            {
                if (_agility == 10) Console.WriteLine($"You've reached the maximum level of agility.");
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
    }

    public class Orc : Creature
    {
        private int _huntCount;
        private int _rage;
        public int Rage
        {
            get { return _rage; }
            init
            {
                if (value < 0)
                {
                    _rage = 0;
                }
                else if (value > 10)
                {
                    _rage = 10;
                }
                else _rage = value;
            }
        }

        public Orc() : base("Unknown Orc", 1) 
        {
        }

        public Orc(string name = "Unknown Orc", int level = 1, int rage = 1) : base(name, level)
        {
            Rage = rage;
        }
        public void Hunt()
        {
            _huntCount++;

            if (_huntCount % 2 == 0)
            {
                if (_rage == 10) Console.WriteLine($"You've reached the maximum level of Rage.");
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
    }
}
