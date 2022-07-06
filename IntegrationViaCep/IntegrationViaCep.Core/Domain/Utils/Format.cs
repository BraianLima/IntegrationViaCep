using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Utils.Interfaces;

namespace IntegrationViaCep.Core.Domain.Utils
{
    public class Format : IFormat
    {
        /// <summary>
        /// Mount the endpoint to Request Address in ViaCep.
        /// </summary>
        /// <param name="cepCode">Address CEP code.</param>
        /// <returns></returns>
        public string MountEndpointToRequestAddressUsingCepCode(string cepCode)
        {
            return $"ws/{FormatCepCode(cepCode)}/json";
        }

        /// <summary>
        /// Mount the endpoint to Request Addresses in ViaCep using state, county name and partial public place.
        /// </summary>
        /// <param name="searchPostalCode">Object containing state, county and partial public place to search</param>
        /// <returns></returns>
        public string MountEndpointToRequestAddressesUsingSearchPostalCode(SearchPostalCode searchPostalCode)
        {
            return $"ws/{searchPostalCode.State}/{searchPostalCode.County}/{searchPostalCode.PublicPlace}/json";
        }

        /// <summary>
        /// Get only numbers of CEP and return.
        /// </summary>
        /// <param name="cepCode">String CEP code.</param>
        /// <returns></returns>
        private string FormatCepCode(string cepCode)
        {
            cepCode = cepCode.Replace(" ", "");
            return GetNumbers(cepCode);
        }

        /// <summary>
        /// Get only numbers of a string.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <returns></returns>
        private string GetNumbers(string value)
        {
            string tmp = string.Empty;

            if (!string.IsNullOrEmpty(value))
            {
                for (int i = 0; i < value.Length; i++)
                    if (char.IsDigit(value[i]))
                        tmp += value[i];
            }

            return tmp;
        }

    }
}
