using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpazioDati.Dandelion.Models;

namespace SpazioDati.Dandelion.Repositories
{
    public class EntityExtractionRepository
    {

        private static EntityExtractionParameters _defaultValues = new EntityExtractionParameters{
                                                                                            Lang = Language.auto, 
                                                                                            TopEntities = 0, 
                                                                                            MinConfidence = 0.6F,
                                                                                            MinLength = 2, 
                                                                                            SocialHashtag = false,  
                                                                                            SocialMention = false,
                                                                                            Include = null,
                                                                                            ExtraTypes = null,
                                                                                            Country = null,
                                                                                            CustomSpots = ""
                                                                                        };  

        public static Task<EntitiesDto> GetEntitiesByTextAsync (EntityExtractionParameters parameters)
        {
            return CallApiAsync<EntitiesDto>(UrlBuilder($"text={parameters.Text}", parameters));
        }

        public static Task<EntitiesDto> GetEntitiesByUrlAsync (EntityExtractionParameters parameters)
        {
            return CallApiAsync<EntitiesDto>(UrlBuilder($"url={parameters.Url}", parameters));
        }

        public static Task<EntitiesDto> GetEntitiesByHtmlAsync (EntityExtractionParameters parameters)
        {
            return CallApiAsync<EntitiesDto>(UrlBuilder($"html={parameters.Html}", parameters));
        }

        public static Task<EntitiesDto> GetEntitiesByHtmlFragmentAsync (EntityExtractionParameters parameters)
        {
            return CallApiAsync<EntitiesDto>(UrlBuilder($"html_fragment={parameters.HtmlFragment}", parameters));
        }
        
        private static string UrlBuilder(string source, EntityExtractionParameters parameters){
            var url = $"{Localizations.BaseUrl}/{Localizations.DataTxt}/{Localizations.EntityExtractionUri}?token={Localizations.Token}&{source}";
            if(parameters.Lang != Language.auto)
            {
                url = $"{url}&lang={parameters.Lang}";
            }
            if(parameters.TopEntities != _defaultValues.TopEntities)
            {
                url = $"{url}&top_entities={parameters.TopEntities}";
            }
            if(parameters.MinConfidence != _defaultValues.MinConfidence)
            {
                url = $"{url}&min_confidence={parameters.MinConfidence}";
            }
            if(parameters.SocialHashtag != _defaultValues.SocialHashtag)
            {
                url = $"{url}&social.hashtag={parameters.SocialHashtag}";
            }
            if(parameters.SocialMention != _defaultValues.SocialMention)
            {
                url = $"{url}&social.mention={parameters.SocialMention}";
            }
            if(parameters.Include != _defaultValues.Include)
            {
                url = $"{url}&include={parameters.Include}";
            }
            if(parameters.ExtraTypes != _defaultValues.ExtraTypes)
            {
                url = $"{url}&extra_types={parameters.ExtraTypes}";
            }
            if(parameters.Country != _defaultValues.Country)
            {
                url = $"{url}&country={parameters.Country}";
            }
            if(parameters.CustomSpots != _defaultValues.CustomSpots)
            {
                url = $"{url}&custom_spots={parameters.CustomSpots}";
            }
            return url;
        }

        public static Task<T> CallApiAsync<T>(string Url){ //TODO move to a general service class
            return Task.Run( async () =>  
            {
                var client = new HttpClient();
                var result = await client.GetStringAsync(Url);
                return JsonConvert.DeserializeObject<T>(result);
            });
        }
    }
}