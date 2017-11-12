using System.Collections.Generic;
using SpazioDati.Dandelion.Models;
using System;
using SpazioDati.Dandelion.Extensions;
using System.Linq;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Clients;

namespace SpazioDati.Dandelion.Services
{
    public class SentimentAnalysisService
    {

        public static Task<SentimentAnalysisDto> CallSentimentAnalysisAsync (SentimentAnalysisParameters parameters)
        {            
            if(parameters.Lang != LanguageOption.en && parameters.Lang != LanguageOption.it && parameters.Lang != LanguageOption.auto)
            {
                throw new ArgumentException("Lang can assume only en | it | auto values", "Lang");
            }
            var source = SourceValidation.verifySingleSource(parameters);
            return ApiClient.CallApiAsync<SentimentAnalysisDto>(ApiClient.SentimentAnalysisUrlBuilder(source, parameters));
        }
        
    }
}