using Newtonsoft.Json;

namespace IntegrationViaCep.Core.Domain.Models.Outputs
{
    public class Cep
    {
        [JsonProperty("cep", Required = Required.Default)]
        public string? PostalCode { get; set; }

        [JsonProperty("logradouro", Required = Required.Default)]
        public string? PublicPlace { get; set; }

        [JsonProperty("complemento", Required = Required.Default)]
        public string? Complement { get; set; }

        [JsonProperty("bairro", Required = Required.Default)]
        public string? District { get; set; }

        [JsonProperty("localidade", Required = Required.Default)]
        public string? County { get; set; }

        [JsonProperty("uf", Required = Required.Default)]
        public string? State { get; set; }

        [JsonProperty("ibge", Required = Required.Default)]
        public string? Ibge { get; set; }

        [JsonProperty("gia", Required = Required.Default)]
        public string? Gia { get; set; }

        [JsonProperty("ddd", Required = Required.Default)]
        public string? Ddd { get; set; }

        [JsonProperty("siafi", Required = Required.Default)]
        public string? Siafi { get; set; }

        [JsonProperty("erro", Required = Required.Default)]
        public string? Error { get; set; }

        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                return string.IsNullOrEmpty(Error);
            }
        }
    }
}
