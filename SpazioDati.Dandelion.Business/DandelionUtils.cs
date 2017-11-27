using System.Threading.Tasks;
using SpazioDati.Dandelion.Domain.Models;
using SpazioDati.Dandelion.Business.Services;
using Newtonsoft.Json;
using SpazioDati.Dandelion.Business.Containers;

namespace SpazioDati.Dandelion.Business
{
    ///<summary> 
    ///     Utility class that allow to call Dandelion API 
    ///     <link> Visit </link>
    ///</summary>
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

        ///<summary> 
        ///     This methods useful in order to initialize services with Simple Injection
        ///</summary>
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

        ///<summary> 
        ///     Deserialize a JSON of a parameter class <seealso cref="Parameters"/>        
        ///</summary>
        ///<param name="jsonParamenters"> JSON that represent generic <typeparamref name="T"/> ParameterClass </param>
        ///<typeparam name="T">The parameter class</typeparam>
        ///<returns>Returns a <typeparamref name="T"/> parameter instance deserialized from <paramref name="jsonParamenters"/> string</returns>

        public static T GetParametersFromJson<T>(string jsonParamenters)
        {
            return JsonConvert.DeserializeObject<T>(jsonParamenters);
        }

        ///<summary> 
        ///     Asyncronous method that call EntityExtraction end-point to compute a text source          
        ///     <link> </link>
        ///</summary>
        ///<param name="parameters"> Parameters to specify all'options for the EntityExtraction process </param>
        ///<returns>Returns a <c>EntityExtractionDto</c> populated with the result of the EntityExtraction process </returns>

        public static Task<EntityExtractionDto> GetEntitiesAsync(EntityExtractionParameters parameters)
        {
            Init();
            return _entityExtractionService.CallEntityExtractionAsync(parameters);
        }

        ///<summary> 
        ///     Asyncronous method that call TextSimilarity end-point to compare two text sources          
        ///     <link> </link>
        ///</summary>
        ///<param name="parameters"> Parameters to specify all'options for the TextSimilarity process </param>
        ///<returns>Returns a <c>TextSimilarityDto</c> populated with the result of the TextSimilarity process </returns>
        public static Task<TextSimilarityDto> GetSimilaritiesAsync(TextSimilarityParameters parameters)
        {
            Init();
            return _textSimilarityService.CallTextSimilaritiesAsync(parameters);
        }

        ///<summary> 
        ///     Asyncronous method that call TextClassification end-point to compute a text source          
        ///     <link> </link>
        ///</summary>
        ///<param name="parameters"> Parameters to specify all'options for the TextSimilarity process </param>
        ///<returns>Returns a <c>TextSimilarityDto</c> populated with the result of the TextSimilarity process </returns>
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
