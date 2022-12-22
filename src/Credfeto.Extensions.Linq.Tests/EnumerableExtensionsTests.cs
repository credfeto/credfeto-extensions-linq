using System.Linq;
using FunFair.Test.Common;
using Xunit;

namespace Credfeto.Extensions.Linq.Tests;

public sealed class EnumerableExtensionsTests : TestBase
{
    [Fact]
    public void ShouldRemoveNulls()
    {
        string?[] input =
        {
            "A",
            null,
            "B",
            null,
            "C"
        };

        string[] output = input.RemoveNulls()
                               .ToArray();

        Assert.Equal(new[]
                     {
                         "A",
                         "B",
                         "C"
                     },
                     actual: output);
    }
}