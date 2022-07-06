using IntegrationViaCep.Core.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationViaCep.API.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Returns the result of the request.
        /// </summary>
        /// <param name="response">Object response</param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ReturnActionResult(Response response)
        {
            //Returns the HttpStatusCode and returns the response
            return StatusCode((int)response.StatusCode, response);
        }

    }
}
