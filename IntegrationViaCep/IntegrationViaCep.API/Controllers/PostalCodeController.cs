using IntegrationViaCep.API.Controllers;
using IntegrationViaCep.Core.Application.Interfaces;
using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using System.Net.Mime;

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
        [Produces("application/json")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponsePresentationCep), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponsePresentationCep), (int)HttpStatusCode.BadRequest)]        
        public async Task<IActionResult> GetPostalCodeAsync([BindRequired][FromQuery] string cepCode)
        {
            return ReturnActionResult(await _service.GetPostalCodeAsync(new PostalCode { CepCode = cepCode }));
        }

        [HttpPost("PostSearchPostalCode")]
        [Produces("application/json")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponsePresentationSearchPostalCode), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponsePresentationSearchPostalCode), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostSearchPostalCode([FromBody] SearchPostalCode searchPostalCode)
        {
            return ReturnActionResult(await _service.PostSearchPostalCodeAsync(searchPostalCode));
        }
    }
}