using IntegrationViaCep.Core.Domain.Global;
using IntegrationViaCep.Core.Domain.Models.Outputs;
using IntegrationViaCep.Core.Domain.Responses;
using IntegrationViaCep.Core.Domain.Utils.Interfaces;
using System.Net;

namespace IntegrationViaCep.Core.Domain.Utils
{
    /// <summary>
    /// An object factory class was created in order to centralize object creations.
    /// </summary>
    public class ObjectFactories : IObjectFactories
    {
        /// <summary>
        /// Instance the object Response to return to Service.
        /// </summary>
        /// <param name="success">If true Response.StatusCode.OK, if false  Response.StatusCode.BadRequest.</param>
        /// <param name="data">Any kind of object.</param>
        /// <returns></returns>
        public Response ReturnResponseToService(bool success, object data)
        {
            if (success)
                return NewResponse(HttpStatusCode.OK, Messages.SUCCESS, data);

            return NewResponse(HttpStatusCode.BadRequest, Messages.FAILURE, null);
        }

        /// <summary>
        /// Instance the object Response.
        /// </summary>
        /// <param name="httpStatusCode">Status code defined for HTTP.</param>
        /// <param name="message">Message of return.</param>
        /// <param name="data">Any kind of object.</param>
        /// <returns></returns>
        private Response NewResponse(HttpStatusCode httpStatusCode, string message, object? data)
        {
            return new Response
            {
                StatusCode = httpStatusCode,
                Data = data,
                Message = message
            };
        }
        
        /// <summary>
        /// Instance the object CEP with error.
        /// </summary>
        /// <param name="error">Text error to CEP.</param>
        /// <returns></returns>
        public Cep NewCep(string error)
        {
            return new Cep()
            {
                Error = error
            };
        }

        /// <summary>
        /// Instance the List<Cep>.
        /// </summary>
        /// <returns></returns>
        public List<Cep> NewListCep()
        {
            return new List<Cep>();
        }
    }
}
