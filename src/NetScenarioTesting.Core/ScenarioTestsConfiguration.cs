using System;
using System.IO;
using Microsoft.Extensions.Configuration;
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
        /// <param name="assemblyName">Assembly name.</param>
        /// <returns>Service provider.</returns>
        public IServiceProvider Build(string assemblyName)
        {
            var serviceCollection = new ServiceCollection();
            var configurationBuilder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                                .AddJsonFile("appsettings.json", false);
            configurationBuilder.AddJsonFile($"appsettings.{assemblyName}.json", true);

            var configuration = (IConfiguration)configurationBuilder.Build();
            serviceCollection.AddSingleton(configuration);
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