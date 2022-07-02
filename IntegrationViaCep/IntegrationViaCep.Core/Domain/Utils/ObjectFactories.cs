using IntegrationViaCep.Core.Domain.Global;
using IntegrationViaCep.Core.Domain.Models.Results;
using IntegrationViaCep.Core.Domain.Responses;
using IntegrationViaCep.Core.Domain.Utils.Interfaces;
using System.Net;

namespace IntegrationViaCep.Core.Domain.Utils
{
    public class ObjectFactories : IObjectFactories
    {
        public Response ReturnResponseToService(bool success, object data)
        {
            if (success)
                return NewResponse(HttpStatusCode.OK, Messages.SUCCESS, data);

            return NewResponse(HttpStatusCode.BadRequest, Messages.FAILURE, data);
        }

        private Response NewResponse(HttpStatusCode httpStatusCode, string message, object data)
        {
            return new Response
            {
                StatusCode = httpStatusCode,
                Data = data,
                Message = message
            };
        }
        
        public Cep NewCep()
        {
            return new Cep()
            {
                Error = "Couldn't get cep"
            };
        }
    }
}
