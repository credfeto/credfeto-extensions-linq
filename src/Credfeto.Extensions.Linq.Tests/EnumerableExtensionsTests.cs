using System;
using System.Collections.Generic;
using System.Linq;
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
    public void ForEachListBranchTest()
    {
        List<int> list = [1, 2, 3];
        IEnumerable<int> input = list;

        List<int> outputs = [];

        input.ForEach(outputs.Add);

        int[] expected = [1, 2, 3];

        Assert.Equal(expected: expected, actual: outputs);
    }

    [Fact]
    public void ForEachEnumerableBranchTest()
    {
        IEnumerable<int> input = Enumerable.Range(start: 1, count: 3);

        List<int> outputs = [];

        input.ForEach(outputs.Add);

        int[] expected = [1, 2, 3];

        Assert.Equal(expected: expected, actual: outputs);
    }

    [Fact]
    public void ForEachSpanEmptyTest()
    {
        ReadOnlySpan<int> input = [];

        List<int> outputs = [];

        input.ForEach(outputs.Add);

        Assert.Empty(outputs);
    }

    [Fact]
    public void ForEachSpanTest()
    {
        ReadOnlySpan<int> input = [1, 2, 3];

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

    [Fact]
    public void RemoveNullsClassShouldThrowWhenSourceIsNull()
    {
        IEnumerable<string?> source = null!;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => source.RemoveNulls().ToArray());

        Assert.Equal(expected: "source", actual: exception.ParamName);
    }

    [Fact]
    public void RemoveNullsValueShouldThrowEagerlyWhenSourceIsNull()
    {
        IEnumerable<int?> source = null!;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => source.RemoveNulls());

        Assert.Equal(expected: "source", actual: exception.ParamName);
    }

    [Fact]
    public void ForEachShouldThrowWhenEnumerationIsNull()
    {
        IEnumerable<int> enumeration = null!;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => enumeration.ForEach(_ => { }));

        Assert.Equal(expected: "enumeration", actual: exception.ParamName);
    }

    [Fact]
    public void ForEachShouldThrowWhenActionIsNull()
    {
        int[] input = [1, 2, 3];

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => input.ForEach(null!));

        Assert.Equal(expected: "action", actual: exception.ParamName);
    }

    [Fact]
    public void ForEachSpanShouldThrowWhenActionIsNull()
    {
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            ((ReadOnlySpan<int>)[1, 2, 3]).ForEach(null!)
        );

        Assert.Equal(expected: "action", actual: exception.ParamName);
    }

    [Fact]
    public void FirstOrNullShouldThrowWhenListIsNull()
    {
        IEnumerable<int> list = null!;

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => list.FirstOrNull(x => x == 1));

        Assert.Equal(expected: "list", actual: exception.ParamName);
    }

    [Fact]
    public void FirstOrNullShouldThrowWhenPredicateIsNull()
    {
        int[] items = [1, 2, 3];

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => items.FirstOrNull(null!));

        Assert.Equal(expected: "predicate", actual: exception.ParamName);
    }
}
