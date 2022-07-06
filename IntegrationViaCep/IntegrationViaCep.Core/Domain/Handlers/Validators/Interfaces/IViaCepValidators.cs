using IntegrationViaCep.Core.Domain.Models.Inputs;

namespace IntegrationViaCep.Core.Domain.Handlers.Validators.Interfaces
{
    public interface IViaCepValidators
    {
        /// <summary>
        /// Check if postal code is null and CEP code is valid.
        /// </summary>
        /// <param name="postalCode">Object containing CEP code.</param>
        /// <returns></returns>
        bool PostalCodeIsValid(PostalCode postalCode);

        /// <summary>
        /// Check if SearchPostalCode is null and State is valid.
        /// </summary>
        /// <param name="searchPostalCode">SearchPostalCode object.</param>
        /// <returns></returns>
        bool SearchPostalCodeIsValid(SearchPostalCode searchPostalCode);

    }
}
