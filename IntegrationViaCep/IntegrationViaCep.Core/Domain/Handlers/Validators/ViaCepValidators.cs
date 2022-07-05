using IntegrationViaCep.Core.Domain.Global;
using IntegrationViaCep.Core.Domain.Handlers.Validators.Interfaces;
using IntegrationViaCep.Core.Domain.Models.Inputs;

namespace IntegrationViaCep.Core.Domain.Handlers.Validators
{
    public class ViaCepValidators : BaseValidators, IViaCepValidators
    {
        public bool PostalCodeIsValid(PostalCode postalCode)
        {
            if (IsNull(postalCode))
                return false;

            if (IsNullOrEmpty(postalCode.CepCode))
                return false;

            if (postalCode.CepCode.Any(x => char.IsLetter(x)))
                return false;

            if (postalCode.CepCode.Count(x => char.IsNumber(x)) != GlobalVariables.COUNT_NUMBERS_POSTAL_CODE)
                return false;

            return true;
        }

        public bool SearchPostalCodeIsValid(SearchPostalCode searchPostalCode)
        {
            if (IsNull(searchPostalCode))
                return false;

            if (searchPostalCode.State.Length != GlobalVariables.COUNT_CHARACTERS_STATE)
                return false;

            return true;
        }
    }
}
