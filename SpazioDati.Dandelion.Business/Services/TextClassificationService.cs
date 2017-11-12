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

        public Task<TextClassificationDto> CallTextClassificationAsync (TextClassificationParameters parameters) 
        {            
            //TODO controllo models https://dandelion.eu/docs/api/datatxt/cl/models/v1/
            if(parameters.MinScore < 0.0 || parameters.MinScore > 1.0)
            {
                throw new ArgumentException("MinScore must be between 0.0 and 1.0", "MinScore");
            }
            if(parameters.MaxAnnotations < 1) 
            {
                throw new ArgumentException("MaxAnnotations must be greater than 0", "MaxAnnotations");
            }
            if(parameters.Include != null)
            {
                if(parameters.Include.FindAll(x => x != IncludeOption.score_details).ToList().Count > 0)
                {
                    throw new ArgumentException("Include can assume only score_details value", "Include");
                }       
            }
            var source = SourceValidation.verifySingleSource(parameters);
            return _apiClient.CallApiAsync<TextClassificationDto>(ApiClient.TextClassificationUrlBuilder(source, parameters));
        }
    }
}