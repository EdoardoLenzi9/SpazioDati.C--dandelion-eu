using System.Collections.Generic;
using SpazioDati.Dandelion.Models;
using System;
using SpazioDati.Dandelion.Extensions;
using System.Linq;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Clients;

namespace SpazioDati.Dandelion.Services
{
    public class LanguageDetectionService
    {

        public static Task<LanguageDetectionDto> CallLanguageDetectionAsync (LanguageDetectionParameters parameters)
        {            
            var source = SourceValidation.verifySingleSource(parameters);
            return ApiClient.CallApiAsync<LanguageDetectionDto>(ApiClient.LanguageDetectionUrlBuilder(source, parameters));
        }
        
    }
}