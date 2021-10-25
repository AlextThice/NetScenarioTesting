using NetScenarioTesting.Core;

namespace NetScenarioTesting.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = TestRunnerFactory.Create();
            runner.RunAsync();
        }
    }
}