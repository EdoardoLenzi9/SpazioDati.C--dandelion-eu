using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpazioDati.Dandelion.Domain.Models;
using SpazioDati.Dandelion.Business.Extensions;
using SimpleInjector;
using System;
using System.Collections.Generic;

namespace SpazioDati.Dandelion.Business.Clients
{
    public class ApiClient
    {
        private static Container _container;
        private HttpClient _client;

        public ApiClient()
        {
            _client = new HttpClient();
        }

        public static void Init()
        {
            if (_container == null)
            {
                _container = _container.GetInstance();
                _container.Register<ApiClient>(Lifestyle.Singleton);
            }
        }

        public static List<KeyValuePair<string, string>> EntityExtractionContentBuilder(string source, EntityExtractionParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();

            content.Add(new KeyValuePair<string, string>("token", Localizations.Token));
            content.Add(new KeyValuePair<string, string>("text", parameters.Text));
            if (parameters.Lang != DefaultValues.Lang)
            {
                content.Add(new KeyValuePair<string, string>("lang", $"{parameters.Lang}"));
            }
            if (parameters.TopEntities != DefaultValues.TopEntities)
            {
                content.Add(new KeyValuePair<string, string>("top_entities", $"{parameters.TopEntities}"));
            }
            if (parameters.MinConfidence != DefaultValues.MinConfidence)
            {
                content.Add(new KeyValuePair<string, string>("min_confidence", $"{parameters.MinConfidence}"));
            }
            if (parameters.SocialHashtag != DefaultValues.SocialHashtag)
            {
                content.Add(new KeyValuePair<string, string>("social.hashtag", $"{parameters.SocialHashtag}"));
            }
            if (parameters.SocialMention != DefaultValues.SocialMention)
            {
                content.Add(new KeyValuePair<string, string>("social.mention", $"{parameters.SocialMention}"));
            }
            if (parameters.Include != DefaultValues.Include)
            {
                content.Add(new KeyValuePair<string, string>("include", $"{parameters.Include}"));
            }
            if (parameters.ExtraTypes != DefaultValues.ExtraTypes)
            {
                content.Add(new KeyValuePair<string, string>("extra_types", $"{parameters.ExtraTypes}"));
            }
            if (parameters.Country != null)
            {
                content.Add(new KeyValuePair<string, string>("country", $"{parameters.Country}"));
            }
            if (parameters.CustomSpots != DefaultValues.CustomSpots)
            {
                content.Add(new KeyValuePair<string, string>("custom_spots", $"{parameters.CustomSpots}"));
            }
            return content;
        }

        public static string EntityExtractionUriBuilder()
        {
            return $"{Localizations.DataTxt}/{Localizations.EntityExtractionUri}";

        }

        public static string EntityExtractionUrlBuilder(string source, EntityExtractionParameters parameters)
        {
            var url = $"{Localizations.BaseUrl}/{Localizations.DataTxt}/{Localizations.EntityExtractionUri}?token={Localizations.Token}&{source}";
            if (parameters.Lang != DefaultValues.Lang)
            {
                url = $"{url}&lang={parameters.Lang}";
            }
            if (parameters.TopEntities != DefaultValues.TopEntities)
            {
                url = $"{url}&top_entities={parameters.TopEntities}";
            }
            if (parameters.MinConfidence != DefaultValues.MinConfidence)
            {
                url = $"{url}&min_confidence={parameters.MinConfidence}";
            }
            if (parameters.SocialHashtag != DefaultValues.SocialHashtag)
            {
                url = $"{url}&social.hashtag={parameters.SocialHashtag}";
            }
            if (parameters.SocialMention != DefaultValues.SocialMention)
            {
                url = $"{url}&social.mention={parameters.SocialMention}";
            }
            if (parameters.Include != DefaultValues.Include)
            {
                url = $"{url}&include={parameters.Include}";
            }
            if (parameters.ExtraTypes != DefaultValues.ExtraTypes)
            {
                url = $"{url}&extra_types={parameters.ExtraTypes}";
            }
            if (parameters.Country != null)
            {
                url = $"{url}&country={parameters.Country}";
            }
            if (parameters.CustomSpots != DefaultValues.CustomSpots)
            {
                url = $"{url}&custom_spots={parameters.CustomSpots}";
            }
            return url;
        }

