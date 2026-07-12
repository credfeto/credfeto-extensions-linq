using System;
using FunFair.Test.Common;
using Xunit;

namespace Credfeto.Extensions.Linq.Tests;

public sealed class SpanExtensionsTests : TestBase
{
    [Fact]
    public void AggregateShouldReturnSeedWhenSpanIsEmpty()
    {
        ReadOnlySpan<int> input = [];

        int output = input.Aggregate(seed: 42, func: (a, b) => a + b);

        Assert.Equal(expected: 42, actual: output);
    }

    [Fact]
    public void AggregateShouldApplyFunctionAcrossAllElements()
    {
        ReadOnlySpan<int> input = [1, 2, 3, 4];

        int output = input.Aggregate(seed: 0, func: (a, b) => a + b);

        Assert.Equal(expected: 10, actual: output);
    }

    [Fact]
    public void AggregateShouldThrowWhenFuncIsNull()
    {
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            ((ReadOnlySpan<int>)[1, 2, 3]).Aggregate(seed: 0, func: null!)
        );

        Assert.Equal(expected: "func", actual: exception.ParamName);
    }
}
