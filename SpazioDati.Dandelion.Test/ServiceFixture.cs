using System;
using SpazioDati.Dandelion.Business.Services;
using SpazioDati.Dandelion.Business.Extensions;
using SimpleInjector;

namespace FactoryMind.TrackMe.Test
{

    public class ServiceFixture : IDisposable
    {
        public EntityExtractionService EntityExtractionService { get; private set; }
        public LanguageDetectionService LanguageDetectionService { get; private set; }
        public SentimentAnalysisService SentimentAnalysisService { get; private set; }
        public SourceValidation SourceValidation { get; private set; }
        public TextClassificationService TextClassificationService { get; private set; }
        public TextSimilarityService TextSimilarityService { get; private set; }
        public WikisearchService WikisearchService { get; private set; }
        private Container _container;

        public ServiceFixture()
        {
            ServiceUtils.Init();
            _container = _container.GetInstance();

            EntityExtractionService = _container.GetInstance<EntityExtractionService>();
            LanguageDetectionService = _container.GetInstance<LanguageDetectionService>();
            SentimentAnalysisService = _container.GetInstance<SentimentAnalysisService>();
            SourceValidation = _container.GetInstance<SourceValidation>();
            TextClassificationService = _container.GetInstance<TextClassificationService>();
            TextSimilarityService = _container.GetInstance<TextSimilarityService>();
            WikisearchService = _container.GetInstance<WikisearchService>();
        }

        void IDisposable.Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}