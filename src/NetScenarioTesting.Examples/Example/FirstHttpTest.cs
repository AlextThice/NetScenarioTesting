using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NetScenarioTesting.Core;
using NetScenarioTesting.Core.Clients;

namespace NetScenarioTesting.Examples.Example
{
    [ScenarioTestClass]
    public class FirstHttpTest
    {
        private string _cardsId;
        private string _cardsBody;
        private readonly string _baseUrl;
        
        public FirstHttpTest(IConfiguration configuration)
        {
            _baseUrl = configuration.GetConnectionString("CardsApiAddress");
        }

        [ScenarioTestItem]
        public async Task OpenCard()
        {
            var result = await HttpTestClient.Create(_baseUrl)
                                             .SetMethod(HttpMethod.Post)
                                             .SetUrlPath("api/BusinessEntry/OpenCardWithParameters")
                                             .SetBody("{'id':20739,'parameters':null}")
                                             .SendAndReadAsync();
            _cardsId = result["id"].ToString();
            _cardsBody = result.ToString();
        }
        
        [ScenarioTestItem]
        public async Task ValidateCards()
        {
            await HttpTestClient.Create(_baseUrl)
                                .SetMethod(HttpMethod.Post)
                                .SetUrlPath($"api/BusinessEntry/ValidateCardInstance?guid={_cardsId}")
                                .SetBody(_cardsBody)
                                .SendAsync();
        }
    }
}