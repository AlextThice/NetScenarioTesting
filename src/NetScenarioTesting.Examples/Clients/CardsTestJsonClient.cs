using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NetScenarioTesting.Core.Clients;
using Newtonsoft.Json.Linq;

namespace NetScenarioTesting.Examples.Clients
{
    public class CardsTestJsonClient : BaseHttpTestClient
    {
        private readonly string _baseUrl;
            
        public CardsTestJsonClient(IConfiguration configuration)
        {
            _baseUrl = configuration.GetConnectionString("CardsApiAddress");
        }

        public async Task<JContainer> OpenCardAsync(int cardId, string parameters)
        {
            var result = await HttpTestClient.Create(_baseUrl)
                                             .SetMethod(HttpMethod.Post)
                                             .SetUrlPath("api/BusinessEntry/OpenCardWithParameters")
                                             .SetBody($"{{'id':{cardId},'parameters': {parameters}}}")
                                             .SendAndReadAsync();
            return result;
        }
        
        public async Task ValidateCardsAsync(string cardId, string cardBody)
        {
            await HttpTestClient.Create(_baseUrl)
                                .SetMethod(HttpMethod.Post)
                                .SetUrlPath($"api/BusinessEntry/ValidateCardInstance?guid={cardId}")
                                .SetBody(cardBody)
                                .SendAndReadAsync();
        }
    }
}