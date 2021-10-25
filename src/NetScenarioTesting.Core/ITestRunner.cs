using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetScenarioTesting.Core
{
    /// <summary>
    /// Tests runner.
    /// </summary>
    public interface ITestRunner
    {
        /// <summary>
        /// Run tests.
        /// </summary>
        public Task RunAsync();

        /// <summary>
        /// Tests in runner.
        /// </summary>
        IReadOnlyCollection<NetScenarioTest> GetTests();
    }
}