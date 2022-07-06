using IntegrationViaCep.Core.Domain.Models.Outputs;
using IntegrationViaCep.Core.Domain.Responses;

namespace IntegrationViaCep.Core.Domain.Utils.Interfaces
{
    /// <summary>
    /// An object factory interface was created in order to centralize object creations.
    /// </summary>
    public interface IObjectFactories
    {
        /// <summary>
        /// Instance the object Response to return to Service.
        /// </summary>
        /// <param name="success">If true Response.StatusCode.OK, if false  Response.StatusCode.BadRequest.</param>
        /// <param name="data">Any kind of object.</param>
        /// <returns></returns>
        Response ReturnResponseToService(bool success, object data);

        /// <summary>
        /// Instance the object CEP with error.
        /// </summary>
        /// <param name="error">Text error to CEP.</param>
        /// <returns></returns>
        Cep NewCep(string error);

        /// <summary>
        /// Instance the List<Cep>.
        /// </summary>
        /// <returns></returns>
        List<Cep> NewListCep();
    }
}
