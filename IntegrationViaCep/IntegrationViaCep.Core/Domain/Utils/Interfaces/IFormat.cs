using IntegrationViaCep.Core.Domain.Models.Inputs;

namespace IntegrationViaCep.Core.Domain.Utils.Interfaces
{
    public interface IFormat
    {
        string FormatCepCodeToRequest(string cepCode);
        string FormatPathSearchPostalCodeToRequest(SearchPostalCode searchPostalCode);
    }
}
