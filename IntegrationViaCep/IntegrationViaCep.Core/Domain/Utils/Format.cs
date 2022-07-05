using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Utils.Interfaces;

namespace IntegrationViaCep.Core.Domain.Utils
{
    public class Format : IFormat
    {
        public string FormatCepCodeToRequest(string cepCode)
        {
            return $"ws/{FormatCepCode(cepCode)}/json";
        }

        public string FormatPathSearchPostalCodeToRequest(SearchPostalCode searchPostalCode)
        {
            return $"ws/{searchPostalCode.State}/{searchPostalCode.County}/{searchPostalCode.PublicPlace}/json";
        }

        private string FormatCepCode(string cepCode)
        {
            cepCode = cepCode.Replace(" ", "");
            return GetNumbers(cepCode);
        }

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
