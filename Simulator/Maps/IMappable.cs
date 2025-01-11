using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public interface IMappable
{
    void AssignMap(Map map, Point position);
    string Go(Direction direction);
}
