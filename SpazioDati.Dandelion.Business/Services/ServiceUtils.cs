using SpazioDati.Dandelion.Business.Clients;

namespace SpazioDati.Dandelion.Business.Services
{
    public static class ServiceUtils
    {
        public static void Init()
        {
            var container =  new SimpleInjector.Container();
            container.Register<EntityExtractionService>(SimpleInjector.Lifestyle.Singleton);
            container.Register<LanguageDetectionService>(SimpleInjector.Lifestyle.Singleton);
            container.Register<SentimentAnalysisService>(SimpleInjector.Lifestyle.Singleton);
            container.Register<TextClassificationService>(SimpleInjector.Lifestyle.Singleton);
            container.Register<TextSimilarityService>(SimpleInjector.Lifestyle.Singleton);
            container.Register<WikisearchService>(SimpleInjector.Lifestyle.Singleton);
            ApiClient.Init();
        }
    }
}