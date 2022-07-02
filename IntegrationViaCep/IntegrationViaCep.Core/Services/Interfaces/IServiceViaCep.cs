using IntegrationViaCep.Core.Domain.Models.Results;

namespace IntegrationViaCep.Core.Services.Interfaces
{
    public interface IServiceViaCep
    {
        Task<HttpClient> InitializeHttpClientAsync(string baseAddress);
        Task<Cep> JsonDeserializeToCep(string json);
        Task<string> RequestViaCep(HttpClient httpClient, string path);
    }
}
