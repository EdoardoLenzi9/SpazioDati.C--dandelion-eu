using SpazioDati.Dandelion.Domain.Models;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;

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
            var source = SourceValidation.verifyMultipleSources(parameters);
            return _apiClient.CallApiAsync<TextSimilarityDto>(ApiClient.TextSimilarityUriBuilder(), ApiClient.TextSimilarityContentBuilder(source, parameters));
        }

    }
}