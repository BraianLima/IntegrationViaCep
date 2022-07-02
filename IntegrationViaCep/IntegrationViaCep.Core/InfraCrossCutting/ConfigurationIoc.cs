using IntegrationViaCep.Core.Application.Interfaces;
using IntegrationViaCep.Core.Application.Services;
using IntegrationViaCep.Core.Domain.Handlers;
using IntegrationViaCep.Core.Domain.Handlers.Interfaces;
using IntegrationViaCep.Core.Domain.Handlers.Validators;
using IntegrationViaCep.Core.Domain.Handlers.Validators.Interfaces;
using IntegrationViaCep.Core.Domain.Utils;
using IntegrationViaCep.Core.Domain.Utils.Interfaces;
using IntegrationViaCep.Core.Services.Interfaces;
using IntegrationViaCep.Core.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationViaCep.Core.InfraCrossCutting
{
    public static class ConfigurationIoc
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IServiceViaCep, ServiceViaCep>();
            services.AddTransient<IObjectFactories, ObjectFactories>();
            services.AddTransient<IViaCepValidators, ViaCepValidators>();
            services.AddTransient<IFormat, Format>();
            services.AddTransient<IViaCepHandler, ViaCepHandler>();
            services.AddTransient<IViaCepApplicationService, ViaCepApplicationService>();
        }
    }
}
