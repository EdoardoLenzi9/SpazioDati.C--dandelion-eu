using SpazioDati.Dandelion.Business.Clients;
using SpazioDati.Dandelion.Business.Containers;

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
    }
}