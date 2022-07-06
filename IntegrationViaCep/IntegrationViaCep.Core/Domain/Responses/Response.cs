using System.Net;

namespace IntegrationViaCep.Core.Domain.Responses
{
    /// <summary>
    /// Standard object of return to Controller
    /// </summary>
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
