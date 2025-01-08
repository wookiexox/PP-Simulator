using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Creature
{
    // get set 
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



    // informacje
    public virtual string Info { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Name} [{Level}]{Info}";
    }


    // konktruktory
    public Creature(string name, int level)
    {
        Name = name;
        Level = level;
    }
        
    public Creature()
    {

    }



    // akcje
    public void Upgrade()
    {
        if (_level < 10) _level++;
    }

    public virtual void SayHi() { }

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
}
