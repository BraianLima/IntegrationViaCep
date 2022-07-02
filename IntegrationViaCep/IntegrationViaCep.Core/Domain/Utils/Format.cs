using IntegrationViaCep.Core.Domain.Utils.Interfaces;

namespace IntegrationViaCep.Core.Domain.Utils
{
    public class Format : IFormat
    {
        public string FormatZipCode(string zipCode)
        {
            zipCode = zipCode.Replace(" ", "");
            return GetNumbers(zipCode);
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
