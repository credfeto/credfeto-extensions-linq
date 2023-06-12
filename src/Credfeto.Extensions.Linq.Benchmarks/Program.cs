#define ENUMERABLE_REMOVE_NULLS

using System.Diagnostics;
using BenchmarkDotNet.Running;
using Credfeto.Extensions.Linq.Benchmarks.Tests;

namespace Credfeto.Extensions.Linq.Benchmarks;

public static class Program
{
    public static void Main()
    {
        ItemRemoveNullsBenchmarkTests();
    }

    [Conditional("ENUMERABLE_REMOVE_NULLS")]
    private static void ItemRemoveNullsBenchmarkTests()
    {
        BenchmarkRunner.Run<EnumerableRemoveNullsBenchmark>();
    }
}