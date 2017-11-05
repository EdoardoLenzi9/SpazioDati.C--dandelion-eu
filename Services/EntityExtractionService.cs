using System.Collections.Generic;
using SpazioDati.Dandelion.Models;
using System;
using SpazioDati.Dandelion.Extensions;
using System.Linq;
using SpazioDati.Dandelion.Repositories;
using System.Threading.Tasks;

namespace SpazioDati.Dandelion.Services
{
    public class EntityExtractionService
    {

        public static Task<EntitiesDto> GetEntitiesAsync (EntityExtractionParameters parameters)
        {            
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
            
            if(parameters.Include.hasDuplicates<IncludeOption>())
            {
                parameters.Include = parameters.Include.Distinct().ToList();
            }

            if(parameters.ExtraTypes.hasDuplicates<ExtraTypesOption>())
            {
                 parameters.ExtraTypes = parameters.ExtraTypes.Distinct().ToList();
            }

            if(!String.IsNullOrWhiteSpace(parameters.Text))
            {
                return EntityExtractionRepository.GetEntitiesByTextAsync(parameters);
            }
            else if(!String.IsNullOrWhiteSpace(parameters.Url))
            {
                if(!Uri.IsWellFormedUriString(parameters.Url, UriKind.RelativeOrAbsolute))
                {
                    throw new ArgumentException("Not well formed Url", "Url"); //TODO use inner exception
                } 
                else 
                {
                    return EntityExtractionRepository.GetEntitiesByUrlAsync(parameters);
                }
            }
            else if(!String.IsNullOrWhiteSpace(parameters.Html))
            {
                return EntityExtractionRepository.GetEntitiesByHtmlAsync(parameters);
            }
            else if(!String.IsNullOrWhiteSpace(parameters.HtmlFragment))
            {
                return EntityExtractionRepository.GetEntitiesByHtmlFragmentAsync(parameters);
            }
            else 
            {            
                throw new ArgumentException("At least one filed between Text, Url, Html and HtmlFragment must be set"); 
            }
        }

    }
}