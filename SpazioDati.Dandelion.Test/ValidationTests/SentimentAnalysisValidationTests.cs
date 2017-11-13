using System;
using System.Collections.Generic;
using FactoryMind.TrackMe.Test;
using SpazioDati.Dandelion.Business.Services;
using SpazioDati.Dandelion.Domain.Models;
using Xunit;

namespace SpazioDati.Dandelion.Test.ValidationTests
{
    public class SentimentAnalysisValidationTests : IClassFixture<ServiceFixture>
    {
        private ServiceFixture _fixture;
        private SentimentAnalysisService _sentimentAnalysisService;

        public SentimentAnalysisValidationTests(ServiceFixture fixture) {
            _fixture = fixture;
            _sentimentAnalysisService = fixture.SentimentAnalysisService;
        }

        [Theory]
        [MemberData(nameof(GetParameters))]
        public async void Should_ThrowException_When_CallSentimentAnalysisWithWrongParameters(SentimentAnalysisParameters parameters, string message, string wrongParameter) {
            //Act & Assert

            ArgumentException ex = await Assert.ThrowsAsync<ArgumentException>(() => _sentimentAnalysisService.CallSentimentAnalysisAsync(parameters));
            if (String.IsNullOrEmpty(wrongParameter))
            {
                Assert.Equal(message, ex.Message);
            }
            else
            {
                Assert.Equal($"{message}{Environment.NewLine}Parameter name: {wrongParameter}", ex.Message);
            }
        }

        public static IEnumerable<object[]> GetParameters()
        {
            yield return new object[] { new SentimentAnalysisParameters(), ErrorMessages.WrongSource, "" };
            yield return new object[] { new SentimentAnalysisParameters { Text = "Text", Lang = LanguageOption.de}, ErrorMessages.WrongLang1, ErrorMessages.Lang };
        }
    }
}
