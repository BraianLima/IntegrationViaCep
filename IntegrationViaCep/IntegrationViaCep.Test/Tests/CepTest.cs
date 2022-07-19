using IntegrationViaCep.Core.Application.Interfaces;
using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationViaCep.Test.Tests
{
    public class CepTest : Startup
    {
        private readonly IViaCepApplicationService? _viaCepApplicationService;

        /// <summary>
        /// Initialize services to use.
        /// </summary>
        public CepTest()
        {
            _viaCepApplicationService = _serviceProvider.GetService<IViaCepApplicationService>();
        }

        /// <summary>
        /// Unit test about GetPostalCode of API
        /// </summary>
        [Fact]
        public void GetPostalCode()
        {
            Assert.NotNull(_viaCepApplicationService);

            Task<Response>? task = _viaCepApplicationService?
                .GetPostalCodeAsync(new PostalCode { CepCode = "83010900" }); //performs the request 
            Assert.NotNull(task);

            Response? response = task?.Result;

            //check the results
            Assert.NotNull(response);
            Assert.True(response?.StatusCode == System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// Unit test about PostSearchPostalCode of API
        /// </summary>
        [Fact]
        public void PostSearchPostalCode()
        {
            Assert.NotNull(_viaCepApplicationService);

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
            Assert.True(response?.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}