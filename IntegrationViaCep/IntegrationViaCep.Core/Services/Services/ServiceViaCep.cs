using IntegrationViaCep.Core.Domain.Global;
using IntegrationViaCep.Core.Domain.Models.Outputs;
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

        public async Task<Cep> JsonDeserializeToCepAsync(string json)
        {
            return await Task.Run(() =>
            {
                try
                {
                    Cep? cep = JsonConvert.DeserializeObject<Cep>(json);
                    if (cep == null)
                        return _objectFactories.NewCep(Messages.ERROR_GET_CEP);

                    return cep;
                }catch (Exception)
                {
                    return _objectFactories.NewCep(Messages.ERROR_GET_CEP);
                }
            });
        }

        public async Task<List<Cep>> JsonDeserializeToListCepAsync(string json)
        {
            return await Task.Run(() =>
            {
                try
                {
                    List<Cep>? listCep = JsonConvert.DeserializeObject<List<Cep>>(json);

                    if (listCep == null)
                        return _objectFactories.NewListCep();

                    return listCep;
                }
                catch (Exception)
                {
                    return _objectFactories.NewListCep();
                }
            });
        }

        public async Task<string> RequestViaCepAsync(HttpClient httpClient, string path)
        {
            HttpResponseMessage response = await httpClient.GetAsync(path);
            return await response.Content.ReadAsStringAsync();
        }

    }
}
