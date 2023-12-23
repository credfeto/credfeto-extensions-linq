using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Credfeto.Extensions.Linq.Benchmarks.Helpers;
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
        this._objectItems = Enumerable.Range(start: 0, count: ITEMS)
                                      .Select(selector: SelectTestClass)
                                      .ToArray();

        this._valueItems = Enumerable.Range(start: 0, count: ITEMS)
                                     .Select(selector: SelectTestStruct)
                                     .ToArray();

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
    }

    [Benchmark]
    public void RemoveNullsClassProduction()
    {
        IEnumerable<TestClass> result = this._objectItems.RemoveNulls();

        result.TestEnumerableObjectAction();
    }

    [Benchmark]
    [SuppressMessage(category: "SonarAnalyzer.CSharp", checkId: "S3267:Loops should be simplified with LINQ", Justification = "For performance reasons")]
    public void RemoveNullsClassLoop()
    {
        IEnumerable<TestClass> result = RemoveNullsNow(this._objectItems);

        result.TestEnumerableObjectAction();

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
    }

    [Benchmark]
    [SuppressMessage(category: "SonarAnalyzer.CSharp", checkId: "S3267:Loops should be simplified with LINQ", Justification = "For performance reasons")]
    public void RemoveNullsClassLoopItem()
    {
        IEnumerable<TestClass> result = RemoveNullsNow(this._objectItems);

        result.TestEnumerableObjectAction();

        static IEnumerable<T> RemoveNullsNow<T>(IEnumerable<T?> source)
            where T : class
        {
            foreach (T? item in source)
            {
                if (Item.Exists(item))
                {
                    yield return item;
                }
            }
        }
    }

    [Benchmark]
    public void RemoveNullsClassLinq()
    {
        IEnumerable<TestClass> result = from item in this._objectItems
                                        where item is not null
                                        select item;

        result.TestEnumerableObjectAction();
    }

    [Benchmark]
    public void RemoveNullsClassLinqItem()
    {
        IEnumerable<TestClass> result = from item in this._objectItems
                                        where Item.Exists(item)
                                        select item;

        result.TestEnumerableObjectAction();
    }

    [Benchmark]
    public void RemoveNullsStructProduction()
    {
        IEnumerable<TestStruct> result = this._valueItems.RemoveNulls();

        result.TestEnumerableStructAction();
    }

    [Benchmark]
    [SuppressMessage(category: "SonarAnalyzer.CSharp", checkId: "S3267:Loops should be simplified with LINQ", Justification = "For performance reasons")]
    public void RemoveNullsStructLoop()
    {
        IEnumerable<TestStruct> result = RemoveNullsNow(this._valueItems);

        result.TestEnumerableStructAction();

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
    }

    [Benchmark]
    [SuppressMessage(category: "SonarAnalyzer.CSharp", checkId: "S3267:Loops should be simplified with LINQ", Justification = "For performance reasons")]
    public void RemoveNullsStructLoopItem()
    {
        IEnumerable<TestStruct> result = RemoveNullsNow(this._valueItems);

        result.TestEnumerableStructAction();

        static IEnumerable<T> RemoveNullsNow<T>(IEnumerable<T?> source)
            where T : struct
        {
            foreach (T? item in source)
            {
                if (Item.Exists(item))
                {
                    yield return item.Value;
                }
            }
        }
    }

    [Benchmark]
    public void RemoveNullsStructLinq()
    {
        IEnumerable<TestStruct> result = from item in this._valueItems
                                         where item.HasValue
                                         select item.Value;

        result.TestEnumerableStructAction();
    }

    [Benchmark]
    public void RemoveNullsStructLinqItem()
    {
        IEnumerable<TestStruct> result = from item in this._valueItems
                                         where Item.Exists(item)
                                         select item.Value;

        result.TestEnumerableStructAction();
    }

    [DebuggerDisplay("Value: {Value}")]
    private sealed record TestClass(int Value);

    [DebuggerDisplay("Value: {Value}")]
    private readonly record struct TestStruct(int Value);
}