using SpazioDati.Dandelion.Domain.Models;
using System;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;

namespace SpazioDati.Dandelion.Business.Services
{
    public class SentimentAnalysisService
    {
        private ApiClient _apiClient;

        public SentimentAnalysisService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<SentimentAnalysisDto> CallSentimentAnalysisAsync(SentimentAnalysisParameters parameters)
        {
            if (parameters.Lang != LanguageOption.en && parameters.Lang != LanguageOption.it && parameters.Lang != LanguageOption.auto)
            {
                throw new ArgumentException(ErrorMessages.WrongLang1, ErrorMessages.Lang);
            }
            var source = SourceValidation.verifySingleSource(parameters);
            return _apiClient.CallApiAsync<SentimentAnalysisDto>(ApiClient.SentimentAnalysisUrlBuilder(source, parameters));
        }

    }
}