using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace NetScenarioTesting.Core.Clients
{
    /// <summary>
    /// Interface tests http client.
    /// </summary>
    public interface IHttpTestClient
    {
        /// <summary>
        /// Append http header.
        /// </summary>
        /// <param name="headerName">Header item name.</param>
        /// <param name="headerValue">Header item value.</param>
        /// <returns>Current client.</returns>
        IHttpTestClient AddHeader(string headerName, string headerValue);

        /// <summary>
        /// Set url (absolute or relative, if base url set in configs).
        /// </summary>
        /// <param name="url">Url for request.</param>
        /// <returns>Current client.</returns>
        IHttpTestClient SetUrlPath(string url);
        
        /// <summary>
        /// Set body for request.
        /// </summary>
        /// <param name="body">Body for request.</param>
        /// <returns>Current client.</returns>
        IHttpTestClient SetBody(string body);

        /// <summary>
        /// Set http method for request.
        /// </summary>
        /// <param name="method">Http method.</param>
        /// <returns>Current client.</returns>
        IHttpTestClient SetMethod(HttpMethod method);
        
        /// <summary>
        /// Execute request and get result.
        /// </summary>
        /// <returns>Request result as Json.</returns>
        Task<JContainer> SendAndReadAsync();
        
        /// <summary>
        /// Execute request without result. 
        /// </summary>
        Task SendAsync();
    }
}