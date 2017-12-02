using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SpazioDati.Dandelion.Domain.Models;
using SpazioDati.Dandelion.Business.Containers;

namespace SpazioDati.Dandelion.Business.Clients
{
    /// <summary> 
    ///     Contains methods useful to setup an http/https call
    /// </summary>
    public class ApiClient
    {
        private static Container _container;
        private HttpClient _client;

        public ApiClient()
        {
            _client = new HttpClient();
        }

        /// <summary> 
        ///     Initializes itself (<c>ApiClient</c>) for the Dependency Injection
        /// </summary>
        public static void Init()
        {
            if (_container == null)
            {
                _container = Container.GetInstance();
                _container.Register<ApiClient>(Lifestyle.Singleton);
            }
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="prefix"> set to "nex." in case of a Text Similarity process</param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> NexContentBuilder(EntityExtractionParameters parameters, string prefix = "")
        {
            var content = new List<KeyValuePair<string, string>>();

            content.Add(new KeyValuePair<string, string>("token", parameters.Token));
            if (parameters.Epsilon != DefaultValues.Epsilon)
            {
                content.Add(new KeyValuePair<string, string>($"{prefix}epsilon", $"{parameters.Epsilon}"));
            }
            if (parameters.Lang != DefaultValues.Lang)
            {
                content.Add(new KeyValuePair<string, string>("lang", $"{parameters.Lang}"));
            }
            if (parameters.TopEntities != DefaultValues.TopEntities)
            {
                content.Add(new KeyValuePair<string, string>($"{prefix}top_entities", $"{parameters.TopEntities}"));
            }
            if (parameters.MinConfidence != DefaultValues.MinConfidence)
            {
                content.Add(new KeyValuePair<string, string>($"{prefix}min_confidence", $"{parameters.MinConfidence}"));
            }
            if (parameters.SocialHashtag != DefaultValues.SocialHashtag)
            {
                content.Add(new KeyValuePair<string, string>($"{prefix}social.hashtag", $"{parameters.SocialHashtag}"));
            }
            if (parameters.SocialMention != DefaultValues.SocialMention)
            {
                content.Add(new KeyValuePair<string, string>($"{prefix}social.mention", $"{parameters.SocialMention}"));
            }
            if (parameters.Include != DefaultValues.Include)
            {
                content.Add(new KeyValuePair<string, string>($"{prefix}include", $"{String.Join(" , ", parameters.Include)}"));
            }
            if (parameters.ExtraTypes != DefaultValues.ExtraTypes)
            {
                content.Add(new KeyValuePair<string, string>($"{prefix}extra_types", $"{String.Join(" , ", parameters.ExtraTypes)}"));
            }
            if (parameters.Country != DefaultValues.Country)
            {
                content.Add(new KeyValuePair<string, string>($"{prefix}country", $"{parameters.Country}"));
            }
            if (parameters.CustomSpots != DefaultValues.CustomSpots)
            {
                content.Add(new KeyValuePair<string, string>($"{prefix}custom_spots", $"{parameters.CustomSpots}"));
            }
            return content;
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="source"> a dictionary that contains the text source</param>
        /// <param name="parameters"></param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> EntityExtractionContentBuilder(List<KeyValuePair<string, string>> source, EntityExtractionParameters parameters)
        {
            var content = NexContentBuilder(parameters);
            content.AddRange(source);
            return content;
        }

        /// <summary> 
        ///     Builds the uri for the http/https call       
        /// </summary>
        /// <returns> Returns the uri as a string </returns>
        public static string EntityExtractionUriBuilder()
        {
            return $"{Localizations.DataTxt}/{Localizations.EntityExtractionUri}";
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="source"> a dictionary that contains the text sources</param>
        /// <param name="parameters"></param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> TextSimilarityContentBuilder(List<KeyValuePair<string, string>> source, TextSimilarityParameters parameters)
        {
            var content = NexContentBuilder(parameters, "nex.");
            content.AddRange(source);

            if (parameters.Bow != DefaultValues.Bow)
            {
                content.Add(new KeyValuePair<string, string>("bow", parameters.Bow.ToString()));
            }
            return content;
        }

        /// <summary> 
        ///     Builds the uri for the http/https call       
        /// </summary>
        /// <returns> Returns the uri as a string </returns>
        public static string TextSimilarityUriBuilder()
        {
            return $"{Localizations.DataTxt}/{Localizations.TextSimilarity}";
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="source"> a dictionary that contains the text source</param>
        /// <param name="parameters"></param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> TextClassificationContentBuilder(List<KeyValuePair<string, string>> source, TextClassificationParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();

            content.Add(new KeyValuePair<string, string>("token", parameters.Token));
            content.AddRange(source);

            if (parameters.MinScore != DefaultValues.MinScore)
            {
                content.Add(new KeyValuePair<string, string>("min_score", parameters.MinScore.ToString()));
            }
            if (parameters.MaxAnnotations != DefaultValues.MaxAnnotations)
            {
                content.Add(new KeyValuePair<string, string>("max_annotations", parameters.MaxAnnotations.ToString()));
            }
            if (parameters.Include != DefaultValues.Include)
            {
                content.Add(new KeyValuePair<string, string>("include", $"{String.Join(" , ", parameters.Include)}"));
            }
            return content;
        }

        /// <summary> 
        ///     Builds the uri for the http/https call       
        /// </summary>
        /// <returns> Returns the uri as a string </returns>
        public static string TextClassificationUriBuilder()
        {
            return $"{Localizations.DataTxt}/{Localizations.TextClassification}";
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="source"> a dictionary that contains the text source</param>
        /// <param name="parameters"></param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> LanguageDetectionContentBuilder(List<KeyValuePair<string, string>> source, LanguageDetectionParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();

            content.Add(new KeyValuePair<string, string>("token", parameters.Token));
            content.AddRange(source);

            if (parameters.Clean != DefaultValues.Clean)
            {
                content.Add(new KeyValuePair<string, string>("clean", parameters.Clean.ToString()));
            }

            return content;
        }

        /// <summary> 
        ///     Builds the uri for the http/https call       
        /// </summary>
        /// <returns> Returns the uri as a string </returns>
        public static string LanguageDetectionUriBuilder()
        {
            return $"{Localizations.DataTxt}/{Localizations.LanguageDetection}";
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="source"> a dictionary that contains the text source</param>
        /// <param name="parameters"></param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> SentimentAnalysisContentBuilder(List<KeyValuePair<string, string>> source, SentimentAnalysisParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();

            content.Add(new KeyValuePair<string, string>("token", parameters.Token));
            content.AddRange(source);


            if (parameters.Lang != DefaultValues.Lang)
            {
                content.Add(new KeyValuePair<string, string>("lang", parameters.Lang.ToString()));
            }

            return content;
        }

        /// <summary> 
        ///     Builds the uri for the http/https call       
        /// </summary>
        /// <returns> Returns the uri as a string </returns>
        public static string SentimentAnalysisUriBuilder()
        {
            return $"{Localizations.DataTxt}/{Localizations.SentimentAnalysis}";
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="source"> a dictionary that contains the text source</param>
        /// <param name="parameters"></param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> WikisearchContentBuilder(List<KeyValuePair<string, string>> source, WikisearchParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();

            content.Add(new KeyValuePair<string, string>("token", parameters.Token));
            content.AddRange(source);

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
                content.Add(new KeyValuePair<string, string>("include", $"{String.Join(" , ", parameters.Include)}"));
            }

            return content;
        }

        /// <summary> 
        ///     Builds the uri for the http/https call       
        /// </summary>
        /// <returns> Returns the uri as a string </returns>
        public static string WikisearchUriBuilder()
        {
            return $"{Localizations.Datagraph}/{Localizations.WikiSearch}";
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> CreateCustomSpotContentBuilder(CustomSpotParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();
            content.Add(new KeyValuePair<string, string>("token", parameters.Token));
            content.Add(new KeyValuePair<string, string>("data", JsonConvert.SerializeObject(parameters.Data)));
            return content;
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> UpdateCustomSpotContentBuilder(CustomSpotParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();
            content.Add(new KeyValuePair<string, string>("token", parameters.Token));
            content.Add(new KeyValuePair<string, string>("id", parameters.Id));
            content.Add(new KeyValuePair<string, string>("data", JsonConvert.SerializeObject(parameters.Data)));
            return content;
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> ReadCustomSpotContentBuilder(CustomSpotParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();
            content.Add(new KeyValuePair<string, string>("token", parameters.Token));
            content.Add(new KeyValuePair<string, string>("id", parameters.Id));
            return content;
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> DeleteCustomSpotContentBuilder(CustomSpotParameters parameters)
        {
            return ReadCustomSpotContentBuilder(parameters);
        }

        /// <summary> 
        ///     Builds the uri for the http/https call       
        /// </summary>
        /// <returns> Returns the uri as a string </returns>
        public static string CustomSpotUriBuilder()
        {
            return $"{Localizations.DataTxt}/{Localizations.CustomSpot}";
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> CreateCustomModelContentBuilder(CustomModelParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();
            content.Add(new KeyValuePair<string, string>("token", parameters.Token));
            content.Add(new KeyValuePair<string, string>("data", JsonConvert.SerializeObject(parameters.Data)));
            return content;
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> UpdateCustomModelContentBuilder(CustomModelParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();
            content.Add(new KeyValuePair<string, string>("token", parameters.Token));
            content.Add(new KeyValuePair<string, string>("id", parameters.Id));
            content.Add(new KeyValuePair<string, string>("data", JsonConvert.SerializeObject(parameters.Data)));
            return content;
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> ReadCustomModelContentBuilder(CustomModelParameters parameters)
        {
            var content = new List<KeyValuePair<string, string>>();
            content.Add(new KeyValuePair<string, string>("token", parameters.Token));
            content.Add(new KeyValuePair<string, string>("id", parameters.Id));
            return content;
        }

        /// <summary> 
        ///     Allocates a dictionary that contains the parameters for the call       
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>Returns the dictionary </returns>
        public static List<KeyValuePair<string, string>> DeleteCustomModelContentBuilder(CustomModelParameters parameters)
        {
            return ReadCustomModelContentBuilder(parameters);
        }

        /// <summary> 
        ///     Builds the uri for the http/https call       
        /// </summary>
        /// <returns> Returns the uri as a string </returns>
        public static string CustomModelUriBuilder()
        {
            return $"{Localizations.DataTxt}/{Localizations.CustomModel}";
        }

        ///<summary> 
        ///     Asyncronous method that made a generic http/https call.         
        ///</summary>
        ///<remarks>
        ///     The base url is declared in <c>Localizations.BaseUrl</c>    
        ///</remarks> 
        ///<param name="uri"> URI  </param>
        ///<param name="content"> Dictionary populated with the parameters for the call </param>
        ///<param name="method"> Http method, in case of Get or Delete the content is passed (and encoded) as an uri parameter instead of a body parameter </param>
        ///<returns>Returns the http/https response</returns>
        ///<seealso cref="Localizations"/> 
        public Task<T> CallApiAsync<T>(string uri, List<KeyValuePair<string, string>> content, HttpMethod method = null)
        {
            var result = new HttpResponseMessage();
            if (method == null)
            {
                method = HttpMethod.Post;
            }

            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(Localizations.BaseUrl);
            }
            return Task.Run(async () =>
            {
                if (method == HttpMethod.Get)
                {
                    string query;
                    using (var encodedContent = new FormUrlEncodedContent(content))
                    {
                        query = encodedContent.ReadAsStringAsync().Result;
                    }
                    result = await _client.GetAsync($"{uri}/?{query}");
                }
                else if (method == HttpMethod.Delete)
                {
                    string query;
                    using (var encodedContent = new FormUrlEncodedContent(content))
                    {
                        query = encodedContent.ReadAsStringAsync().Result;
                    }
                    result = await _client.DeleteAsync($"{uri}/?{query}");
                }
                else
                {
                    var httpContent = new HttpRequestMessage(method, uri);
                    if (content != null)
                    {
                        httpContent.Content = new FormUrlEncodedContent(content.ToArray());
                    }
                    result = await _client.SendAsync(httpContent);
                }
                string resultContent = await result.Content.ReadAsStringAsync();
                if (result.StatusCode == System.Net.HttpStatusCode.RequestUriTooLong)
                {
                    throw new ArgumentException(ErrorMessages.UriTooLong);
                }
                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception(resultContent); 
                }
                return JsonConvert.DeserializeObject<T>(resultContent);
            });
        }
    }
}