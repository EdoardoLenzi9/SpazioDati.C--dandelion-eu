using System;
using System.Linq;
using SpazioDati.Dandelion.Domain.Models;
using SpazioDati.Dandelion.Business.Clients;
using System.Threading.Tasks;

namespace SpazioDati.Dandelion.Business.Services
{
    /// <summary> 
    ///     Services class that parse the user parameters and call the <c>client</c> 
    /// </summary>
    /// <seealso cref="ApiClient"/> 
    public class TextClassificationService
    {
        private ApiClient _apiClient;

        public TextClassificationService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary> 
        ///     Asyncronous method that validate the user parameters and call <c>ApiClient</c>       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns a <c>TextClassificationDto</c> populated with the result of the call </returns>
        /// <seealso cref="TextClassificationDto"/> 
        public Task<TextClassificationDto> CallTextClassificationAsync(TextClassificationParameters parameters)
        {
            ServiceUtils.ParameterValidation(parameters);
            if (parameters.MinScore < 0.0 || parameters.MinScore > 1.0)
            {
                throw new ArgumentException(ErrorMessages.WrongMinScore, ErrorMessages.MinScore);
            }
            if (parameters.MaxAnnotations < 1)
            {
                throw new ArgumentException(ErrorMessages.WrongMaxAnnotations, ErrorMessages.MaxAnnotations);
            }
            if (parameters.Include != null)
            {
                if (parameters.Include.FindAll(x => x != IncludeOption.score_details).ToList().Count > 0)
                {
                    throw new ArgumentException(ErrorMessages.WrongInclude2, ErrorMessages.Include);
                }
            }
            var source = SourceValidationService.verifySingleSource(parameters);
            return _apiClient.CallApiAsync<TextClassificationDto>(ApiClient.TextClassificationUriBuilder(), ApiClient.TextClassificationContentBuilder(source, parameters), parameters.HttpMethod);

        }
    }
}