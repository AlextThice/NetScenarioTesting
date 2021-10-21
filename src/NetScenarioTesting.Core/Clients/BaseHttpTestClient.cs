using System;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetScenarioTesting.Core.Clients
{
    /// <summary>
    /// Base test http client.
    /// </summary>
    public abstract class BaseHttpTestClient : IHttpTestClient
    {
        protected readonly HttpClient _httpClient;
        private readonly HttpRequestMessage _request;

        /// <summary>
        /// Constructor.
        /// </summary>
        protected BaseHttpTestClient()
        {
            _httpClient = new HttpClient();
            _request = new HttpRequestMessage();
        }

        /// <summary>
        /// Append http header.
        /// </summary>
        /// <param name="headerName">Header item name.</param>
        /// <param name="headerValue">Header item value.</param>
        /// <returns>Current client.</returns>
        public virtual IHttpTestClient AddHeader(string headerName, string headerValue)
        {
            _request.Headers.Add(headerName, headerValue);
            return this;
        }
        
        /// <summary>
        /// Set url (absolute or relative, if base url set in configs).
        /// </summary>
        /// <param name="url">Url for request.</param>
        /// <returns>Current client.</returns>
        public virtual IHttpTestClient SetUrlPath(string url)
        {
            _request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
            return this;
        }
        
        /// <summary>
        /// Set body for request.
        /// </summary>
        /// <param name="body">Body for request.</param>
        /// <returns>Current client.</returns>
        public virtual IHttpTestClient SetBody(string body)
        {
            _request.Content = new StringContent(body, Encoding.UTF8, MediaTypeNames.Application.Json);
            return this;
        }

        /// <summary>
        /// Set http method for request.
        /// </summary>
        /// <param name="method">Http method.</param>
        /// <returns>Current client.</returns>
        public virtual IHttpTestClient SetMethod(HttpMethod method)
        {
            _request.Method = method;
            return this;
        }

        /// <summary>
        /// Execute request and get result.
        /// </summary>
        /// <returns>Request result as Json.</returns>
        public virtual async Task<JContainer> SendAndReadAsync()
        {
            var response = await _httpClient.SendAsync(_request);
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException("", null, response.StatusCode);
            
            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<JContainer>(stringResult);
        }

        /// <summary>
        /// Execute request and get result.
        /// </summary>
        /// <returns>Request result as Json.</returns>
        public virtual async Task SendAsync()
        {
            var response = await _httpClient.SendAsync(_request);
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException("", null, response.StatusCode);
        }
    }
}