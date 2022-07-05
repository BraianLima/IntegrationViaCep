using IntegrationViaCep.Core.Domain.Models.Inputs;

namespace IntegrationViaCep.Core.Domain.Handlers.Validators.Interfaces
{
    public interface IViaCepValidators
    {
        bool PostalCodeIsValid(PostalCode postalCode);
        bool SearchPostalCodeIsValid(SearchPostalCode searchPostalCode);

    }
}