        public static string TextSimilarityUrlBuilder(string source, TextSimilarityParameters parameters)
        {
            var url = $"{Localizations.BaseUrl}/{Localizations.DataTxt}/{Localizations.TextSimilarity}?token={Localizations.Token}&{source}";
            if (parameters.Lang != DefaultValues.Lang)
            {
                url = $"{url}&lang={parameters.Lang}";
            }
            if (parameters.Bow != DefaultValues.Bow)
            {
                url = $"{url}&top_entities={parameters.Bow}";
            }
            return url;
        }

        public static string TextClassificationUrlBuilder(string source, TextClassificationParameters parameters)
        {
            var url = $"{Localizations.BaseUrl}/{Localizations.DataTxt}/{Localizations.TextSimilarity}?token={Localizations.Token}&{source}&model={parameters.Model}";
            if (parameters.MinScore != DefaultValues.MinScore)
            {
                url = $"{url}&min_score={parameters.MinScore}";
            }
            if (parameters.MaxAnnotations != DefaultValues.MaxAnnotations)
            {
                url = $"{url}&max_annotations={parameters.MaxAnnotations}";
            }
            if (parameters.Include != DefaultValues.Include) //TODO refact ogni lista
            {
                url = $"{url}&include={parameters.Include}";
            }
            return url;
        }

        public static string LanguageDetectionUrlBuilder(string source, LanguageDetectionParameters parameters)
        {
            var url = $"{Localizations.BaseUrl}/{Localizations.DataTxt}/{Localizations.LanguageDetection}?token={Localizations.Token}&{source}";
            if (parameters.Clean != DefaultValues.Clean)
            {
                url = $"{url}&clean={parameters.Clean}";
            }
            return url;
        }

        public static string SentimentAnalysisUrlBuilder(string source, SentimentAnalysisParameters parameters)
        {
            var url = $"{Localizations.BaseUrl}/{Localizations.DataTxt}/{Localizations.SentimentAnalysis}?token={Localizations.Token}&{source}";
            if (parameters.Lang != DefaultValues.Lang)
            {
                url = $"{url}&lang={parameters.Lang}";
            }
            return url;
        }

        public static string WikisearchUrlBuilder(string source, WikisearchParameters parameters)
        {
            var url = $"{Localizations.BaseUrl}/{Localizations.Datagraph}/{Localizations.WikiSearch}/?token={Localizations.Token}&{source}&lang={parameters.Lang}";
            if (parameters.Limit != DefaultValues.Limit)
            {
                url = $"{url}&limit={parameters.Limit}";
            }
            if (parameters.Offset != DefaultValues.Offset)
            {
                url = $"{url}&offset={parameters.Offset}";
            }
            if (parameters.Query != DefaultValues.Query)
            {
                url = $"{url}&query={parameters.Query}";
            }
            if (parameters.Include != DefaultValues.Include)
            {
                url = $"{url}&include={parameters.Include}";
            }
            return url;
        }

        public Task<T> CallApiAsync<T>(string uri)
        {
            return null;
        }

        public Task<T> CallApiAsync<T>(string uri, List<KeyValuePair<string, string>> content, HttpMethod method = null)
        {
            if (method == null)
            {
                method = HttpMethod.Post;
            }

            return Task.Run(async () =>
            {
                _client.BaseAddress = new Uri(Localizations.BaseUrl);
                var httpContent = new HttpRequestMessage(method, uri)
                {
                    Content = new FormUrlEncodedContent(content.ToArray())
                };
                var result = await _client.SendAsync(httpContent);
                string resultContent = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(resultContent); 
            });
        }
    }
}