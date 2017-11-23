using System.Threading.Tasks;
using SpazioDati.Dandelion.Domain.Models;
using SpazioDati.Dandelion.Business.Services;
using Newtonsoft.Json;
using SpazioDati.Dandelion.Business.Containers;

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

        private static void Init()
        {
            if (_container == null)
            {
                ServiceUtils.Init();
                _container = Container.GetInstance();
                _entityExtractionService = _container.Resolve<EntityExtractionService>();
                _languageDetectionService = _container.Resolve<LanguageDetectionService>();
                _sentimentAnalysisService = _container.Resolve<SentimentAnalysisService>();
                _textClassificationService = _container.Resolve<TextClassificationService>();
                _textSimilarityService = _container.Resolve<TextSimilarityService>();
                _wikisearchService = _container.Resolve<WikisearchService>();
                _customSpotService = _container.Resolve<CustomSpotService>();
                _customModelService = _container.Resolve<CustomModelService>();
            }
        }

        public static T GetParametersFromJson<T>(string jsonParamenters)
        {
            return JsonConvert.DeserializeObject<T>(jsonParamenters);
        }

        public static Task<EntityExtractionDto> GetEntitiesAsync(EntityExtractionParameters parameters)
        {
            Init();
            return _entityExtractionService.CallEntityExtractionAsync(parameters);
        }

        public static Task<TextSimilarityDto> GetSimilaritiesAsync(TextSimilarityParameters parameters)
        {
            Init();
            return _textSimilarityService.CallTextSimilaritiesAsync(parameters);
        }

        public static Task<TextClassificationDto> ClassifyTextAsync(TextClassificationParameters parameters)
        {
            Init();
            return _textClassificationService.CallTextClassificationAsync(parameters);
        }

        public static Task<LanguageDetectionDto> DetectLanguageAsync(LanguageDetectionParameters parameters)
        {
            Init();
            return _languageDetectionService.CallLanguageDetectionAsync(parameters);
        }

        public static Task<SentimentAnalysisDto> AnalyzeSentimentsAsync(SentimentAnalysisParameters parameters)
        {
            Init();
            return _sentimentAnalysisService.CallSentimentAnalysisAsync(parameters);
        }

        public static Task<WikisearchDto> GetWikiSearchAsync(WikisearchParameters parameters)
        {
            Init();
            return _wikisearchService.CallWikisearchAsync(parameters);
        }

        public static Task<CustomSpotDto> CreateCustomSpot(CustomSpotParameters parameters)
        {
            Init();
            return _customSpotService.CallCreateCustomSpotAsync(parameters);
        }

        public static Task<CustomSpotDto> ReadCustomSpot(CustomSpotParameters parameters)
        {
            Init();
            return _customSpotService.CallReadCustomSpotAsync(parameters);
        }

        public static Task<CustomSpotDto> UpdateCustomSpot(CustomSpotParameters parameters)
        {
            Init();
            return _customSpotService.CallUpdateCustomSpotAsync(parameters);
        }

        public static Task DeleteCustomSpot(CustomSpotParameters parameters)
        {
            Init();
            return _customSpotService.CallDeleteCustomSpotAsync(parameters);
        }

        public static Task<CustomSpotsListDto> ListAllCustomSpots(CustomSpotParameters parameters)
        {
            Init();
            return _customSpotService.CallListAllCustomSpotsAsync();
        }

        public static Task<CustomModelDto> CreateCustomModel(CustomModelParameters parameters)
        {
            Init();
            return _customModelService.CallCreateCustomModelAsync(parameters);
        }

        public static Task<CustomModelDto> ReadCustomModel(CustomModelParameters parameters)
        {
            Init();
            return _customModelService.CallReadCustomModelAsync(parameters);
        }

        public static Task<CustomModelDto> UpdateCustomModel(CustomModelParameters parameters)
        {
            Init();
            return _customModelService.CallUpdateCustomModelAsync(parameters);
        }

        public static Task DeleteCustomModel(CustomModelParameters parameters)
        {
            Init();
            return _customModelService.CallDeleteCustomModelAsync(parameters);
        }

        public static Task<CustomModelsListDto> ListAllCustomModels(CustomModelParameters parameters)
        {
            Init();
            return _customModelService.CallListAllCustomModelsAsync();
        }
    }
}
