using SpazioDati.Dandelion.Business.Clients;
using SpazioDati.Dandelion.Business.Extensions;

namespace SpazioDati.Dandelion.Business.Services
{
    public static class ServiceUtils
    {
        private static SimpleInjector.Container _container;

        public static void Init()
        {
            if (_container == null)
            {
                _container = _container.GetInstance();
                _container.Register<EntityExtractionService>(SimpleInjector.Lifestyle.Singleton);
                _container.Register<LanguageDetectionService>(SimpleInjector.Lifestyle.Singleton);
                _container.Register<SentimentAnalysisService>(SimpleInjector.Lifestyle.Singleton);
                _container.Register<TextClassificationService>(SimpleInjector.Lifestyle.Singleton);
                _container.Register<TextSimilarityService>(SimpleInjector.Lifestyle.Singleton);
                _container.Register<WikisearchService>(SimpleInjector.Lifestyle.Singleton);
                ApiClient.Init();
            }
        }
    }
}