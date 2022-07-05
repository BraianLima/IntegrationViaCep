using IntegrationViaCep.Core.Domain.Models.Outputs;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace IntegrationViaCep.Core.Domain.Responses
{
    public class ResponsePresentationSearchPostalCode
    {
        [Required]
        public HttpStatusCode StatusCode { get; set; }

        [Required]
        public string Message { get; set; } = string.Empty;

        [Required]
        public List<Cep> Data { get; set; } = new List<Cep>();
    }
}
