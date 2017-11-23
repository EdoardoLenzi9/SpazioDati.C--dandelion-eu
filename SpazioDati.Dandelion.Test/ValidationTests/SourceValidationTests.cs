using System;
using System.Collections.Generic;
using FactoryMind.TrackMe.Test;
using SpazioDati.Dandelion.Business.Services;
using SpazioDati.Dandelion.Domain.Models;
using Xunit;

namespace SpazioDati.Dandelion.Test.ValidationTests
{
    public class SourceValidationTests : IClassFixture<ServiceFixture>
    {

        [Theory]
        [MemberData(nameof(GetSingleSourceParameters))]
        public void Should_ThrowException_When_CallVerifySingleSourceWithWrongParameters(SourceParameters parameters, string message, string wrongParameter)
        {
            //Act & Assert

            ArgumentException ex = Assert.Throws<ArgumentException>(() => SourceValidationService.verifySingleSource(parameters));
            if (String.IsNullOrEmpty(wrongParameter))
            {
                Assert.Equal(message, ex.Message);
            }
            else
            {
                Assert.Equal($"{message}{Environment.NewLine}Parameter name: {wrongParameter}", ex.Message);
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_ThrowException_When_CallWikisearchWithWrongTextSource(string Text)
        {
            //Arrange
            var parameters = new WikisearchParameters { Token = "Token", Text = Text };

            //Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => SourceValidationService.verifySingleSource(parameters));
            Assert.Equal($"{ErrorMessages.WrongText}{Environment.NewLine}Parameter name: {ErrorMessages.Text}", ex.Message);
        }

        [Theory]
        [MemberData(nameof(GetMultipleSourcesParameters))]
        public void Should_ThrowException_When_CallVerifyMultipleSourcesWithWrongParameters(TextSimilarityParameters parameters, string message, string wrongParameter)
        {
            //Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => SourceValidationService.verifyMultipleSources(parameters));
            if (String.IsNullOrEmpty(wrongParameter))
            {
                Assert.Equal(message, ex.Message);
            }
            else
            {
                Assert.Equal($"{message}{Environment.NewLine}Parameter name: {wrongParameter}", ex.Message);
            }
        }

        public static IEnumerable<object[]> GetMultipleSourcesParameters()
        {
            yield return new object[] { new TextSimilarityParameters { Token = "Token" }, ErrorMessages.WrongSources, "" };
            yield return new object[] { new TextSimilarityParameters { Token = "Token", Text2 = "Text", Text1 = "Text", Url1 = "https://www.google.it" }, ErrorMessages.WrongSource1, ErrorMessages.Url1 };
            yield return new object[] { new TextSimilarityParameters { Token = "Token", Text2 = "Text", Text1 = "Text", Html1 = "<html><body><p>Html Text</p></body></html>" }, ErrorMessages.WrongSource1, ErrorMessages.Html1 };
            yield return new object[] { new TextSimilarityParameters { Token = "Token", Text2 = "Text", Text1 = "Text", HtmlFragment1 = "<p> Html Text </p>" }, ErrorMessages.WrongSource1, ErrorMessages.HtmlFragment1 };
            yield return new object[] { new TextSimilarityParameters { Token = "Token", Text2 = "Text", Url1 = "https://www.google.it", Html1 = "<html><body><p>Html Text</p></body></html>" }, ErrorMessages.WrongSource1, ErrorMessages.Html1 };
            yield return new object[] { new TextSimilarityParameters { Token = "Token", Text2 = "Text", Url1 = "https://www.google.it", HtmlFragment1 = "<p> Html Text </p>" }, ErrorMessages.WrongSource1, ErrorMessages.HtmlFragment1 };
            yield return new object[] { new TextSimilarityParameters { Token = "Token", Text2 = "Text", HtmlFragment1 = "<p> Html Text </p>", Html1 = "<html><body><p>Html Text</p></body></html>" }, ErrorMessages.WrongSource1, ErrorMessages.HtmlFragment1 };
            yield return new object[] { new TextSimilarityParameters { Token = "Token", Text1 = "Text", Text2 = "Text", Url2 = "https://www.google.it" }, ErrorMessages.WrongSource2, ErrorMessages.Url2 };
            yield return new object[] { new TextSimilarityParameters { Token = "Token", Text1 = "Text", Text2 = "Text", Html2 = "<html><body><p>Html Text</p></body></html>" }, ErrorMessages.WrongSource2, ErrorMessages.Html2 };
            yield return new object[] { new TextSimilarityParameters { Token = "Token", Text1 = "Text", Text2 = "Text", HtmlFragment2 = "<p> Html Text </p>" }, ErrorMessages.WrongSource2, ErrorMessages.HtmlFragment2 };
            yield return new object[] { new TextSimilarityParameters { Token = "Token", Text1 = "Text", Url2 = "https://www.google.it", Html2 = "<html><body><p>Html Text</p></body></html>" }, ErrorMessages.WrongSource2, ErrorMessages.Html2 };
            yield return new object[] { new TextSimilarityParameters { Token = "Token", Text1 = "Text", Url2 = "https://www.google.it", HtmlFragment2 = "<p> Html Text </p>" }, ErrorMessages.WrongSource2, ErrorMessages.HtmlFragment2 };
            yield return new object[] { new TextSimilarityParameters { Token = "Token", Text1 = "Text", HtmlFragment2 = "<p> Html Text </p>", Html2 = "<html><body><p>Html Text</p></body></html>" }, ErrorMessages.WrongSource2, ErrorMessages.HtmlFragment2 };
        }

        public static IEnumerable<object[]> GetSingleSourceParameters()
        {
            yield return new object[] { new SourceParameters { Token = "Token" } , ErrorMessages.WrongSource, "" };
            yield return new object[] { new SourceParameters { Token = "Token", Text = "Text", Url = "https://www.google.it" }, ErrorMessages.MultipleSources, ErrorMessages.Url };
            yield return new object[] { new SourceParameters { Token = "Token", Text = "Text", Html = "<html><body><p>Html Text</p></body></html>" }, ErrorMessages.MultipleSources, ErrorMessages.Html };
            yield return new object[] { new SourceParameters { Token = "Token", Text = "Text", HtmlFragment = "<p> Html Text </p>" }, ErrorMessages.MultipleSources, ErrorMessages.HtmlFragment };
            yield return new object[] { new SourceParameters { Token = "Token", Url = "https://www.google.it", Html = "<html><body><p>Html Text</p></body></html>" }, ErrorMessages.MultipleSources, ErrorMessages.Html };
            yield return new object[] { new SourceParameters { Token = "Token", Url = "https://www.google.it", HtmlFragment = "<p> Html Text </p>" }, ErrorMessages.MultipleSources, ErrorMessages.HtmlFragment };
            yield return new object[] { new SourceParameters { Token = "Token", HtmlFragment = "<p> Html Text </p>", Html = "<html><body><p>Html Text</p></body></html>" }, ErrorMessages.MultipleSources, ErrorMessages.HtmlFragment };
            yield return new object[] { new SourceParameters { Token = "Token", Text = "<p> Html Text </p>", Html = "<html><body><p>Html Text</p></body></html>" }, ErrorMessages.MultipleSources, ErrorMessages.Html };
        }
    }
}
