using SpazioDati.Dandelion.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Business.Clients;
using SpazioDati.Dandelion.Business.Extensions;

namespace SpazioDati.Dandelion.Business.Services
{
    public class EntityExtractionService
    {
        private ApiClient _apiClient;

        public EntityExtractionService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<EntityExtractionDto> CallEntityExtractionAsync (EntityExtractionParameters parameters)
        {  
            if(parameters.Epsilon < 0.0 || parameters.Epsilon > 0.5){
                throw new ArgumentException("Epsilon must be between 0.0 and 0.5", "Epsilon");
            }          
            if(parameters.TopEntities < 0)
            {
                throw new ArgumentException("TopEntities cannot be negative", "TopEntities");
            }
            if(parameters.MinConfidence < 0.0 || parameters.MinConfidence > 1.0)
            {
                throw new ArgumentException("MinConfidence must be between 0.0 and 1.0", "MinConfidence");
            }
            if(parameters.MinLength<2)
            {
                throw new ArgumentException("MinLength must be greater then 1", "MinLength");
            }
            if(parameters.Include != null)
            {
                if(parameters.Include.FindAll(x => x == IncludeOption.score_details).ToList().Count > 0)
                {
                    throw new ArgumentException("Include cannot assume score_details value", "Include");
                }       
            }
            if(parameters.Include.hasDuplicates<IncludeOption>())
            {
                parameters.Include = parameters.Include.Distinct().ToList();
            }
            if(parameters.ExtraTypes.hasDuplicates<ExtraTypesOption>())
            {
                 parameters.ExtraTypes = parameters.ExtraTypes.Distinct().ToList();
            }

            var source = SourceValidation.verifySingleSource(parameters);
            return _apiClient.CallApiAsync<EntityExtractionDto>(ApiClient.EntityExtractionUrlBuilder(source, parameters));
        }
    }
}