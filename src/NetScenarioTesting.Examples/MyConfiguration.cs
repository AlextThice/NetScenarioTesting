using Microsoft.Extensions.DependencyInjection;
using NetScenarioTesting.Core;
using NetScenarioTesting.Examples.Clients;

namespace NetScenarioTesting.Examples
{
    public class MyConfiguration : ScenarioTestsConfiguration
    {
        /// <summary>
        /// Configure service provider.
        /// </summary>
        /// <param name="serviceCollection">Service collection for registration.</param>
        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Calculator>();
            serviceCollection.AddScoped<CardsTestJsonClient>();
        }
    }
}