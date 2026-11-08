using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.Emit;

namespace Credfeto.Extensions.Linq.Benchmarks.Tests.Bench;

// In-process so BenchmarkDotNet does not validate the SDK for a target framework it does not yet recognise
public sealed class InProcessDryConfig : ManualConfig
{
    public InProcessDryConfig()
    {
        this.AddJob(Job.Dry.WithToolchain(InProcessEmitToolchain.Instance));
    }
}
