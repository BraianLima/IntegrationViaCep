using IntegrationViaCep.Core.Domain.Models.Outputs;
using IntegrationViaCep.Core.Domain.Responses;
using IntegrationViaCep.Core.Domain.Utils.Interfaces;

namespace IntegrationViaCep.Test.Tests
{
    public class ObjectFactoriesTest : Startup
    {

        private readonly IObjectFactories? _objectFactories;

        /// <summary>
        /// Initialize services to use.
        /// </summary>
        public ObjectFactoriesTest()
        {
            //get service by ServiceProvider
            _objectFactories = _serviceProvider.GetService<IObjectFactories>();
        }

        /// <summary>
        /// Unit test about ReturnResponseToService of IObjectFactories
        /// </summary>
        [Fact]
        public void ReturnResponseToService()
        {
            Assert.NotNull(_objectFactories); //check if service is null

            bool success = true; //param to return StatusCode.OK by ReturnResponseToService
            object data = new { 
                name = "Braian", 
                linkedin = "https://www.linkedin.com/in/braian-freitas-de-lima-8968a2115/" 
            }; //generic object to send data to method ReturnResponseToService

            //call ReturnResponseToService to receive object Response
            Response? response = _objectFactories?.ReturnResponseToService(success, data);

            //check if variable valid is true and not null
            Assert.NotNull(response);

            //should return StatusCode.OK
            Assert.True(response?.StatusCode == System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// Unit test about NewCep of IObjectFactories
        /// </summary>
        [Fact]
        public void NewCep()
        {
            Assert.NotNull(_objectFactories); //check if service is null

            Cep? cep = _objectFactories?.NewCep("error"); //instance Cep with error

            //check if cep is not null
            Assert.NotNull(cep);

            //check if cep.IsValid is false
            Assert.False(cep?.IsValid);
        }

        /// <summary>
        /// Unit test about NewListCep of IObjectFactories
        /// </summary>
        [Fact]
        public void NewListCep()
        {
            Assert.NotNull(_objectFactories); //check if service is null

            List<Cep>? listCep = _objectFactories?.NewListCep(); //instance List<Cep>() without errors

            Assert.NotNull(listCep); //check if list is not null
            Assert.True(listCep?.Count == 0); //check if list have 0 items
        }
    }
}
