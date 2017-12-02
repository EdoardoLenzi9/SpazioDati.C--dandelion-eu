using SpazioDati.Dandelion.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;

namespace SpazioDati.Dandelion.Business.Services
{
    /// <summary> 
    ///     Services class that parse the user parameters and call the <c>client</c> 
    /// </summary>
    /// <seealso cref="ApiClient"/> 
    public class WikisearchService
    {
        private ApiClient _apiClient;

        public WikisearchService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary> 
        ///     Asyncronous method that validate the user parameters and call <c>ApiClient</c>       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns a <c>WikisearchDto</c> populated with the result of the call </returns>
        /// <seealso cref="WikisearchDto"/> 
        public Task<WikisearchDto> CallWikisearchAsync(WikisearchParameters parameters)
        {
            ServiceUtils.ParameterValidation(parameters);
            if (parameters.Include != null)
            {
                if (parameters.Include.FindAll(x => x == IncludeOption.score_details).ToList().Count > 0)
                {
                    throw new ArgumentException(ErrorMessages.WrongInclude1, ErrorMessages.Include);
                }
            }
            if (parameters.Lang == LanguageOption.auto)
            {
                throw new ArgumentException(ErrorMessages.WrongLang2, ErrorMessages.Lang);
            }
            if (parameters.Limit < 1 || parameters.Limit > 50)
            {
                throw new ArgumentException(ErrorMessages.WrongLimit, ErrorMessages.Limit);
            }

            var source = SourceValidationService.verifySingleSource(parameters);
            return _apiClient.CallApiAsync<WikisearchDto>(ApiClient.WikisearchUriBuilder(), ApiClient.WikisearchContentBuilder(source, parameters), parameters.HttpMethod);
        }
    }
}