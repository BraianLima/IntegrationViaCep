using IntegrationViaCep.Core.Domain.Models.Inputs;

namespace IntegrationViaCep.Core.Domain.Utils.Interfaces
{
    public interface IFormat
    {
        /// <summary>
        /// Mount the endpoint to Request Address in ViaCep.
        /// </summary>
        /// <param name="cepCode">Address CEP code.</param>
        /// <returns></returns>
        string MountEndpointToRequestAddressUsingCepCode(string cepCode);

        /// <summary>
        /// Mount the endpoint to Request Addresses in ViaCep using state, county name and partial public place.
        /// </summary>
        /// <param name="searchPostalCode">Object containing state, county and partial public place to search</param>
        /// <returns></returns>
        string MountEndpointToRequestAddressesUsingSearchPostalCode(SearchPostalCode searchPostalCode);
    }
}
