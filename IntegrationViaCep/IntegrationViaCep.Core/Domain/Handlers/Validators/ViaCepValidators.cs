using IntegrationViaCep.Core.Domain.Global;
using IntegrationViaCep.Core.Domain.Handlers.Validators.Interfaces;
using IntegrationViaCep.Core.Domain.Models.Inputs;

namespace IntegrationViaCep.Core.Domain.Handlers.Validators
{
    public class ViaCepValidators : BaseValidators, IViaCepValidators
    {
        /// <summary>
        /// Check if postal code is null and CEP code is valid.
        /// </summary>
        /// <param name="postalCode">Object containing CEP code.</param>
        /// <returns></returns>
        public bool PostalCodeIsValid(PostalCode postalCode)
        {
            //Call method IsNull(string) inside abstract class
            if (IsNull(postalCode))
                return false;

            //Call method IsNullOrEmpty(string) inside abstract class
            if (IsNullOrEmpty(postalCode.CepCode))
                return false;

            //Check if string CepCode contain any letter
            if (postalCode.CepCode.Any(x => char.IsLetter(x)))
                return false;

            //check if string CepCode contain 8 numbers, right amount of characters
            if (postalCode.CepCode.Count(x => char.IsNumber(x)) != GlobalVariables.COUNT_NUMBERS_CEP_CODE)
                return false;

            return true;
        }

        /// <summary>
        /// Check if SearchPostalCode is null and State is valid.
        /// </summary>
        /// <param name="searchPostalCode">SearchPostalCode object.</param>
        /// <returns></returns>
        public bool SearchPostalCodeIsValid(SearchPostalCode searchPostalCode)
        {
            //Call method IsNull(string) inside abstract class
            if (IsNull(searchPostalCode))
                return false;

            //check if string State contain 2 chacarters, right amount of characters
            if (searchPostalCode.State.Length != GlobalVariables.COUNT_CHARACTERS_STATE)
                return false;

            return true;
        }
    }
}
