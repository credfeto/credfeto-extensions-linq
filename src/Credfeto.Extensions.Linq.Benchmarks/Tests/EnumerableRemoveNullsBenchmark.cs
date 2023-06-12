using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Credfeto.Extensions.Linq.Helpers;

namespace Credfeto.Extensions.Linq.Benchmarks.Tests;

[SimpleJob]
[MinColumn]
[MaxColumn]
[MeanColumn]
[MedianColumn]
[MemoryDiagnoser(false)]
public abstract class EnumerableRemoveNullsBenchmark
{
    private const int ITEMS = 100000;
    private const int SELECTION = 2;
    private readonly IReadOnlyList<TestClass?> _objectItems;
    private readonly IReadOnlyList<TestStruct?> _valueItems;

    protected EnumerableRemoveNullsBenchmark()
    {
        static TestClass? SelectTestClass(int x)
        {
            return x % SELECTION == 0
                ? new TestClass(x)
                : null;
        }

        static TestStruct? SelectTestStruct(int x)
        {
            return x % SELECTION == 0
                ? new TestStruct(x)
                : null;
        }

        this._objectItems = Enumerable.Range(start: 0, count: ITEMS)
                                      .Select(selector: SelectTestClass)
                                      .ToArray();

        this._valueItems = Enumerable.Range(start: 0, count: ITEMS)
                                     .Select(selector: SelectTestStruct)
                                     .ToArray();
    }

    [Benchmark]
    public void RemoveNullsClassProduction()
    {
        IReadOnlyList<TestClass> result = this._objectItems.RemoveNulls()
                                              .ToArray();

        TestAction(result);
    }

    [Benchmark]
    [SuppressMessage(category: "SonarAnalyzer.CSharp", checkId: "S3267:Loops should be simplified with LINQ", Justification = "For performance reasons")]
    public void RemoveNullsClassLoop()
    {
        static IEnumerable<T> RemoveNullsNow<T>(IEnumerable<T?> source)
            where T : class
        {
            foreach (T? item in source)
            {
                if (item is not null)
                {
                    yield return item;
                }
            }
        }

        IReadOnlyList<TestClass> result = RemoveNullsNow(this._objectItems)
            .ToArray();

        TestAction(result);
    }

    [Benchmark]
    public void RemoveNullsClassLinq()
    {
        IReadOnlyList<TestClass> result = (from item in this._objectItems
                                           where item is not null
                                           select item).ToArray();

        TestAction(result);
    }

    [Benchmark]
    public void RemoveNullsClassLinqItem()
    {
        IReadOnlyList<TestClass> result = (from item in this._objectItems
                                           where Item.Exists(item)
                                           select item).ToArray();

        TestAction(result);
    }

    [Benchmark]
    public void RemoveNullsStructProduction()
    {
        IReadOnlyList<TestStruct> result = this._valueItems.RemoveNulls()
                                               .ToArray();

        TestAction(result);
    }

    [Benchmark]
    [SuppressMessage(category: "SonarAnalyzer.CSharp", checkId: "S3267:Loops should be simplified with LINQ", Justification = "For performance reasons")]
    public void RemoveNullsStructLoop()
    {
        static IEnumerable<T> RemoveNullsNow<T>(IEnumerable<T?> source)
            where T : struct
        {
            foreach (T? item in source)
            {
                if (item.HasValue)
                {
                    yield return item.Value;
                }
            }
        }

        IReadOnlyList<TestStruct> result = RemoveNullsNow(this._valueItems)
            .ToArray();

        TestAction(result);
    }

    [Benchmark]
    public void RemoveNullsStructLinq()
    {
        IReadOnlyList<TestStruct> result = (from item in this._valueItems
                                            where item.HasValue
                                            select item.Value).ToArray();

        TestAction(result);
    }

    [Benchmark]
    public void RemoveNullsStructLinqItem()
    {
        IReadOnlyList<TestStruct> result = (from item in this._valueItems
                                            where Item.Exists(item)
                                            select item.Value).ToArray();

        TestAction(result);
    }

    [SuppressMessage(category: "ReSharper", checkId: "UnusedParameter.Local", Justification = "Deliberately blank")]
    private static void TestAction<T>(T value)
    {
        // Deliberately blank
    }

    [DebuggerDisplay("Value: {Value}")]
    private sealed record class TestClass(int Value);

    [DebuggerDisplay("Value: {Value}")]
    private readonly record struct TestStruct(int Value);
}