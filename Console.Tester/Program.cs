using BenchmarkDotNet.Running;
using Tests;

namespace Console.Tester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkBinarySearch>();
        }
    }
}