using System;
using System.Collections.Generic;
using FactoryMind.TrackMe.Test;
using SpazioDati.Dandelion.Business.Services;
using SpazioDati.Dandelion.Domain.Models;
using Xunit;

namespace SpazioDati.Dandelion.Test.ValidationTests
{
    public class WikisearchValidationTests : IClassFixture<ServiceFixture>
    {
        private ServiceFixture _fixture;
        private WikisearchService _wikisearchtextClassificationService;

        public WikisearchValidationTests(ServiceFixture fixture)
        {
            _fixture = fixture;
            _wikisearchtextClassificationService = fixture.WikisearchService;
        }

        [Theory]
        [MemberData(nameof(GetParameters))]
        public async void Should_ThrowException_When_CallWikisearchWithWrongParameters(WikisearchParameters parameters, string message, string wrongParameter)
        {
            //Act & Assert

            ArgumentException ex = await Assert.ThrowsAsync<ArgumentException>(() => _wikisearchtextClassificationService.CallWikisearchAsync(parameters));
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
            yield return new object[] { new WikisearchParameters { Token = "Token" }, ErrorMessages.WrongText, ErrorMessages.Text };
            yield return new object[] { new WikisearchParameters { Token = "Token", Text = "Text", Limit = 51 }, ErrorMessages.WrongLimit, ErrorMessages.Limit };
            yield return new object[] { new WikisearchParameters { Token = "Token", Text = "Text", Limit = 0 }, ErrorMessages.WrongLimit, ErrorMessages.Limit };
            yield return new object[] { new WikisearchParameters { Token = "Token", Text = "Text", Lang = LanguageOption.auto }, ErrorMessages.WrongLang2, ErrorMessages.Lang };
            yield return new object[] { new WikisearchParameters { Token = "Token", Text = "Text", Include = new List<IncludeOption>() { IncludeOption.score_details } }, ErrorMessages.WrongInclude1, ErrorMessages.Include };
        }
    }
}
