using IntegrationViaCep.Core.InfraCrossCutting;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationViaCep.Test
{
    public class Startup
    {
        private readonly IServiceCollection _serviceCollection;
        public ServiceProvider _serviceProvider;

        /// <summary>
        /// Initialize dependencies and ServiceProvider to get service in Tests.
        /// </summary>
        public Startup()
        {
            _serviceCollection = new ServiceCollection();
            ConfigurationIoc.Register(_serviceCollection);
            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }
    }
}
