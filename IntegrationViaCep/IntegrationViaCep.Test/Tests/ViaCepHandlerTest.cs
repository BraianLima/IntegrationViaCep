using IntegrationViaCep.Core.Domain.Handlers.Interfaces;
using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Responses;

namespace IntegrationViaCep.Test.Tests
{
    public class ViaCepHandlerTest : Startup
    {
        private readonly IViaCepHandler? _viaCepHandler;

        /// <summary>
        /// Initialize services to use.
        /// </summary>
        public ViaCepHandlerTest()
        {
            //get service by ServiceProvider
            _viaCepHandler = _serviceProvider.GetService<IViaCepHandler>();
        }

        /// <summary>
        /// Unit test about GetPostalCode of IViaCepHandler
        /// </summary>
        [Fact]
        public void GetPostalCode()
        {
            Assert.NotNull(_viaCepHandler); //check if service is null

            Task<Response>? task = _viaCepHandler?
                .GetPostalCodeAsync(new PostalCode { CepCode = "83010900" }); //performs the request 
            Assert.NotNull(task);

            Response? response = task?.Result;

            //check the results
            Assert.NotNull(response);

            //should return StatusCode.OK
            Assert.True(response?.StatusCode == System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// Unit test about PostSearchPostalCode of IViaCepHandler
        /// </summary>
        [Fact]
        public void PostSearchPostalCode()
        {
            Assert.NotNull(_viaCepHandler); //check if service is null

            Task<Response>? task = _viaCepHandler?
                .PostSearchPostalCodeAsync(new SearchPostalCode
                {
                    State = "RS",
                    County = "Porto Alegre",
                    PublicPlace = "Domingos"
                }); //performs the request 
            Assert.NotNull(task);

            Response? response = task?.Result;

            //check the results
            Assert.NotNull(response);

            //should return StatusCode.OK
            Assert.True(response?.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
