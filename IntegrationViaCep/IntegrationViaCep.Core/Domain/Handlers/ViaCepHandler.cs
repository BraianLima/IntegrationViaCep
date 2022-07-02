using IntegrationViaCep.Core.Domain.Global;
using IntegrationViaCep.Core.Domain.Handlers.Interfaces;
using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Models.Results;
using IntegrationViaCep.Core.Domain.Responses;
using IntegrationViaCep.Core.Domain.Utils.Interfaces;
using IntegrationViaCep.Core.Services.Interfaces;

namespace IntegrationViaCep.Core.Domain.Handlers
{
    public class ViaCepHandler : IViaCepHandler
    {
        private readonly IServiceViaCep _serviceViaCep;
        private readonly IObjectFactories _objectFactories;

        public ViaCepHandler(IServiceViaCep serviceViaCep,
            IObjectFactories objectFactories)
        {
            _serviceViaCep = serviceViaCep;
            _objectFactories = objectFactories;
        }

        public async Task<Response> GetPostalCodeAsync(PostalCode postalCode)
        {
            HttpClient httpClient = await _serviceViaCep
                .InitializeHttpClientAsync(GlobalVariables.BASE_ADDRESS_VIA_CEP);

            string apiResponse = await _serviceViaCep
                .RequestViaCep(httpClient, $"ws/{postalCode.ZipCode}/json");

            Cep cep = await _serviceViaCep.JsonDeserializeToCep(apiResponse);

            return _objectFactories.ReturnResponseToService(cep.IsValid, cep);
        }
    }
}
