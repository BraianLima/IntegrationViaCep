using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Responses;

namespace IntegrationViaCep.Core.Application.Interfaces
{
    public interface IViaCepApplicationService
    {
        /// <summary>
        /// Call GetPostalCodeAsync and return results of request in ViaCep.
        /// </summary>
        /// <param name="postalCode">PostalCode object containing CEP code.</param>
        /// <returns></returns>
        Task<Response> GetPostalCodeAsync(PostalCode postalCode);

        /// <summary>
        /// Call PostSearchPostalCodeAsync and return search results of request in ViaCep.
        /// </summary>
        /// <param name="searchPostalCode">SearchPostalCode object containing 
        /// State, County and partial public place to search.</param>
        /// <returns></returns>
        Task<Response> PostSearchPostalCodeAsync(SearchPostalCode searchPostalCode);
    }
}
