using IntegrationViaCep.Core.Domain.Models.Outputs;

namespace IntegrationViaCep.Core.Services.Interfaces
{
    public interface IServiceViaCep
    {
        /// <summary>
        /// This method initializes a HttpClient, if the HttpClient doesn't exists, 
        /// a new one is instantiated.
        /// </summary>
        /// <param name="baseAddress">Base URL for queries.</param>
        /// <returns></returns>
        Task<HttpClient> InitializeHttpClientAsync(string baseAddress);

        /// <summary>
        /// Deserialize JSON string to object CEP, it is asynchronous method because 
        /// it is not possible to know the size of the JSON;
        /// </summary>
        /// <param name="json">Return JSON of request https://viacep.com.br/ws/00000000/json</param>
        /// <returns></returns>
        Task<Cep> JsonDeserializeToCepAsync(string json);

        /// <summary>
        /// Deserialize JSON string to list objects CEP, it is asynchronous method because 
        /// it is not possible to know the size of the JSON;
        /// </summary>
        /// <param name="json">Return JSON of request https://viacep.com.br/ws/xx/xxxxx/xxxxxxx+xxxxxx/json</param>
        /// <returns></returns>
        Task<List<Cep>> JsonDeserializeToListCepAsync(string json);

        /// <summary>
        /// Make the request in the ViaCep system
        /// </summary>
        /// <param name="httpClient">HttpClient already initialized</param>
        /// <param name="endpoint">Endpoint of query.</param>
        /// <returns></returns>
        Task<string> RequestViaCepAsync(HttpClient httpClient, string endpoint);
    }
}
