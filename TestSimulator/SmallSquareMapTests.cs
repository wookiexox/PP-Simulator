using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;
using Simulator;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    public void Constructor_ValidSize_ShouldSetSize(int size)
    {
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Fact]
    public void Exist_PointWithinBounds_ShouldReturnTrue()
    {
        var map = new SmallSquareMap(10);
        var point = new Point(5, 5);
        Assert.True(map.Exist(point));
    }

    [Fact]
    public void Exist_PointOutsideBounds_ShouldReturnFalse()
    {
        var map = new SmallSquareMap(10);
        var point = new Point(15, 15);
        Assert.False(map.Exist(point));
    }

    [Fact]
    public void Next_ValidDirection_ShouldReturnCorrectPoint()
    {
        var map = new SmallSquareMap(10);
        var startPoint = new Point(5, 5);
        Assert.Equal(new Point(5, 6), map.Next(startPoint, Direction.Up));
        Assert.Equal(new Point(5, 4), map.Next(startPoint, Direction.Down));
        Assert.Equal(new Point(4, 5), map.Next(startPoint, Direction.Left));
        Assert.Equal(new Point(6, 5), map.Next(startPoint, Direction.Right));
    }

    [Fact]
    public void Next_OutOfBounds_ShouldReturnSamePoint()
    {
        var map = new SmallSquareMap(10);
        var startPoint = new Point(0, 0);
        Assert.Equal(startPoint, map.Next(startPoint, Direction.Left));
        Assert.Equal(startPoint, map.Next(startPoint, Direction.Down));
    }
}