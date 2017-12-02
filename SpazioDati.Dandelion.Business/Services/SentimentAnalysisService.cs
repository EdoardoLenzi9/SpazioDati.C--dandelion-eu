using SpazioDati.Dandelion.Domain.Models;
using System;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;

namespace SpazioDati.Dandelion.Business.Services
{
    /// <summary> 
    ///     Services class that parse the user parameters and call the <c>client</c> 
    /// </summary>
    /// <seealso cref="ApiClient"/> 
    public class SentimentAnalysisService
    {
        private ApiClient _apiClient;

        public SentimentAnalysisService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary> 
        ///     Asyncronous method that validate the user parameters and call <c>ApiClient</c>       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns a <c>SentimentAnalysisDto</c> populated with the result of the call </returns>
        /// <seealso cref="SentimentAnalysisDto"/> 
        public Task<SentimentAnalysisDto> CallSentimentAnalysisAsync(SentimentAnalysisParameters parameters)
        {
            ServiceUtils.ParameterValidation(parameters);
            if (parameters.Lang != LanguageOption.en && parameters.Lang != LanguageOption.it && parameters.Lang != LanguageOption.auto)
            {
                throw new ArgumentException(ErrorMessages.WrongLang1, ErrorMessages.Lang);
            }
            var source = SourceValidationService.verifySingleSource(parameters);
            return _apiClient.CallApiAsync<SentimentAnalysisDto>(ApiClient.SentimentAnalysisUriBuilder(), ApiClient.SentimentAnalysisContentBuilder(source, parameters), parameters.HttpMethod);
        }

    }
}