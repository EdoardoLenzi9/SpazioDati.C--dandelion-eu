using SpazioDati.Dandelion.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;

namespace SpazioDati.Dandelion.Business.Services
{
    public class WikisearchService
    {
        private ApiClient _apiClient;

        public WikisearchService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<WikisearchDto> CallWikisearchAsync(WikisearchParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentException(ErrorMessages.MissingParameters);
            }
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