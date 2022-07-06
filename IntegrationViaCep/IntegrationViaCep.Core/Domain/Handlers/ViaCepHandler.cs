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

        /// <summary>
        /// returns the CEP object inside the response object.
        /// </summary>
        /// <param name="postalCode">Object containing CEP code.</param>
        /// <returns></returns>
        public async Task<Response> GetPostalCodeAsync(PostalCode postalCode)
        {
            //validate the PostalCode
            bool isValid = _viaCepValidators.PostalCodeIsValid(postalCode); 

            if (isValid)
            {
                //initialize HttpClient to perform the request, using the ViaCep base address
                HttpClient httpClient = await _serviceViaCep
                    .InitializeHttpClientAsync(GlobalVariables.BASE_ADDRESS_VIA_CEP);

                //mount the endpoint
                string endpoint = _format.MountEndpointToRequestAddressUsingCepCode(postalCode.CepCode); 

                //perform the request
                string apiResponse = await _serviceViaCep.RequestViaCepAsync(httpClient, endpoint);

                //deserialize json to CEP object
                Cep cep = await _serviceViaCep.JsonDeserializeToCepAsync(apiResponse);

                //instance CEP object and return
                return _objectFactories.ReturnResponseToService(cep.IsValid, cep);
            }

            //instance CEP object with error and return
            return _objectFactories
                .ReturnResponseToService(isValid, _objectFactories.NewCep(Messages.ERROR_GET_CEP));
        }

        /// <summary>
        /// Does the research, the research is done by making a request on ViaCep.
        /// </summary>
        /// <param name="searchPostalCode">SearchPostalCode object.</param>
        /// <returns></returns>
        public async Task<Response> PostSearchPostalCodeAsync(SearchPostalCode searchPostalCode)
        {
            //validate the SearchPostalCode
            bool isValid = _viaCepValidators.SearchPostalCodeIsValid(searchPostalCode);

            if (isValid)
            {
                //initialize HttpClient to perform the request, using the ViaCep base address
                HttpClient httpClient = await _serviceViaCep
                    .InitializeHttpClientAsync(GlobalVariables.BASE_ADDRESS_VIA_CEP);

                //mount the endpoint
                string endpoint = _format.MountEndpointToRequestAddressesUsingSearchPostalCode(searchPostalCode);

                //perform the request
                string apiResponse = await _serviceViaCep.RequestViaCepAsync(httpClient, endpoint);

                //deserialize json to List<Cep> object
                List<Cep> listCep = await _serviceViaCep.JsonDeserializeToListCepAsync(apiResponse);

                //instance List<Cep> object and return
                return _objectFactories.ReturnResponseToService(listCep.Count > 0, listCep);
            }

            //instance List<Cep> object with error and return
            return _objectFactories.ReturnResponseToService(isValid, _objectFactories.NewListCep());
        }

    }
}
