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

        public static List<KeyValuePair<string, string>> TextSimilarityContentBuilder(string source, TextSimilarityParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();

            content.Add(new KeyValuePair<string, string>("token", Localizations.Token));
            //content.Add(new KeyValuePair<string, string>("text", parameters.Text));

            if (parameters.Lang != DefaultValues.Lang)
            {
                content.Add(new KeyValuePair<string, string>("lang", parameters.Lang.ToString()));
            }
            if (parameters.Bow != DefaultValues.Bow)
            {
                content.Add(new KeyValuePair<string, string>("top_entities", parameters.Bow.ToString()));
            }
            return content;
        }

        public static string TextSimilarityUriBuilder()
        {
            return $"{Localizations.DataTxt}/{Localizations.TextSimilarity}";
        }

        public static List<KeyValuePair<string, string>> TextClassificationContentBuilder(string source, TextClassificationParameters parameters)
        { 
            var content = new List<KeyValuePair<string, string>>();

            content.Add(new KeyValuePair<string, string>("token", Localizations.Token));
            content.Add(new KeyValuePair<string, string>("text", parameters.Text));

            if (parameters.MinScore != DefaultValues.MinScore)
            {
                content.Add(new KeyValuePair<string, string>("min_score", parameters.MinScore.ToString()));
            }
            if (parameters.MaxAnnotations != DefaultValues.MaxAnnotations)
            {
                content.Add(new KeyValuePair<string, string>("max_annotations", parameters.MaxAnnotations.ToString()));
            }
            if (parameters.Include != DefaultValues.Include) //TODO refact ogni lista
            {
                content.Add(new KeyValuePair<string, string>("include", parameters.Include.ToString()));
            }
            return content;
        }

        public static string TextClassificationUriBuilder()
        {
            return $"{Localizations.DataTxt}/{Localizations.TextClassification}";
        }

        public static List<KeyValuePair<string, string>> LanguageDetectionContentBuilder(string source, LanguageDetectionParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();

            content.Add(new KeyValuePair<string, string>("token", Localizations.Token));
            content.Add(new KeyValuePair<string, string>("text", parameters.Text)); //TODO switch source

            if (parameters.Clean != DefaultValues.Clean)
            {
                content.Add(new KeyValuePair<string, string>("clean", parameters.Clean.ToString()));
            }

            return content;
        }

        public static string LanguageDetectionUriBuilder()
        {
            return $"{Localizations.DataTxt}/{Localizations.LanguageDetection}";
        }

        public static List<KeyValuePair<string, string>> SentimentAnalysisContentBuilder(string source, SentimentAnalysisParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();

            content.Add(new KeyValuePair<string, string>("token", Localizations.Token));
            content.Add(new KeyValuePair<string, string>("text", parameters.Text)); //TODO switch source


            if (parameters.Lang != DefaultValues.Lang)
            {
                content.Add(new KeyValuePair<string, string>("lang", parameters.Lang.ToString()));
            }

            return content;
        }

        public static string SentimentAnalysisUriBuilder()
        {
            return $"{Localizations.DataTxt}/{Localizations.SentimentAnalysis}";
        }

        public static List<KeyValuePair<string, string>> WikisearchContentBuilder(string source, WikisearchParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();

            content.Add(new KeyValuePair<string, string>("token", Localizations.Token));
            content.Add(new KeyValuePair<string, string>("text", parameters.Text)); //TODO switch source


            if (parameters.Limit != DefaultValues.Limit)
            {
                content.Add(new KeyValuePair<string, string>("limit", parameters.Limit.ToString()));
            }
            if (parameters.Offset != DefaultValues.Offset)
            {
                content.Add(new KeyValuePair<string, string>("offset", parameters.Offset.ToString()));
            }
            if (parameters.Query != DefaultValues.Query)
            {
                content.Add(new KeyValuePair<string, string>("query", parameters.Query.ToString()));
            }
            if (parameters.Include != DefaultValues.Include)
            {
                content.Add(new KeyValuePair<string, string>("include", parameters.Include.ToString()));
            }

            return content;
        }

        public static string WikisearchUriBuilder()
        {
            return $"{Localizations.Datagraph}/{Localizations.WikiSearch}";
        }

        /*
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
        }*/

        public async Task<T> CallApiAsync<T>(string uri, List<KeyValuePair<string, string>> content, HttpMethod method = null)
        {
            if (method == null)
            {
                method = HttpMethod.Post;
            }

            _client.BaseAddress = new Uri(Localizations.BaseUrl);
            var httpContent = new HttpRequestMessage(method, uri)
            {
                Content = new FormUrlEncodedContent(content.ToArray())
            };
            var result = await _client.SendAsync(httpContent);
            string resultContent = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resultContent);
        }
    }
}