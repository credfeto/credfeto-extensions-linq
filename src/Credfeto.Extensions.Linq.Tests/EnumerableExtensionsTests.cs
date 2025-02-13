using System.Linq;
using FunFair.Test.Common;
using Xunit;

namespace Credfeto.Extensions.Linq.Tests;

public sealed class EnumerableExtensionsTests : TestBase
{
    [Fact]
    public void ShouldRemoveNullsClass()
    {
        string?[] input =
        [
            "A",
            null,
            "B",
            null,
            "C"
        ];

        string[] output = [..input.RemoveNulls()];

        string[] expected =
        [
            "A",
            "B",
            "C"
        ];

        Assert.Equal(expected: expected, actual: output);
    }

    [Fact]
    public void ShouldRemoveNullsValue()
    {
        int?[] input =
        [
            1,
            null,
            2,
            null,
            3
        ];

        int[] output = [..input.RemoveNulls()];

        int[] expected =
        [
            1,
            2,
            3
        ];

        Assert.Equal(expected: expected, actual: output);
    }
}