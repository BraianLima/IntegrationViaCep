using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Responses;

namespace IntegrationViaCep.Core.Application.Interfaces
{
    public interface IViaCepApplicationService
    {
        Task<Response> GetPostalCodeAsync(PostalCode postalCode);
    }
}
