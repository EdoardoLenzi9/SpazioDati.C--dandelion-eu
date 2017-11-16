using System;
using System.Linq;
using SpazioDati.Dandelion.Domain.Models;
using SpazioDati.Dandelion.Business.Clients;
using System.Threading.Tasks;

namespace SpazioDati.Dandelion.Business.Services
{
    public class TextClassificationService
    {
        private ApiClient _apiClient;

        public TextClassificationService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<TextClassificationDto> CallTextClassificationAsync(TextClassificationParameters parameters)
        {
            //TODO controllo models https://dandelion.eu/docs/api/datatxt/cl/models/v1/
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
            var source = SourceValidation.verifySingleSource(parameters);
            return _apiClient.CallApiAsync<TextClassificationDto>(ApiClient.TextClassificationUriBuilder(), ApiClient.TextClassificationContentBuilder(source, parameters));

        }
    }
}