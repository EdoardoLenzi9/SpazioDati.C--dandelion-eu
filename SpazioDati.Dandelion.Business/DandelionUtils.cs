using System.Threading.Tasks;
using SpazioDati.Dandelion.Domain.Models;
using SpazioDati.Dandelion.Business.Services;
using Newtonsoft.Json;
using SpazioDati.Dandelion.Business.Containers;

namespace SpazioDati.Dandelion.Business
{
    /// <summary> 
    ///     Utility class that allow to call every <see href="https://dandelion.eu/docs/">Dandelion API</see>
    /// </summary>
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

        /// <summary> 
        ///     Initializes the services (it's based on the Dependency Injection pattern)
        /// </summary>
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

        /// <summary> 
        ///     Deserializes a JSON to a generic parameter class <seealso cref="Parameters"/>        
        /// </summary>
        /// <param name="jsonParameters"> JSON that represent generic <typeparamref name="T"/> ParameterClass </param>
        /// <typeparam name="T">The parameter class</typeparam>
        /// <returns>Returns a <typeparamref name="T"/> parameter instance deserialized from <paramref name="jsonParameters"/> string</returns>
        public static T GetParametersFromJson<T>(string jsonParameters)
        {
            return JsonConvert.DeserializeObject<T>(jsonParameters);
        }

