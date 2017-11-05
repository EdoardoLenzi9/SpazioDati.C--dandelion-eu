using System.Collections.Generic;
using SpazioDati.Dandelion.Models;
using System;
using SpazioDati.Dandelion.Extensions;
using System.Linq;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Clients;

namespace SpazioDati.Dandelion.Services
{
    public class WikisearchService
    {

        public static Task<WikisearchDto> CallWikisearchAsync (WikisearchParameters parameters)
        {    
            if(parameters.Include != null)
            {
                if(parameters.Include.FindAll(x => x == IncludeOption.score_details).ToList().Count > 0)
                {
                    throw new ArgumentException("Include cannot assume score_details value", "Include");
                }       
            }
            if(parameters.Lang == LanguageOption.auto)
            {
                throw new ArgumentException("Lang cannot assume value auto", "Lang");
            }
            if(String.IsNullOrEmpty(parameters.Text))
            {
                throw new ArgumentException("Text must be set", "Text");
            }
            if(parameters.Limit < 1 || parameters.Limit > 50 )
            {
                throw new ArgumentException("Limit must be between 1 and 50", "Limit");
            }

            var source = $"&text={parameters.Text}";
            return ApiClient.CallApiAsync<WikisearchDto>(ApiClient.WikisearchUrlBuilder(source, parameters));
        }
        
    }
}