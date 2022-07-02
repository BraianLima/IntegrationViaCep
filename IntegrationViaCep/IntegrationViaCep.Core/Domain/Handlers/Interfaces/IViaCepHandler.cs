using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Responses;

namespace IntegrationViaCep.Core.Domain.Handlers.Interfaces
{
    public interface IViaCepHandler
    {
        Task<Response> GetPostalCodeAsync(PostalCode postalCode);

    }
}
