using IntegrationViaCep.Core.Domain.Global;
using IntegrationViaCep.Core.Domain.Handlers.Interfaces;
using IntegrationViaCep.Core.Domain.Handlers.Validators.Interfaces;
using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Models.Outputs;
using IntegrationViaCep.Core.Domain.Responses;
using IntegrationViaCep.Core.Domain.Utils.Interfaces;
using IntegrationViaCep.Core.Services.Interfaces;

namespace IntegrationViaCep.Core.Domain.Handlers
{
    public class ViaCepHandler : IViaCepHandler
    {
        private readonly IServiceViaCep _serviceViaCep;
        private readonly IObjectFactories _objectFactories;
        private readonly IViaCepValidators _viaCepValidators;
        private readonly IFormat _format;

        public ViaCepHandler(IServiceViaCep serviceViaCep,
            IObjectFactories objectFactories,
            IViaCepValidators viaCepValidators,
            IFormat format)
        {
            _serviceViaCep = serviceViaCep;
            _objectFactories = objectFactories;
            _viaCepValidators = viaCepValidators;
            _format = format;
        }

        public async Task<Response> GetPostalCodeAsync(PostalCode postalCode)
        {
            bool isValid = _viaCepValidators.PostalCodeIsValid(postalCode);
            if (isValid)
            {
                HttpClient httpClient = await _serviceViaCep
                    .InitializeHttpClientAsync(GlobalVariables.BASE_ADDRESS_VIA_CEP);

                string apiResponse = await _serviceViaCep
                    .RequestViaCepAsync(httpClient, _format.FormatCepCodeToRequest(postalCode.CepCode));

                Cep cep = await _serviceViaCep.JsonDeserializeToCepAsync(apiResponse);

                return _objectFactories.ReturnResponseToService(cep.IsValid, cep);
            }

            return _objectFactories
                .ReturnResponseToService(isValid, _objectFactories.NewCep(Messages.ERROR_GET_CEP));
        }

        public async Task<Response> PostSearchPostalCodeAsync(SearchPostalCode searchPostalCode)
        {
            bool isValid = _viaCepValidators.SearchPostalCodeIsValid(searchPostalCode);
            if (isValid)
            {
                HttpClient httpClient = await _serviceViaCep
                    .InitializeHttpClientAsync(GlobalVariables.BASE_ADDRESS_VIA_CEP);

                string apiResponse = await _serviceViaCep
                    .RequestViaCepAsync(httpClient, _format.FormatPathSearchPostalCodeToRequest(searchPostalCode));

                List<Cep> listCep = await _serviceViaCep.JsonDeserializeToListCepAsync(apiResponse);

                return _objectFactories.ReturnResponseToService(listCep.Count > 0, listCep);
            }

            return _objectFactories
                .ReturnResponseToService(isValid, _objectFactories.NewListCep());
        }

    }
}
