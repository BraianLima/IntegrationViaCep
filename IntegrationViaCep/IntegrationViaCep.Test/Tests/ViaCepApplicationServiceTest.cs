using IntegrationViaCep.Core.Application.Interfaces;
using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Responses;

namespace IntegrationViaCep.Test.Tests
{
    public class ViaCepApplicationServiceTest : Startup
    {
        private readonly IViaCepApplicationService? _viaCepApplicationService;

        /// <summary>
        /// Initialize services to use.
        /// </summary>
        public ViaCepApplicationServiceTest()
        {
            //get service by ServiceProvider
            _viaCepApplicationService = _serviceProvider.GetService<IViaCepApplicationService>();
        }

        /// <summary>
        /// Unit test about GetPostalCode of IViaCepApplicationService
        /// </summary>
        [Fact]
        public void GetPostalCode()
        {
            Assert.NotNull(_viaCepApplicationService); //check if service is null

            Task<Response>? task = _viaCepApplicationService?
                .GetPostalCodeAsync(new PostalCode { CepCode = "83010900" }); //performs the request 
            Assert.NotNull(task);

            Response? response = task?.Result;

            //check the results
            Assert.NotNull(response);

            //should return StatusCode.OK
            Assert.True(response?.StatusCode == System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// Unit test about PostSearchPostalCode of IViaCepApplicationService
        /// </summary>
        [Fact]
        public void PostSearchPostalCode()
        {
            Assert.NotNull(_viaCepApplicationService); //check if service is null

            Task<Response>? task = _viaCepApplicationService?
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