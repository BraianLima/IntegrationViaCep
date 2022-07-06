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

        /// <summary>
        /// Returns the address the Cep code.
        /// </summary>
        /// <param name="cepCode">Value of Cep code.</param>
        /// <returns></returns>
        [HttpGet("GetPostalCode")]
        [Produces("application/json")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponsePresentationCep), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponsePresentationCep), (int)HttpStatusCode.BadRequest)]        
        public async Task<IActionResult> GetPostalCodeAsync([BindRequired][FromQuery] string cepCode)
        {
            return ReturnActionResult(await _service.GetPostalCodeAsync(new PostalCode { CepCode = cepCode }));
        }

        /// <summary>
        /// Search perform, and returns the data addresses.
        /// </summary>
        /// <param name="searchPostalCode">SearchPostalCode object containing 
        /// State, County and partial public place to search.</param>
        /// <returns></returns>
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