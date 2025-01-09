using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(15, 1, 10, 10)]
    [InlineData(-3, 1, 10, 1)]
    public void Limiter_ShouldRestrictLevelWithinBounds(int level, int min, int max, int expected)
    {
        var result = Validator.Limiter(level, min, max);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("Alex", 3, 6, "Alex")]
    [InlineData("X        ", 3, 6, "X##")]
    [InlineData("LongNameForCharacter", 3, 6, "LongNa")]
    public void Shortener_ShouldAdjustNameLength(string name, int min, int max, string expected)
    {
        var result = Validator.Shortener(name, min, max, '#');
        Assert.Equal(expected, result);
    }
}
