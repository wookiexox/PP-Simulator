using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.GameLogic;
using Simulator.Maps;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldSetCoordinates()
    {
        var point = new Point(3, 4);
        Assert.Equal(3, point.X);
        Assert.Equal(4, point.Y);
    }

    [Fact]
    public void Equals_SameCoordinates_ShouldReturnTrue()
    {
        var point1 = new Point(3, 4);
        var point2 = new Point(3, 4);
        Assert.Equal(point1, point2);
    }

    [Fact]
    public void Equals_DifferentCoordinates_ShouldReturnFalse()
    {
        var point1 = new Point(3, 4);
        var point2 = new Point(4, 3);
        Assert.NotEqual(point1, point2);
    }
}
