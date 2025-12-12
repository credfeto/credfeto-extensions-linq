using System.Diagnostics;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Credfeto.Extensions.Linq.Benchmarks.Tests;

namespace Credfeto.Extensions.Linq.Benchmarks;

public sealed class EnumerableRemoveNullsTests : LoggingTestBase
{
    public ItemRemoveNullsTests(ITestOutputHelper output)
        : base(output) { }

    [Fact]
    public void Run_Benchmarks()
    {
        (Summary _, AccumulationLogger logger) = Benchmark<EnumerableRemoveNullsBenchmark>();

        this.Output.WriteLine(logger.GetLog());
    }
}
