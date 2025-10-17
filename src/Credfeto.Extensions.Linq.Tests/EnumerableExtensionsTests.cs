using System.Collections.Generic;
using FunFair.Test.Common;
using Xunit;

namespace Credfeto.Extensions.Linq.Tests;

public sealed class EnumerableExtensionsTests : TestBase
{
    [Fact]
    public void ShouldRemoveNullsClass()
    {
        string?[] input = ["A", null, "B", null, "C"];

        string[] output = [.. input.RemoveNulls()];

        string[] expected = ["A", "B", "C"];

        Assert.Equal(expected: expected, actual: output);
    }

    [Fact]
    public void ShouldRemoveNullsValue()
    {
        int?[] input = [1, null, 2, null, 3];

        int[] output = [.. input.RemoveNulls()];

        int[] expected = [1, 2, 3];

        Assert.Equal(expected: expected, actual: output);
    }

    [Fact]
    public void ForEachTest()
    {
        int[] input = [1, 2, 3];

        List<int> outputs = [];

        input.ForEach(outputs.Add);

        int[] expected = [1, 2, 3];

        Assert.Equal(expected: expected, actual: outputs);
    }

    [Fact]
    public void FirstOrNullMatch()
    {
        int[] items = [1, 2, 3, 4];

        int? found = items.FirstOrNull(x => x == 3);
        Assert.NotNull(found);
        Assert.Equal(3, found.Value);
    }

    [Fact]
    public void FirstOrNullNoMatch()
    {
        int[] items = [1, 2, 3, 4];

        int? found = items.FirstOrNull(x => x == 7);
        Assert.Null(found);
    }
}
