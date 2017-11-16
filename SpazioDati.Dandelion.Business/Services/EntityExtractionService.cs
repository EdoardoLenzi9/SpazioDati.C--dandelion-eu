using SpazioDati.Dandelion.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;
using SpazioDati.Dandelion.Business.Extensions;
using System.Net.Http;

namespace SpazioDati.Dandelion.Business.Services
{
    public class EntityExtractionService
    {
        private ApiClient _apiClient;

        public EntityExtractionService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<EntityExtractionDto> CallEntityExtractionAsync(EntityExtractionParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentException(ErrorMessages.MissingParameters);
            }
            if (parameters.Epsilon < 0.0 || parameters.Epsilon > 0.5)
            {
                throw new ArgumentException(ErrorMessages.WrongEpsilon, ErrorMessages.Epsilon);
            }
            if (parameters.TopEntities < 0)
            {
                throw new ArgumentException(ErrorMessages.WrongTopEntities, ErrorMessages.TopEntities);
            }
            if (parameters.MinConfidence < 0.0 || parameters.MinConfidence > 1.0)
            {
                throw new ArgumentException(ErrorMessages.WrongMinConfidence, ErrorMessages.MinConfidence);
            }
            if (parameters.MinLength < 2)
            {
                throw new ArgumentException(ErrorMessages.WrongMinLength, ErrorMessages.MinLength);
            }
            if (parameters.Include != null)
            {
                if (parameters.Include.FindAll(x => x == IncludeOption.score_details).ToList().Count > 0)
                {
                    throw new ArgumentException(ErrorMessages.WrongInclude1, ErrorMessages.Include);
                }
            }
            if (parameters.Include.hasDuplicates<IncludeOption>())
            {
                parameters.Include = parameters.Include.Distinct().ToList();
            }
            if (parameters.ExtraTypes.hasDuplicates<ExtraTypesOption>())
            {
                parameters.ExtraTypes = parameters.ExtraTypes.Distinct().ToList();
            }

            var source = SourceValidationService.verifySingleSource(parameters);
            return _apiClient.CallApiAsync<EntityExtractionDto>(ApiClient.EntityExtractionUriBuilder(), ApiClient.EntityExtractionContentBuilder(source, parameters));
        }
    }
}