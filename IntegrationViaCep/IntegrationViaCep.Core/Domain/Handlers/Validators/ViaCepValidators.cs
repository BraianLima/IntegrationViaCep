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

            if (IsNullOrEmpty(postalCode.ZipCode))
                return false;

            if (postalCode.ZipCode.Any(x => char.IsLetter(x)))
                return false;

            if (postalCode.ZipCode.Count(x => char.IsNumber(x)) != GlobalVariables.COUNT_NUMBERS_POSTAL_CODE)
                return false;

            return true;
        }
    }
}
