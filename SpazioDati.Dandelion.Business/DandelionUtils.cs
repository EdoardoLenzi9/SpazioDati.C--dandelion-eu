using System;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Domain.Models;
using SpazioDati.Dandelion.Business.Services;
using SimpleInjector;
using Newtonsoft.Json;

namespace SpazioDati.Dandelion.Business
{
    public class DandelionUtils
    {
        private static EntityExtractionService _entityExtractionService;
        private static LanguageDetectionService _languageDetectionService;
        private static SentimentAnalysisService _sentimentAnalysisService;
        private static TextClassificationService _textClassificationService;
        private static TextSimilarityService _textSimilarityService;
        private static WikisearchService _wikisearchService;
        private static CustomSpotService _customSpotService;
        private static CustomModelService _customModelService;
        private static Container _container;

        private static void Resolve()
        {
            ServiceUtils.Init();
            _container = new Container();
            _entityExtractionService = _container.GetInstance<EntityExtractionService>();
            _languageDetectionService = _container.GetInstance<LanguageDetectionService>();
            _sentimentAnalysisService = _container.GetInstance<SentimentAnalysisService>();
            _textClassificationService = _container.GetInstance<TextClassificationService>();
            _textSimilarityService = _container.GetInstance<TextSimilarityService>();
            _wikisearchService = _container.GetInstance<WikisearchService>();
            _customSpotService = _container.GetInstance<CustomSpotService>();
            _customModelService = _container.GetInstance<CustomModelService>();
        }

        public DandelionUtils()
        {
            Resolve();
        }

        private static void SetToken(string token)
        {
            if (String.IsNullOrEmpty(token) && String.IsNullOrEmpty(Localizations.Token))         //cambiare metodi statici
            {
                throw new ArgumentException(ErrorMessages.InvalidToken, ErrorMessages.Token);
            }
            if (!String.IsNullOrEmpty(token))
            {
                Localizations.Token = token;
            }
        }

        public static T GetParametersFromJson<T>(string jsonParamenters)
        {
            return JsonConvert.DeserializeObject<T>(jsonParamenters);
        }

        public static Task<EntityExtractionDto> GetEntitiesAsync(EntityExtractionParameters parameters, string token = "")
        {
            SetToken(token);
            return _entityExtractionService.CallEntityExtractionAsync(parameters);
        }

        public static Task<TextSimilarityDto> GetSimilaritiesAsync(TextSimilarityParameters parameters, string token = "")
        {
            SetToken(token);
            return _textSimilarityService.CallTextSimilaritiesAsync(parameters);
        }

        public static Task<TextClassificationDto> ClassifyTextAsync(TextClassificationParameters parameters, string token = "")
        {
            SetToken(token);
            return _textClassificationService.CallTextClassificationAsync(parameters);
        }

        public static Task<LanguageDetectionDto> DetectLanguageAsync(LanguageDetectionParameters parameters, string token = "")
        {
            SetToken(token);
            return _languageDetectionService.CallLanguageDetectionAsync(parameters);
        }

        public static Task<SentimentAnalysisDto> AnalyzeSentimentsAsync(SentimentAnalysisParameters parameters, string token = "")
        {
            SetToken(token);
            return _sentimentAnalysisService.CallSentimentAnalysisAsync(parameters);
        }

        public static Task<WikisearchDto> GetWikiSearchAsync(WikisearchParameters parameters, string token = "")
        {
            SetToken(token);
            return _wikisearchService.CallWikisearchAsync(parameters);
        }

        public static Task<CustomSpotDto> CreateCustomSpot(CustomSpotParameters parameters, string token = "")
        {
            SetToken(token);
            return _customSpotService.CallCreateCustomSpotAsync(parameters);
        }

        public static Task<CustomSpotDto> ReadCustomSpot(CustomSpotParameters parameters, string token = "")
        {
            SetToken(token);
            return _customSpotService.CallReadCustomSpotAsync(parameters);
        }

        public static Task<CustomSpotDto> UpdateCustomSpot(CustomSpotParameters parameters, string token = "")
        {
            SetToken(token);
            return _customSpotService.CallUpdateCustomSpotAsync(parameters);
        }

        public static Task DeleteCustomSpot(CustomSpotParameters parameters, string token = "")
        {
            SetToken(token);
            return _customSpotService.CallDeleteCustomSpotAsync(parameters);
        }

        public static Task<CustomSpotsListDto> ListAllCustomSpots(CustomSpotParameters parameters, string token = "")
        {
            SetToken(token);
            return _customSpotService.CallListAllCustomSpotsAsync();
        }

        public static Task<CustomModelDto> CreateCustomModel(CustomModelParameters parameters, string token = "")
        {
            SetToken(token);
            return _customModelService.CallCreateCustomModelAsync(parameters);
        }

        public static Task<CustomModelDto> ReadCustomModel(CustomModelParameters parameters, string token = "")
        {
            SetToken(token);
            return _customModelService.CallReadCustomModelAsync(parameters);
        }

        public static Task<CustomModelDto> UpdateCustomModel(CustomModelParameters parameters, string token = "")
        {
            SetToken(token);
            return _customModelService.CallUpdateCustomModelAsync(parameters);
        }

        public static Task DeleteCustomModel(CustomModelParameters parameters, string token = "")
        {
            SetToken(token);
            return _customModelService.CallDeleteCustomModelAsync(parameters);
        }

        public static Task<CustomModelsListDto> ListAllCustomModels(CustomModelParameters parameters, string token = "")
        {
            SetToken(token);
            return _customModelService.CallListAllCustomModelsAsync();
        }
    }
}
