using System.ComponentModel.DataAnnotations;

namespace IntegrationViaCep.Core.Domain.Models.Inputs
{
    public class SearchPostalCode
    {
        [Required]
        public string State { get; set; } = string.Empty;

        [Required]
        public string County { get; set; } = string.Empty;

        [Required]
        public string PublicPlace { get; set; } = string.Empty;

    }
}
