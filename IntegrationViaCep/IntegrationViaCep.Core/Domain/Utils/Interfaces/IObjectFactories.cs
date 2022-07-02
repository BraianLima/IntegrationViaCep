using IntegrationViaCep.Core.Domain.Models.Outputs;
using IntegrationViaCep.Core.Domain.Responses;

namespace IntegrationViaCep.Core.Domain.Utils.Interfaces
{
    public interface IObjectFactories
    {
        Response ReturnResponseToService(bool success, object data);
        Cep NewCep(string error);
    }
}
