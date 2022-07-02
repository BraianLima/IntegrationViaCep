using IntegrationViaCep.API.Controllers;
using IntegrationViaCep.Core.Application.Interfaces;
using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationViaCep.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostalCodeController : BaseController
    {
        private readonly IViaCepApplicationService _service;
        public PostalCodeController(IViaCepApplicationService service)
        {
            _service = service;
        }

        [HttpGet("GetPostalCode")]
        public async Task<IActionResult> GetPostalCodeAsync(string zipCode)
        {
            Response response = await _service.GetPostalCodeAsync(new PostalCode{ZipCode = zipCode});
            return ReturnActionResult(response);
        }
    }
}