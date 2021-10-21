using System;
using Microsoft.Extensions.DependencyInjection;

namespace NetScenarioTesting.Core
{
    /// <summary>
    /// Base class for configuring available services in tests
    /// </summary>
    public abstract class ScenarioTestsConfiguration
    {
        /// <summary>
        /// Build service provider with implemented configuration.
        /// </summary>
        /// <returns>Service provider.</returns>
        public IServiceProvider Build()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            return serviceCollection.BuildServiceProvider();
        }
        
        /// <summary>
        /// Configure service provider.
        /// </summary>
        /// <param name="serviceCollection">Service collection for registration.</param>
        protected abstract void ConfigureServices(IServiceCollection serviceCollection);
    }
}