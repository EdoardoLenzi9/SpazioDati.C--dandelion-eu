using System;
using SpazioDati.Dandelion.Business.Clients;
using SpazioDati.Dandelion.Business.Containers;
using SpazioDati.Dandelion.Domain.Models;

namespace SpazioDati.Dandelion.Business.Services
{
    /// <summary> 
    ///     Generic services class that provide methods useful to validate parameters and initialize other services 
    /// </summary>
    public static class ServiceUtils
    {
        private static Container _container;

        /// <summary> 
        ///     Method that initialize the container of the <see href="https://www.nuget.org/packages/SimpleInjector/">Simple Injector</see>       
        /// </summary>
        public static void Init()
        {
            if (_container == null)
            {
                _container = Container.GetInstance();
                _container.Register<EntityExtractionService>(Lifestyle.Singleton);
                _container.Register<LanguageDetectionService>(Lifestyle.Singleton);
                _container.Register<SentimentAnalysisService>(Lifestyle.Singleton);
                _container.Register<TextClassificationService>(Lifestyle.Singleton);
                _container.Register<TextSimilarityService>(Lifestyle.Singleton);
                _container.Register<WikisearchService>(Lifestyle.Singleton);
                _container.Register<CustomSpotService>(Lifestyle.Singleton);
                _container.Register<CustomModelService>(Lifestyle.Singleton);
                ApiClient.Init();
            }
        }

        /// <summary> 
        ///     Asyncronous method that validate the user parameters 
        /// </summary>
        /// <param name="parameters"></param>
        public static void ParameterValidation(Parameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentException(ErrorMessages.MissingParameters);
            }
            TokenValidation(parameters);
        }

        /// <summary> 
        ///     Asyncronous method that validate the token parameter
        /// </summary>
        /// <param name="parameters"></param>
        public static void TokenValidation(Parameters parameters)
        {
            if (String.IsNullOrEmpty(parameters.Token))
            {
                throw new ArgumentException(ErrorMessages.InvalidToken, ErrorMessages.Token);
            }
        }
    }
}