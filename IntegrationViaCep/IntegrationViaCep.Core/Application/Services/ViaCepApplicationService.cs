﻿using IntegrationViaCep.Core.Application.Interfaces;
using IntegrationViaCep.Core.Domain.Handlers.Interfaces;
using IntegrationViaCep.Core.Domain.Models.Inputs;
using IntegrationViaCep.Core.Domain.Responses;

namespace IntegrationViaCep.Core.Application.Services
{
    public class ViaCepApplicationService : IViaCepApplicationService
    {
        private readonly IViaCepHandler _viaCepHandler;

        public ViaCepApplicationService(IViaCepHandler viaCepHandler)
        {
            _viaCepHandler = viaCepHandler;
        }

        /// <summary>
        /// Call GetPostalCodeAsync and return results of request in ViaCep.
        /// </summary>
        /// <param name="postalCode">PostalCode object containing CEP code.</param>
        /// <returns></returns>
        public async Task<Response> GetPostalCodeAsync(PostalCode postalCode) 
            => await _viaCepHandler.GetPostalCodeAsync(postalCode);

        /// <summary>
        /// Call PostSearchPostalCodeAsync and return search results of request in ViaCep.
        /// </summary>
        /// <param name="searchPostalCode">SearchPostalCode object containing 
        /// State, County and partial public place to search.</param>
        /// <returns></returns>
        public async Task<Response> PostSearchPostalCodeAsync(SearchPostalCode searchPostalCode) 
            => await _viaCepHandler.PostSearchPostalCodeAsync(searchPostalCode);       

    }
}
