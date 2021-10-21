using Microsoft.Extensions.DependencyInjection;

namespace NetScenarioTesting.Core
{
    /// <summary>
    /// Simple test configuration class.
    /// </summary>
    internal class SimpleScenarioTestsConfiguration : ScenarioTestsConfiguration
    {
        /// <summary>
        /// Configure service provider.
        /// </summary>
        /// <param name="serviceCollection">Service collection for registration.</param>
        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {
        }
    }
}