using System;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Domain.Models;
using SpazioDati.Dandelion.Business.Services;
using SimpleInjector;

namespace SpazioDati.Dandelion
{
    class Dandelion
    {
        private static EntityExtractionService _entityExtractionService;
        private static LanguageDetectionService _languageDetectionService;
        private static SentimentAnalysisService _sentimentAnalysisService;
        private static TextClassificationService _textClassificationService;
        private static TextSimilarityService _textSimilarityService;
        private static WikisearchService _wikisearchService;
        private static Container _container;

        public static void Resolve()
        {
            _container = new Container();
            _entityExtractionService = _container.GetInstance<EntityExtractionService>();
            _languageDetectionService = _container.GetInstance<LanguageDetectionService>();
            _sentimentAnalysisService = _container.GetInstance<SentimentAnalysisService>();
            _textClassificationService = _container.GetInstance<TextClassificationService>();
            _textSimilarityService = _container.GetInstance<TextSimilarityService>();
             _wikisearchService = _container.GetInstance<WikisearchService>();
        }

        public Dandelion() 
        {
            ServiceUtils.Init();
            Resolve();
        }

        public static void SetToken(string token)
        { //need more security, dependency injection
            if(String.IsNullOrEmpty(token) && String.IsNullOrEmpty(Localizations.Token))         //cambiare metodi statici
            {
                throw new ArgumentException(ErrorMessages.InvalidToken, ErrorMessages.Token);
            }
            if(!String.IsNullOrEmpty(token))
            {
                Localizations.Token = token;
            }
        }

        public static Task<EntityExtractionDto> GetEntitiesAsync (EntityExtractionParameters parameters, string token = "")
        {
            SetToken(token);
            return _entityExtractionService.CallEntityExtractionAsync(parameters);
        }

        public static Task<TextSimilarityDto> GetSimilaritiesAsync (TextSimilarityParameters parameters, string token = "")
        {
            SetToken(token);
            return _textSimilarityService.CallTextSimilaritiesAsync(parameters);
        }

        public static Task<TextClassificationDto> ClassifyTextAsync (TextClassificationParameters parameters, string token = "")
        {
            SetToken(token);
            return _textClassificationService.CallTextClassificationAsync(parameters);
        }

        public static Task<LanguageDetectionDto> DetectLanguageAsync (LanguageDetectionParameters parameters, string token = "")
        {
            SetToken(token);
            return _languageDetectionService.CallLanguageDetectionAsync(parameters);
        }

        public static Task<SentimentAnalysisDto> AnalyzeSentimentsAsync (SentimentAnalysisParameters parameters, string token = "")
        {
            SetToken(token);
            return _sentimentAnalysisService.CallSentimentAnalysisAsync(parameters);
        }

        public static Task<WikisearchDto> GetWikiSearchAsync (WikisearchParameters parameters, string token = "")
        {
            SetToken(token);
            return _wikisearchService.CallWikisearchAsync(parameters);
        }

    }
}
