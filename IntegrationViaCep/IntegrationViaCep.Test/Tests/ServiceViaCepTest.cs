using IntegrationViaCep.Core.Domain.Global;
using IntegrationViaCep.Core.Services.Interfaces;

namespace IntegrationViaCep.Test.Tests
{
    public class ServiceViaCepTest : Startup
    {
        private readonly IServiceViaCep? _serviceViaCep;

        /// <summary>
        /// Initialize services to use.
        /// </summary>
        public ServiceViaCepTest()
        {
            //get service by ServiceProvider
            _serviceViaCep = _serviceProvider.GetService<IServiceViaCep>();
        }

        /// <summary>
        /// Unit test about InitializeHttpClient of IServiceViaCep
        /// </summary>
        [Fact]
        public void InitializeHttpClient()
        {
            Assert.NotNull(_serviceViaCep); //check if service is null

            //initialize HttpClient
            Task<HttpClient>? task = _serviceViaCep?
                .InitializeHttpClientAsync(GlobalVariables.BASE_ADDRESS_VIA_CEP); 

            //check if task is null
            Assert.NotNull(task);

            HttpClient? httpClient = task?.Result;

            //check the results
            Assert.NotNull(httpClient);

            //check if httpClient.BaseAddress equals BASE_ADDRESS_VIA_CEP
            Assert.True(httpClient?.BaseAddress == new Uri(GlobalVariables.BASE_ADDRESS_VIA_CEP));
        }

    }
}
