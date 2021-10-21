using System;

namespace NetScenarioTesting.Core.Clients
{
    /// <summary>
    /// Implemented tests http client.
    /// </summary>
    public class HttpTestClient : BaseHttpTestClient
    {
        /// <summary>
        /// Not public constructor.
        /// </summary>
        private HttpTestClient()
        {
        }
        
        /// <summary>
        /// Create new test http client.
        /// </summary>
        /// <param name="baseUrl">Base url for service.</param>
        /// <returns>New test http client.</returns>
        public static IHttpTestClient Create(string baseUrl)
        {
            var client = new HttpTestClient
            {
                _httpClient =
                {
                    BaseAddress = string.IsNullOrWhiteSpace(baseUrl) ? null : new Uri(baseUrl)
                }
            };

            return client;
        }
    }
}