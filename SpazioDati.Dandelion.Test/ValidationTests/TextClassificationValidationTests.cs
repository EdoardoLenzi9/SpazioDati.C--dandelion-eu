using System;
using System.Collections.Generic;
using FactoryMind.TrackMe.Test;
using SpazioDati.Dandelion.Business.Services;
using SpazioDati.Dandelion.Domain.Models;
using Xunit;

namespace SpazioDati.Dandelion.Test.ValidationTests
{
    public class TextClassificationValidationTests : IClassFixture<ServiceFixture>
    {
        private ServiceFixture _fixture;
        private TextClassificationService _textClassificationService;

        public TextClassificationValidationTests(ServiceFixture fixture)
        {
            _fixture = fixture;
            _textClassificationService = fixture.TextClassificationService;
        }

        [Theory]
        [MemberData(nameof(GetParameters))]
        public async void Should_ThrowException_When_CallTextClassificationWithWrongParameters(TextClassificationParameters parameters, string message, string wrongParameter)
        {
            //Act & Assert

            ArgumentException ex = await Assert.ThrowsAsync<ArgumentException>(() => _textClassificationService.CallTextClassificationAsync(parameters));
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
            yield return new object[] { new TextClassificationParameters(), ErrorMessages.WrongSource, "" };
            yield return new object[] { new TextClassificationParameters { Text = "Text", MinScore = -1 }, ErrorMessages.WrongMinScore, ErrorMessages.MinScore };
            yield return new object[] { new TextClassificationParameters { Text = "Text", MinScore = 2 }, ErrorMessages.WrongMinScore, ErrorMessages.MinScore };
            yield return new object[] { new TextClassificationParameters { Text = "Text", MaxAnnotations = 0 }, ErrorMessages.WrongMaxAnnotations, ErrorMessages.MaxAnnotations };
            yield return new object[] { new TextClassificationParameters { Text = "Text", Include = new List<IncludeOption>() { IncludeOption.image } }, ErrorMessages.WrongInclude2, ErrorMessages.Include };
        }
    }
}
