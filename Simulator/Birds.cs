using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Birds : Animals
{
    // get set
    private Boolean _canFly = true;
    public Boolean CanFly
    {
        get { return _canFly; }
        init { _canFly = value; }
    }



    // informacje
    public override string Info
    {
        get { return CanFly == true ? "fly+" : "fly-"; }
    }
}
