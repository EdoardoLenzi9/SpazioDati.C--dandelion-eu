using SpazioDati.Dandelion.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;
using SpazioDati.Dandelion.Business.Extensions;

namespace SpazioDati.Dandelion.Business.Services
{
    /// <summary> 
    ///     Services class that parse the user parameters and call the <c>client</c> 
    /// </summary>
    /// <seealso cref="ApiClient"/> 
    public class EntityExtractionService
    {
        private ApiClient _apiClient;

        public EntityExtractionService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary> 
        ///     Asyncronous method that validate the user parameters and call <c>ApiClient</c>       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns a <c>EntityExtractionDto</c> populated with the result of the call </returns>
        /// <seealso cref="EntityExtractionDto"/> 
        public Task<EntityExtractionDto> CallEntityExtractionAsync(EntityExtractionParameters parameters)
        {
            ValidateParameters(parameters);
            var source = SourceValidationService.verifySingleSource(parameters);
            return _apiClient.CallApiAsync<EntityExtractionDto>(ApiClient.EntityExtractionUriBuilder(), ApiClient.EntityExtractionContentBuilder(source, parameters), parameters.HttpMethod);
        }

        /// <summary> 
        ///     Asyncronous method that validate the <c>EntityExtractionParameters</c> and <c>TextSimilarityParameters</c> in <see href="https://dandelion.eu/docs/api/datatxt/sim/v1/">special cases</see>         
        /// </summary>
        /// <param name="parameters"></param>
        public static void ValidateParameters(EntityExtractionParameters parameters) {
            ServiceUtils.ParameterValidation(parameters);
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
            if (parameters.Include.hasDuplicates())
            {
                parameters.Include = parameters.Include.Distinct().ToList();
            }
            if (parameters.ExtraTypes.hasDuplicates())
            {
                parameters.ExtraTypes = parameters.ExtraTypes.Distinct().ToList();
            }
        }
    }
}