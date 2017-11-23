using System;
using SpazioDati.Dandelion.Business.Clients;
using SpazioDati.Dandelion.Business.Containers;
using SpazioDati.Dandelion.Domain.Models;

namespace SpazioDati.Dandelion.Business.Services
{
    public static class ServiceUtils
    {
        private static Container _container;

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

        public static void ParameterValidation(Parameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentException(ErrorMessages.MissingParameters);
            }
            TokenValidation(parameters);
        }

        public static void TokenValidation(Parameters parameters)
        {
            if (String.IsNullOrEmpty(parameters.Token))
            {
                throw new ArgumentException(ErrorMessages.InvalidToken, ErrorMessages.Token);
            }
        }
    }
}