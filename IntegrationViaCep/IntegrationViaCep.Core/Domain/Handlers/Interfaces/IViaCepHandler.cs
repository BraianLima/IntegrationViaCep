using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Responses;

namespace IntegrationViaCep.Core.Domain.Handlers.Interfaces
{
    public interface IViaCepHandler
    {
        /// <summary>
        /// returns the CEP object inside the response object.
        /// </summary>
        /// <param name="postalCode">Object containing CEP code.</param>
        /// <returns></returns>
        Task<Response> GetPostalCodeAsync(PostalCode postalCode);

        /// <summary>
        /// Does the research, the research is done by making a request on ViaCep.
        /// </summary>
        /// <param name="searchPostalCode">SearchPostalCode object.</param>
        /// <returns></returns>
        Task<Response> PostSearchPostalCodeAsync(SearchPostalCode searchPostalCode);

    }
}
