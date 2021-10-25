using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using NetScenarioTesting.Core.Factory;

namespace NetScenarioTesting.Core
{
    /// <summary>
    /// Tests runner
    /// </summary>
    internal class ScenarioTestRunner : ITestRunner
    {
        private readonly IEnumerable<TestsRunnerData> _testsRunnerData;
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="testsRunnerData">TestsByAssemblies.</param>
        public ScenarioTestRunner(IEnumerable<TestsRunnerData> testsRunnerData)
        {
            _testsRunnerData = testsRunnerData;
        }

        /// <summary>
        /// Run all tests.
        /// </summary>
        public async Task RunAsync()
        {
            foreach (var testsRunnerData in _testsRunnerData) 
                await RunAsync(testsRunnerData);
        }

        /// <summary>
        /// Tests in runner.
        /// </summary>
        public IReadOnlyCollection<NetScenarioTest> GetTests()
        {
            var result = new List<NetScenarioTest>();
            foreach (var testData in _testsRunnerData)
            {
                foreach (var test in testData.TestTypes)
                {
                    var testInfo = new NetScenarioTest(testData.Assembly, test);
                    result.Add(testInfo);
                }
            }

            return result;
        }

        private static async Task RunAsync(TestsRunnerData testsRunnerData)
        {
            foreach (var testInstance in testsRunnerData.TestTypes) 
                await RunAsync(testInstance, testsRunnerData.Factory);
        }

        /// <summary>
        /// Run single test.
        /// </summary>
        /// <param name="testType">Test class type.</param>
        /// <param name="testInstanceFactory">Factory test instance object by type.</param>
        private static async Task RunAsync(Type testType, TestInstanceFactory testInstanceFactory)
        {
            try
            {
                var classAttribute = testType.GetCustomAttribute<ScenarioTestClass>();
                Console.WriteLine($"Start test: " + (classAttribute?.Name ?? testType.Name));

                var testInstance = testInstanceFactory.Create(testType);
                var methods = testType.GetMethods().Where(x => x.GetCustomAttribute<ScenarioTestItem>() != null);
                foreach (var method in methods)
                {
                    Console.WriteLine($"Execute test item: " + (method.GetCustomAttribute<ScenarioTestItem>()?.Description ?? method.Name));
                    var result = method.Invoke(testInstance, Array.Empty<object>());
                    if (result is Task taskResult)
                        await taskResult;
                }
            }
            catch (Exception e)
            {
                // TODO 2021/10/31 griva write to TestLog.
                Console.WriteLine(e);
            }
        }
    }
}