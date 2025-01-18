using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.GameLogic;
using Simulator.Maps;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ValidCoordinates_ShouldCreateRectangle()
    {
        var rect = new Rectangle(1, 2, 3, 4);
        Assert.Equal("(1, 2):(3, 4)", rect.ToString());
    }

    [Fact]
    public void Constructor_InvalidCoordinates_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(3, 4, 3, 2));
    }

    [Fact]
    public void Contains_PointInsideRectangle_ShouldReturnTrue()
    {
        var rect = new Rectangle(1, 1, 5, 5);
        var point = new Point(3, 3);
        Assert.True(rect.Contains(point));
    }

    [Fact]
    public void Contains_PointOutsideRectangle_ShouldReturnFalse()
    {
        var rect = new Rectangle(1, 1, 5, 5);
        var point = new Point(6, 6);
        Assert.False(rect.Contains(point));
    }

    [Fact]
    public void ToString_ValidRectangle_ShouldReturnFormattedString()
    {
        var rect = new Rectangle(2, 3, 7, 8);
        Assert.Equal("(2, 3):(7, 8)", rect.ToString());
    }
}
