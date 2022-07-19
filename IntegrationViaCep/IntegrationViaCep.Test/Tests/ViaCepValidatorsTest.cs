using IntegrationViaCep.Core.Domain.Handlers.Validators.Interfaces;
using IntegrationViaCep.Core.Domain.Models.Inputs;

namespace IntegrationViaCep.Test.Tests
{
    public class ViaCepValidatorsTest : Startup
    {

        private readonly IViaCepValidators? _viaCepValidators;

        /// <summary>
        /// Initialize services to use.
        /// </summary>
        public ViaCepValidatorsTest()
        {
            //get service by ServiceProvider
            _viaCepValidators = _serviceProvider.GetService<IViaCepValidators>();
        }

        /// <summary>
        /// Unit test about PostalCodeIsValid of IViaCepValidators
        /// </summary>
        [Fact]
        public void PostalCodeIsValid()
        {
            Assert.NotNull(_viaCepValidators); //check if service is null

            bool? valid = _viaCepValidators?
                .PostalCodeIsValid(new PostalCode { CepCode = "83010900" }); //check PostalCode is valid

            //check if variable valid is true and not null
            Assert.NotNull(valid);
            Assert.True(valid);
        }


        /// <summary>
        /// Unit test about SearchPostalCodeIsValid of IViaCepValidators
        /// </summary>
        [Fact]
        public void SearchPostalCodeIsValid()
        {
            Assert.NotNull(_viaCepValidators); //check if service is null

            bool? valid = _viaCepValidators?
                .SearchPostalCodeIsValid(new SearchPostalCode
                {
                    State = "RS",
                    County = "Porto Alegre",
                    PublicPlace = "Domingos"
                }); //check SearchPostalCode is valid

            //check if variable valid is true and not null
            Assert.NotNull(valid);
            Assert.True(valid);
        }
    }
}
