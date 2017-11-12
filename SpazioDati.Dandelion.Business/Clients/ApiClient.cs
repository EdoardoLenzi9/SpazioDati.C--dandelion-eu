using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpazioDati.Dandelion.Domain.Models;

namespace SpazioDati.Dandelion.Business.Clients
{
    public class ApiClient
    {

        public static void Init()
        {
            var container =  new SimpleInjector.Container();
            container.Register<ApiClient>(SimpleInjector.Lifestyle.Singleton);
        }
      
        public static string EntityExtractionUrlBuilder(string source, EntityExtractionParameters parameters){
            var url = $"{Localizations.BaseUrl}/{Localizations.DataTxt}/{Localizations.EntityExtractionUri}?token={Localizations.Token}&{source}";
            if(parameters.Lang != DefaultValues.Lang)
            {
                url = $"{url}&lang={parameters.Lang}";
            }
            if(parameters.TopEntities != DefaultValues.TopEntities)
            {
                url = $"{url}&top_entities={parameters.TopEntities}";
            }
            if(parameters.MinConfidence != DefaultValues.MinConfidence)
            {
                url = $"{url}&min_confidence={parameters.MinConfidence}";
            }
            if(parameters.SocialHashtag != DefaultValues.SocialHashtag)
            {
                url = $"{url}&social.hashtag={parameters.SocialHashtag}";
            }
            if(parameters.SocialMention != DefaultValues.SocialMention)
            {
                url = $"{url}&social.mention={parameters.SocialMention}";
            }
            if(parameters.Include != DefaultValues.Include)
            {
                url = $"{url}&include={parameters.Include}";
            }
            if(parameters.ExtraTypes != DefaultValues.ExtraTypes)
            {
                url = $"{url}&extra_types={parameters.ExtraTypes}";
            }
            if(parameters.Country != null)
            {
                url = $"{url}&country={parameters.Country}";
            }
            if(parameters.CustomSpots != DefaultValues.CustomSpots)
            {
                url = $"{url}&custom_spots={parameters.CustomSpots}";
            }
            return url;
        }

        public static string TextSimilarityUrlBuilder(string source, TextSimilarityParameters parameters){
            var url = $"{Localizations.BaseUrl}/{Localizations.DataTxt}/{Localizations.TextSimilarity}?token={Localizations.Token}&{source}";
            if(parameters.Lang != DefaultValues.Lang)
            {
                url = $"{url}&lang={parameters.Lang}";
            }
            if(parameters.Bow != DefaultValues.Bow)
            {
                url = $"{url}&top_entities={parameters.Bow}";
            }
            return url;
        }

        public static string TextClassificationUrlBuilder(string source, TextClassificationParameters parameters){
            var url = $"{Localizations.BaseUrl}/{Localizations.DataTxt}/{Localizations.TextSimilarity}?token={Localizations.Token}&{source}&model={parameters.Model}";
            if(parameters.MinScore != DefaultValues.MinScore)
            {
                url = $"{url}&min_score={parameters.MinScore}";
            }
            if(parameters.MaxAnnotations != DefaultValues.MaxAnnotations)
            {
                url = $"{url}&max_annotations={parameters.MaxAnnotations}";
            }
            if(parameters.Include != DefaultValues.Include) //TODO refact ogni lista
            {
                url = $"{url}&include={parameters.Include}";
            }
            return url;
        }

        public static string LanguageDetectionUrlBuilder(string source, LanguageDetectionParameters parameters){
            var url = $"{Localizations.BaseUrl}/{Localizations.DataTxt}/{Localizations.LanguageDetection}?token={Localizations.Token}&{source}";
            if(parameters.Clean != DefaultValues.Clean)
            {
                url = $"{url}&clean={parameters.Clean}";
            }
            return url;
        }

        public static string SentimentAnalysisUrlBuilder(string source, SentimentAnalysisParameters parameters){
            var url = $"{Localizations.BaseUrl}/{Localizations.DataTxt}/{Localizations.SentimentAnalysis}?token={Localizations.Token}&{source}";
            if(parameters.Lang != DefaultValues.Lang)
            {
                url = $"{url}&lang={parameters.Lang}";
            }
            return url;
        }

        public static string WikisearchUrlBuilder(string source, WikisearchParameters parameters){
            var url = $"{Localizations.BaseUrl}/{Localizations.Datagraph}/{Localizations.WikiSearch}/?token={Localizations.Token}&{source}&lang={parameters.Lang}";
            if(parameters.Limit != DefaultValues.Limit)
            {
                url = $"{url}&limit={parameters.Limit}";
            }
            if(parameters.Offset != DefaultValues.Offset)
            {
                url = $"{url}&offset={parameters.Offset}";
            }
            if(parameters.Query != DefaultValues.Query)
            {
                url = $"{url}&query={parameters.Query}";
            }
            if(parameters.Include != DefaultValues.Include)
            {
                url = $"{url}&include={parameters.Include}";
            }
            return url;
        }

        public Task<T> CallApiAsync<T>(string Url){
            return Task.Run( async () =>  
            {
                var client = new HttpClient();
                var result = await client.GetStringAsync(Url);
                return JsonConvert.DeserializeObject<T>(result); //TODO guardare status code http call
            });
        }
    }
}