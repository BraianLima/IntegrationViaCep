using System.ComponentModel.DataAnnotations;

namespace IntegrationViaCep.Core.Domain.Models.Inputs
{
    public class PostalCode
    {
        [Required]
        public string ZipCode { get; set; } = string.Empty;
    }
}
