using System;
using System.Collections.Generic;
using FactoryMind.TrackMe.Test;
using SpazioDati.Dandelion.Business.Services;
using SpazioDati.Dandelion.Domain.Models;
using Xunit;

namespace SpazioDati.Dandelion.Test.ValidationTests
{
    public class EntityExtractionValidationTests : IClassFixture<ServiceFixture>
    {
        private ServiceFixture _fixture;
        private EntityExtractionService _entityExtractionService;

        public EntityExtractionValidationTests(ServiceFixture fixture)  
        {
            _fixture = fixture;
            _entityExtractionService = fixture.EntityExtractionService;
        }

        [Theory]
        [MemberData(nameof(GetParameters))]
        public async void Should_ThrowException_When_CallEntityExtractionWithWrongParameters(EntityExtractionParameters parameters, string message, string wrongParameter)
        {
            //Act & Assert

            ArgumentException ex = await Assert.ThrowsAsync<ArgumentException>(() => _entityExtractionService.CallEntityExtractionAsync(parameters));
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
            yield return new object[] { new EntityExtractionParameters(), ErrorMessages.WrongSource, "" };
            yield return new object[] { new EntityExtractionParameters { Text = "Text", Epsilon = -1 }, ErrorMessages.WrongEpsilon, ErrorMessages.Epsilon };
            yield return new object[] { new EntityExtractionParameters { Text = "Text", Epsilon = 1 }, ErrorMessages.WrongEpsilon, ErrorMessages.Epsilon };
            yield return new object[] { new EntityExtractionParameters { Text = "Text", TopEntities = -1 }, ErrorMessages.WrongTopEntities, ErrorMessages.TopEntities };
            yield return new object[] { new EntityExtractionParameters { Text = "Text", MinConfidence = -1 }, ErrorMessages.WrongMinConfidence, ErrorMessages.MinConfidence };
            yield return new object[] { new EntityExtractionParameters { Text = "Text", MinConfidence = 2 }, ErrorMessages.WrongMinConfidence, ErrorMessages.MinConfidence };
            yield return new object[] { new EntityExtractionParameters { Text = "Text", MinLength = 1 }, ErrorMessages.WrongMinLength, ErrorMessages.MinLength };
            yield return new object[] { new EntityExtractionParameters { Text = "Text", Include = new List<IncludeOption> { IncludeOption.score_details } }, ErrorMessages.WrongInclude1, ErrorMessages.Include };
        }
    }
}
