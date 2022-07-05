using IntegrationViaCep.Core.Domain.Models.Outputs;

namespace IntegrationViaCep.Core.Services.Interfaces
{
    public interface IServiceViaCep
    {
        Task<HttpClient> InitializeHttpClientAsync(string baseAddress);
        Task<Cep> JsonDeserializeToCepAsync(string json);
        Task<List<Cep>> JsonDeserializeToListCepAsync(string json);
        Task<string> RequestViaCepAsync(HttpClient httpClient, string path);
    }
}
