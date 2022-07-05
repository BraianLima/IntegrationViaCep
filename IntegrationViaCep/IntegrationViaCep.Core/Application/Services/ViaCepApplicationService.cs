using IntegrationViaCep.Core.Application.Interfaces;
using IntegrationViaCep.Core.Domain.Handlers.Interfaces;
using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Responses;

namespace IntegrationViaCep.Core.Application.Services
{
    public class ViaCepApplicationService : IViaCepApplicationService
    {
        private readonly IViaCepHandler _viaCepHandler;

        public ViaCepApplicationService(IViaCepHandler viaCepHandler)
        {
            _viaCepHandler = viaCepHandler;
        }

        public async Task<Response> GetPostalCodeAsync(PostalCode postalCode)
        {
            return await _viaCepHandler.GetPostalCodeAsync(postalCode);
        }        

    }
}
