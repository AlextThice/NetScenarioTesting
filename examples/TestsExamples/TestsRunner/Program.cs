using System;
using NetScenarioTesting.Core;

namespace TestsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var runner = TestRunnerFactory.Create();
            runner.RunAsync();
        }
    }
}