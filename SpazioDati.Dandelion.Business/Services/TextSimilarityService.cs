using SpazioDati.Dandelion.Domain.Models;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;
namespace SpazioDati.Dandelion.Business.Services
{
    /// <summary> 
    ///     Services class that parse the user parameters and call the <c>client</c> 
    /// </summary>
    /// <seealso cref="ApiClient"/> 
    public class TextSimilarityService
    {
        private ApiClient _apiClient;

        public TextSimilarityService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary> 
        ///     Asyncronous method that validate the user parameters and call <c>ApiClient</c>       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns a <c>TextSimilarityDto</c> populated with the result of the call </returns>
        /// <seealso cref="TextSimilarityDto"/> 
        public Task<TextSimilarityDto> CallTextSimilaritiesAsync(TextSimilarityParameters parameters)
        {
            EntityExtractionService.ValidateParameters(parameters);
            var source = SourceValidationService.verifyMultipleSources(parameters);
            return _apiClient.CallApiAsync<TextSimilarityDto>(ApiClient.TextSimilarityUriBuilder(), ApiClient.TextSimilarityContentBuilder(source, parameters), parameters.HttpMethod);
        }

    }
}