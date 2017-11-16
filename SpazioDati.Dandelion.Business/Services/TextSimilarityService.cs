using SpazioDati.Dandelion.Domain.Models;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;
using System;

namespace SpazioDati.Dandelion.Business.Services
{
    public class TextSimilarityService
    {
        private ApiClient _apiClient;

        public TextSimilarityService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<TextSimilarityDto> CallTextSimilaritiesAsync(TextSimilarityParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentException(ErrorMessages.MissingParameters);
            }
            var source = SourceValidation.verifyMultipleSources(parameters);
            return _apiClient.CallApiAsync<TextSimilarityDto>(ApiClient.TextSimilarityUriBuilder(), ApiClient.TextSimilarityContentBuilder(source, parameters));
        }

    }
}