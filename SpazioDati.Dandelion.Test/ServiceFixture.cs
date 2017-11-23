using System;
using SpazioDati.Dandelion.Business.Containers;
using SpazioDati.Dandelion.Business.Services;

namespace FactoryMind.TrackMe.Test
{

    public class ServiceFixture : IDisposable
    {
        public EntityExtractionService EntityExtractionService { get; private set; }
        public LanguageDetectionService LanguageDetectionService { get; private set; }
        public SentimentAnalysisService SentimentAnalysisService { get; private set; }
        public TextClassificationService TextClassificationService { get; private set; }
        public TextSimilarityService TextSimilarityService { get; private set; }
        public WikisearchService WikisearchService { get; private set; }
        private Container _container;

        public ServiceFixture()
        {
            ServiceUtils.Init();
            _container = Container.GetInstance();

            EntityExtractionService = _container.Resolve<EntityExtractionService>();
            LanguageDetectionService = _container.Resolve<LanguageDetectionService>();
            SentimentAnalysisService = _container.Resolve<SentimentAnalysisService>();
            TextClassificationService = _container.Resolve<TextClassificationService>();
            TextSimilarityService = _container.Resolve<TextSimilarityService>();
            WikisearchService = _container.Resolve<WikisearchService>();
        }

        void IDisposable.Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}