using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using Credfeto.Extensions.Linq.Benchmarks.Tests.Bench;
using FunFair.Test.Common;
using Xunit;

namespace Credfeto.Extensions.Linq.Benchmarks.Tests;

public sealed class EnumerableRemoveNullsTests : LoggingTestBase
{
    public EnumerableRemoveNullsTests(ITestOutputHelper output)
        : base(output) { }

    [Fact]
    public void Run_Benchmarks()
    {
        (Summary _, AccumulationLogger logger) = Benchmark<EnumerableRemoveNullsBenchmark>();

        this.Output.WriteLine(logger.GetLog());
    }
}
