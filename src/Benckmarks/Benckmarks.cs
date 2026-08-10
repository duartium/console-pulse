#:package BenchmarkDotNet@0.14.0
#:property PublishAot=false

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");

// File-based apps have no .csproj, so benchmarks must run in-process
var config = DefaultConfig.Instance
	.AddJob(Job.ShortRun.WithToolchain(InProcessEmitToolchain.Instance).AsDefault());

var summary = BenchmarkRunner.Run<Md5VsSha256>(config);

[MemoryDiagnoser]
public class Md5VsSha256
{
	private const int N = 10000;
	private readonly byte[] data;

	private readonly SHA256 sha256 = SHA256.Create();
	private readonly MD5 md5 = MD5.Create();

	public Md5VsSha256()
	{
		data = new byte[N];
		new Random(42).NextBytes(data);
	}

	[Benchmark]
	public byte[] Sha256() => sha256.ComputeHash(data);

	[Benchmark]
	public byte[] Md5() => md5.ComputeHash(data);
}
