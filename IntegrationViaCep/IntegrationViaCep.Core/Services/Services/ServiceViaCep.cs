using IntegrationViaCep.Core.Domain.Models.Results;
using IntegrationViaCep.Core.Domain.Utils.Interfaces;
using IntegrationViaCep.Core.Services.Interfaces;
using Newtonsoft.Json;

namespace IntegrationViaCep.Core.Services.Services
{
    public class ServiceViaCep : IServiceViaCep 
    {
        private static HttpClient? httpClient;

        private readonly IObjectFactories _objectFactories;
        public ServiceViaCep(IObjectFactories objectFactories)
        {
            _objectFactories = objectFactories;
        }

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

        public async Task<Cep> JsonDeserializeToCep(string json)
        {
            return await Task.Run(() =>
            {
                try
                {
                    Cep? cep = JsonConvert.DeserializeObject<Cep>(json);
                    if (cep == null)
                        return _objectFactories.NewCep();

                    return cep;
                }catch (Exception)
                {
                    return _objectFactories.NewCep();
                }
            });
        }
        
        public async Task<string> RequestViaCep(HttpClient httpClient, string path)
        {
            HttpResponseMessage response = await httpClient.GetAsync(path);
            return await response.Content.ReadAsStringAsync();
        }

    }
}