        /// <summary> 
        ///     Asyncronous method that call <see href="https://dandelion.eu/docs/api/datatxt/nex/v1/">EntityExtraction end-point</see> on a text source          
        /// </summary>
        /// <param name="parameters"> Parameters to specify all options for the EntityExtraction process </param>
        /// <returns>Returns a <c>EntityExtractionDto</c> populated with the result of the EntityExtraction process </returns>
        /// <seealso cref="EntityExtractionDto"/> 
        public static Task<EntityExtractionDto> GetEntitiesAsync(EntityExtractionParameters parameters)
        {
            Init();
            return _entityExtractionService.CallEntityExtractionAsync(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that call <see href="https://dandelion.eu/docs/api/datatxt/sim/v1/">Text Similarity end-point</see> to compare two text sources          
        /// </summary>
        /// <param name="parameters"> Parameters to specify all options for the Text Similarity process </param>
        /// <returns>Returns a <c>TextSimilarityDto</c> populated with the result of the Text Similarity process </returns>
        /// <seealso cref="TextSimilarityDto"/> 
        public static Task<TextSimilarityDto> GetSimilaritiesAsync(TextSimilarityParameters parameters)
        {
            Init();
            return _textSimilarityService.CallTextSimilaritiesAsync(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that call <see href="https://dandelion.eu/docs/api/datatxt/cl/v1/">Text Classification end-point</see> on a text source        
        /// </summary>
        /// <param name="parameters"> Parameters to specify all options for the Text Classification process </param>
        /// <returns>Returns a <c>TextClassificationDto</c> populated with the result of the Text Classification process </returns>
        /// <seealso cref="TextClassificationDto"/> 
        public static Task<TextClassificationDto> ClassifyTextAsync(TextClassificationParameters parameters)
        {
            Init();
            return _textClassificationService.CallTextClassificationAsync(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that call <see href="https://dandelion.eu/docs/api/datatxt/li/v1/">Language Detection end-point</see> on a text source        
        /// </summary>
        /// <param name="parameters"> Parameters to specify all options for the Language Detection process </param>
        /// <returns>Returns a <c>LanguageDetectionDto</c> populated with the result of the Language Detection process </returns>
        /// <seealso cref="LanguageDetectionDto"/> 
        public static Task<LanguageDetectionDto> DetectLanguageAsync(LanguageDetectionParameters parameters)
        {
            Init();
            return _languageDetectionService.CallLanguageDetectionAsync(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that call <see href="https://dandelion.eu/docs/api/datatxt/sent/v1/">Sentiment Analysis end-point</see> on a text source        
        /// </summary>
        /// <param name="parameters"> Parameters to specify all options for the Sentiment Analysis process </param>
        /// <returns>Returns a <c>SentimentAnalysisDto</c> populated with the result of the Sentiment Analysis process </returns>
        /// <seealso cref="SentimentAnalysisDto"/> 
        public static Task<SentimentAnalysisDto> AnalyzeSentimentsAsync(SentimentAnalysisParameters parameters)
        {
            Init();
            return _sentimentAnalysisService.CallSentimentAnalysisAsync(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that call <see href="https://dandelion.eu/docs/api/datagraph/wikisearch/">Wikisearch end-point</see> on a text source        
        /// </summary>
        /// <param name="parameters"> Parameters to specify all options for the Wikisearch process </param>
        /// <returns>Returns a <c>WikisearchDto</c> populated with the result of the Wikisearch process </returns>
        /// <seealso cref="WikisearchDto"/> 
        public static Task<WikisearchDto> GetWikiSearchAsync(WikisearchParameters parameters)
        {
            Init();
            return _wikisearchService.CallWikisearchAsync(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that create a new <see href="https://dandelion.eu/docs/api/datatxt/custom-spots/v1/#create">Custom Spot</see>        
        /// </summary>
        /// <param name="parameters"> Contains all the informations related to the custom spot</param>
        /// <returns>Returns a <c>CustomSpotDto</c> populated with the result of the process </returns>
        /// <seealso cref="CustomSpotDto"/> 
        public static Task<CustomSpotDto> CreateCustomSpotAsync(CustomSpotParameters parameters)
        {
            Init();
            return _customSpotService.CallCreateCustomSpotAsync(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that read a <see href="https://dandelion.eu/docs/api/datatxt/custom-spots/v1/#read">Custom Spot</see>        
        /// </summary>
        /// <param name="parameters"> Contains all the informations related to the custom spot</param>
        /// <returns>Returns a <c>CustomSpotDto</c> populated with the result of the process </returns>
        /// <seealso cref="CustomSpotDto"/> 
        public static Task<CustomSpotDto> ReadCustomSpotAsync(CustomSpotParameters parameters)
        {
            Init();
            return _customSpotService.CallReadCustomSpotAsync(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that update a <see href="https://dandelion.eu/docs/api/datatxt/custom-spots/v1/#update">Custom Spot</see>        
        /// </summary>
        /// <param name="parameters"> Contains all the informations related to the custom spot</param>
        /// <returns>Returns a <c>CustomSpotDto</c> populated with the result of the process </returns>
        /// <seealso cref="CustomSpotDto"/> 
        public static Task<CustomSpotDto> UpdateCustomSpotAsync(CustomSpotParameters parameters)
        {
            Init();
            return _customSpotService.CallUpdateCustomSpotAsync(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that delete a <see href="https://dandelion.eu/docs/api/datatxt/custom-spots/v1/#delete">Custom Spot</see>        
        /// </summary>
        /// <param name="parameters"> Contains all the informations related to the custom spot</param> 
        public static Task DeleteCustomSpotAsync(CustomSpotParameters parameters)
        {
            Init();
            return _customSpotService.CallDeleteCustomSpotAsync(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that returns the list of all your <see href="https://dandelion.eu/docs/api/datatxt/custom-spots/v1/#list">Custom Spots</see>        
        /// </summary>
        /// <param name="parameters"> Contains all the informations related to the custom spots</param>
        /// <returns>Returns a <c>CustomSpotsListDto</c> populated with the result of the process </returns>
        /// <seealso cref="CustomSpotsListDto"/> 
        public static Task<CustomSpotsListDto> ListAllCustomSpotsAsync(CustomSpotParameters parameters)
        {
            Init();
            return _customSpotService.CallListAllCustomSpotsAsync();
        }

        /// <summary> 
        ///     Asyncronous method that create a new <see href="https://dandelion.eu/docs/api/datatxt/cl/models/v1/#create">Custom Model</see>        
        /// </summary>
        /// <param name="parameters"> Contains all the informations related to the custom model</param>
        /// <returns>Returns a <c>CustomModelDto</c> populated with the result of the process </returns>
        /// <seealso cref="CustomModelDto"/> 
        public static Task<CustomModelDto> CreateCustomModelAsync(CustomModelParameters parameters)
        {
            Init();
            return _customModelService.CallCreateCustomModelAsync(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that read a <see href="https://dandelion.eu/docs/api/datatxt/cl/models/v1/#read">Custom Model</see>        
        /// </summary>
        /// <param name="parameters"> Contains all the informations related to the custom model</param>
        /// <returns>Returns a <c>CustomModelDto</c> populated with the result of the process </returns>
        /// <seealso cref="CustomModelDto"/> 
        public static Task<CustomModelDto> ReadCustomModelAsync(CustomModelParameters parameters)
        {
            Init();
            return _customModelService.CallReadCustomModelAsync(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that update a <see href="https://dandelion.eu/docs/api/datatxt/cl/models/v1/#update">Custom Model</see>        
        /// </summary>
        /// <param name="parameters"> Contains all the informations related to the custom model</param>
        /// <returns>Returns a <c>CustomModelDto</c> populated with the result of the process </returns>
        /// <seealso cref="CustomModelDto"/> 
        public static Task<CustomModelDto> UpdateCustomModelAsync(CustomModelParameters parameters)
        {
            Init();
            return _customModelService.CallUpdateCustomModelAsync(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that delete a <see href="https://dandelion.eu/docs/api/datatxt/cl/models/v1/#delete">Custom Model</see>        
        /// </summary>
        /// <param name="parameters"> Contains all the informations related to the custom model</param>
        public static Task DeleteCustomModelAsync(CustomModelParameters parameters)
        {
            Init();
            return _customModelService.CallDeleteCustomModelAsync(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that returns the list of all your <see href="https://dandelion.eu/docs/api/datatxt/cl/models/v1/#list">Custom Models</see>        
        /// </summary>
        /// <param name="parameters"> Contains all the informations related to the custom models</param>
        /// <returns>Returns a <c>CustomModelsListDto</c> populated with the result of the process </returns>
        /// <seealso cref="CustomModelsListDto"/> 
        public static Task<CustomModelsListDto> ListAllCustomModelsAsync(CustomModelParameters parameters)
        {
            Init();
            return _customModelService.CallListAllCustomModelsAsync();
        }
    }
}
