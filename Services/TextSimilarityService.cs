using System.Collections.Generic;
using SpazioDati.Dandelion.Models;
using System;
using SpazioDati.Dandelion.Extensions;
using System.Linq;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Clients;

namespace SpazioDati.Dandelion.Services
{
    public class TextSimilarityService
    {

        public static Task<TextSimilarityDto> CallTextSimilaritiesAsync (TextSimilarityParameters parameters)
        {            
            var source = SourceValidation.verifyMultipleSources(parameters);
            return ApiClient.CallApiAsync<TextSimilarityDto>(ApiClient.TextSimilarityUrlBuilder(source, parameters));
        }
        
    }
}