using IntegrationViaCep.Core.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationViaCep.API.Controllers
{
    public class BaseController : Controller
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ReturnActionResult(Response response)
        {
            return StatusCode((int)response.StatusCode, response);
        }

    }
}
