using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpazioDati.Dandelion.Models;
using SpazioDati.Dandelion.Services;

namespace SpazioDati.Dandelion
{
    class Dandelion
    {

        static void Main(string[] args)
        {
            MainAsync();
            Console.ReadLine();
        }

        public static async void MainAsync()
        {
            Console.WriteLine(JsonConvert.SerializeObject(await GetEntitiesAsync(new EntityExtractionParameters{Text = "hello world", Lang = LanguageOption.fr})));
        }

        public static void SetToken(string token){ //need more security, dependency injection
            if(String.IsNullOrEmpty(token) && String.IsNullOrEmpty(Localizations.Token))         //cambiare metodi statici
            {
                throw new ArgumentException("Invalid token", "token");
            }
            if(!String.IsNullOrEmpty(token))
            {
                Localizations.Token = token;
            }
        }

        public static Task<EntityExtractionDto> GetEntitiesAsync (EntityExtractionParameters parameters, string token = "")
        {
            SetToken(token);
            return EntityExtractionService.CallEntityExtractionAsync(parameters);
        }

        public static Task<TextSimilarityDto> GetSimilaritiesAsync (TextSimilarityParameters parameters, string token = "")
        {
            SetToken(token);
            return TextSimilarityService.CallTextSimilaritiesAsync(parameters);
        }

        public static Task<TextClassificationDto> ClassifyTextAsync (TextClassificationParameters parameters, string token = "")
        {
            SetToken(token);
            return TextClassificationService.CallTextClassificationAsync(parameters);
        }

        public static Task<LanguageDetectionDto> DetectLanguageAsync (LanguageDetectionParameters parameters, string token = "")
        {
            SetToken(token);
            return LanguageDetectionService.CallLanguageDetectionAsync(parameters);
        }

        public static Task<SentimentAnalysisDto> AnalyzeSentimentsAsync (SentimentAnalysisParameters parameters, string token = "")
        {
            SetToken(token);
            return SentimentAnalysisService.CallSentimentAnalysisAsync(parameters);
        }

        public static Task<WikisearchDto> GetWikiSearchAsync (WikisearchParameters parameters, string token = "")
        {
            SetToken(token);
            return WikisearchService.CallWikisearchAsync(parameters);
        }

    }
}
