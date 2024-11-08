using BenchmarkDotNet.Running;
using Benckmarks;

Console.WriteLine("Hello, World!");

var summary = BenchmarkRunner.Run<Md5VsSha256>();
