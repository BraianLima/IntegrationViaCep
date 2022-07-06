using IntegrationViaCep.Core.Domain.Global;
using IntegrationViaCep.Core.Domain.Models.Outputs;
using IntegrationViaCep.Core.Domain.Utils.Interfaces;
using IntegrationViaCep.Core.Services.Interfaces;
using Newtonsoft.Json;

namespace IntegrationViaCep.Core.Services.Services
{
    public class ServiceViaCep : IServiceViaCep 
    {
        /// <summary>
        /// Only this HttpClient is use this API
        /// </summary>
        private static HttpClient? httpClient;

        private readonly IObjectFactories _objectFactories;
        public ServiceViaCep(IObjectFactories objectFactories)
        {
            _objectFactories = objectFactories;
        }

        /// <summary>
        /// This method initializes a HttpClient, if the HttpClient doesn't exists, 
        /// a new one is instantiated.
        /// </summary>
        /// <param name="baseAddress">Base URL for queries.</param>
        /// <returns></returns>
        public async Task<HttpClient> InitializeHttpClientAsync(string baseAddress)
        {
            return await Task.Run(() =>
            {
                if (httpClient == null)
                {
                    httpClient = new HttpClient
                    {
                        BaseAddress = new Uri(baseAddress)
                    };
                }

                return Task.FromResult(httpClient);
            });
        }

        /// <summary>
        /// Deserialize JSON string to object CEP, it is asynchronous method because 
        /// it is not possible to know the size of the JSON;
        /// </summary>
        /// <param name="json">Return JSON of request https://viacep.com.br/ws/00000000/json</param>
        /// <returns></returns>
        public async Task<Cep> JsonDeserializeToCepAsync(string json)
        {
            return await Task.Run(() =>
            {
                try
                {
                    Cep? cep = JsonConvert.DeserializeObject<Cep>(json);
                    if (cep == null)
                        return _objectFactories.NewCep(Messages.ERROR_GET_CEP); //return Cep object with error

                    return cep;
                }catch (Exception)
                {
                    return _objectFactories.NewCep(Messages.ERROR_GET_CEP); //return Cep object with error
                }
            });
        }

        /// <summary>
        /// Deserialize JSON string to list objects CEP, it is asynchronous method because 
        /// it is not possible to know the size of the JSON;
        /// </summary>
        /// <param name="json">Return JSON of request https://viacep.com.br/ws/xx/xxxxx/xxxxxxx+xxxxxx/json</param>
        /// <returns></returns>
        public async Task<List<Cep>> JsonDeserializeToListCepAsync(string json)
        {
            return await Task.Run(() =>
            {
                try
                {
                    List<Cep>? listCep = JsonConvert.DeserializeObject<List<Cep>>(json);

                    if (listCep == null)
                        return _objectFactories.NewListCep(); //return List<Cep> object with error

                    return listCep;
                }
                catch (Exception)
                {
                    return _objectFactories.NewListCep(); //return List<Cep> object with error
                }
            });
        }

        /// <summary>
        /// Make the request in the ViaCep system
        /// </summary>
        /// <param name="httpClient">HttpClient already initialized</param>
        /// <param name="endpoint">Endpoint of query.</param>
        /// <returns></returns>
        public async Task<string> RequestViaCepAsync(HttpClient httpClient, string endpoint)
        {
            HttpResponseMessage response = await httpClient.GetAsync(endpoint); //performs the request
            return await response.Content.ReadAsStringAsync(); //return a JSON string
        }

    }
}
