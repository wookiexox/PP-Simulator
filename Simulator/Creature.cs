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

    public virtual string Greeting() 
    { 
        return "";
    }

    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions)
    {
        List<string> result = new List<string>();
        foreach (Direction direction in directions)
        {
            result.Add(Go(direction));
        }
        return result.ToArray();
    }


    public string[] Go(string directionsString)
    {
        Direction[] directions = DirectionParser.Parse(directionsString);
        return Go(directions);
    }
}
