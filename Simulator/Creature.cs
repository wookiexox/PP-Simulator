using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Creature
{
    private string _name = "Unknown";
    private int _level;

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

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }

    public void Upgrade()
    {
        if (_level < 10) _level++;
    }
}
