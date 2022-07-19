using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Utils.Interfaces;

namespace IntegrationViaCep.Test.Tests
{
    public class FormatTest : Startup
    {
        private readonly IFormat? _format;
        private readonly string WS = "ws"; //endpoint must contain ws
        private readonly string JSON = "json"; //endpoint must contain json

        /// <summary>
        /// Initialize services to use.
        /// </summary>
        public FormatTest()
        {
            //get service by ServiceProvider
            _format = _serviceProvider.GetService<IFormat>();
        }


        /// <summary>
        /// Unit test about MountEndpointToRequestAddressUsingCepCode of IFormat
        /// </summary>
        [Fact]
        public void MountEndpointToRequestAddressUsingCepCode()
        {
            Assert.NotNull(_format); //check if service is null

            string cepCode = "83010900"; //CEP example

            //mount the endpoint to request viacep
            string? endpoint = _format?.MountEndpointToRequestAddressUsingCepCode(cepCode);
            Assert.NotNull(endpoint);

            //endpoint must contain '/'
            string[]? splitEndpoint = endpoint?.Split('/');

            //check if array string is right length
            Assert.True(LengthArrayStringIsValid(3, splitEndpoint?.Length));

            //check if this part string is "ws"
            Assert.True(StringIsValid(WS, splitEndpoint?[0]));

            //check if this part string equals cepCode
            Assert.True(StringIsValid(cepCode, splitEndpoint?[1]));

            //check if this part string is "JSON"
            Assert.True(StringIsValid(JSON, splitEndpoint?[2]));

        }

        /// <summary>
        /// Unit test about MountEndpointToRequestAddressesUsingSearchPostalCode of IFormat
        /// </summary>
        [Fact]
        public void MountEndpointToRequestAddressesUsingSearchPostalCode()
        {
            Assert.NotNull(_format); //check if service is null

            SearchPostalCode searchPostalCode = new()
            {
                State = "RS",
                County = "Porto Alegre",
                PublicPlace = "Domingos"
            };

            //mount the endpoint to request viacep
            string? endpoint = _format?.MountEndpointToRequestAddressesUsingSearchPostalCode(searchPostalCode);
            Assert.NotNull(endpoint);

            //endpoint must contain '/'
            string[]? splitEndpoint = endpoint?.Split('/');

            //check if array string is right length
            Assert.True(LengthArrayStringIsValid(5, splitEndpoint?.Length));

            //check if this part string is "ws"
            Assert.True(StringIsValid(WS, splitEndpoint?[0]));

            //check if this part string equals State
            Assert.True(StringIsValid(searchPostalCode.State, splitEndpoint?[1]));

            //check if this part string equals County
            Assert.True(StringIsValid(searchPostalCode.County, splitEndpoint?[2]));

            //check if this part string equals PublicPlace
            Assert.True(StringIsValid(searchPostalCode.PublicPlace, splitEndpoint?[3]));

            //check if this part string is "JSON"
            Assert.True(StringIsValid(JSON, splitEndpoint?[4]));
        }

        /// <summary>
        /// Check if rightLength equals lengthReceived of method MountEndpoint...
        /// </summary>
        /// <param name="rightLength">Rigth length of array string</param>
        /// <param name="lengthReceived">Length Received by MountEndpoint...</param>
        /// <returns></returns>
        private static bool LengthArrayStringIsValid(int rightLength, int? lengthReceived)
        {
            return rightLength == lengthReceived;
        }

        /// <summary>
        /// CHeck if valueSent equals valueReceived of method MountEndpoint...
        /// </summary>
        /// <param name="valueSent">Value sent to MountEndpoint...</param>
        /// <param name="valueReceived">Value sent by MountEndpoint...</param>
        /// <returns></returns>
        private static bool StringIsValid(string valueSent, string? valueReceived)
        {
            return valueSent == valueReceived; 
        }
    }
}
