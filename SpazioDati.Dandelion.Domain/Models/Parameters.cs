using System.Collections.Generic;
using System.Net.Http;

namespace SpazioDati.Dandelion.Domain.Models
{
    ///<summary> 
    ///     Generic class extended by any other parameter class; contains only the <c>Token</c> variable, necessary for every call.   
    ///</summary>
    ///<remarks> Api key is available on the <see href="https://dandelion.eu/docs/api/#calling-our-api-authentication">authentication page</see></remarks> 
    public class Parameters
    {
        public string Token;
    }

    public class SourceParameters : Parameters
    {
        public string Text;
        public string Url;
        public string Html;
        public string HtmlFragment;
        public HttpMethod HttpMethod = null;
    }

    ///<summary> 
    ///     Complete description of the parameters on the <see href="https://dandelion.eu/docs/api/datatxt/nex/v1/#parameters">Dandelion page</see>
    ///</summary>
    public class EntityExtractionParameters : SourceParameters
    {
        public LanguageOption Lang = DefaultValues.Lang;
        public int TopEntities = DefaultValues.TopEntities;
        public double MinConfidence = DefaultValues.MinConfidence;
        public int MinLength = DefaultValues.MinLength;
        public bool SocialHashtag = DefaultValues.SocialHashtag;
        public bool SocialMention = DefaultValues.SocialMention;
        public List<IncludeOption> Include = DefaultValues.Include;
        public List<ExtraTypesOption> ExtraTypes = DefaultValues.ExtraTypes;
        public CountryOption? Country = DefaultValues.Country;
        public string CustomSpots = DefaultValues.CustomSpots;
        public double Epsilon = DefaultValues.Epsilon;
    }

    ///<summary> 
    ///     Complete description of the parameters on the <see href="https://dandelion.eu/docs/api/datatxt/sim/v1/#parameters">Dandelion page</see>
    ///</summary>
    public class TextSimilarityParameters : EntityExtractionParameters
    {
        public string Text1;
        public string Text2;
        public string Url1;
        public string Url2;
        public string Html1;
        public string Html2;
        public string HtmlFragment1;
        public string HtmlFragment2;
        public BowOption Bow = DefaultValues.Bow;
        private new string Text;
        private new string Url;
        private new string Html;
        private new string HtmlFragment;
    }

    ///<summary> 
    ///     Complete description of the parameters on the <see href="https://dandelion.eu/docs/api/datatxt/cl/v1/#parameters">Dandelion page</see>
    ///</summary>
    public class TextClassificationParameters : SourceParameters
    {
        public int Model;
        public double MinScore = DefaultValues.MinScore;
        public int? MaxAnnotations = DefaultValues.MaxAnnotations;
        public List<IncludeOption> Include = DefaultValues.Include;
    }

    ///<summary> 
    ///     Complete description of the parameters on the <see href="https://dandelion.eu/docs/api/datatxt/li/v1/#parameters">Dandelion page</see>
    ///</summary>
    public class LanguageDetectionParameters : SourceParameters
    {
        public bool Clean = DefaultValues.Clean;
    }

    ///<summary> 
    ///     Complete description of the parameters on the <see href="https://dandelion.eu/docs/api/datatxt/sent/v1/#parameters">Dandelion page</see>
    ///</summary>
    public class SentimentAnalysisParameters : SourceParameters
    {
        public LanguageOption Lang = DefaultValues.Lang;
    }

    ///<summary> 
    ///     Complete description of the parameters on the <see href="https://dandelion.eu/docs/api/datagraph/wikisearch/">Dandelion page</see>
    ///</summary>
    public class WikisearchParameters : Parameters
    {
        public string Text;
        public LanguageOption Lang = LanguageOption.en;
        public int Limit = DefaultValues.Limit;
        public int Offset = DefaultValues.Offset;
        public QueryOption Query = DefaultValues.Query;
        public List<IncludeOption> Include = DefaultValues.Include;
        public HttpMethod HttpMethod = null;
    }

    ///<summary> 
    ///     Complete description of the parameters on the <see href="https://dandelion.eu/docs/api/datagraph/wikisearch/">Dandelion page</see>
    ///</summary>
    public class CustomSpotParameters : Parameters
    {
        public string Id;
        public CustomSpotDataParameters Data;
    }

    ///<summary> 
    ///     Complete description of the parameters on the <see href="https://dandelion.eu/docs/api/datatxt/custom-spots/v1/">Dandelion page</see>
    ///</summary>
    public class CustomSpotDataParameters 
    {
        public LanguageOption Lang;
        public string Description;
        public List<CustomSpotListParameters> List;
    }

    public class CustomSpotListParameters 
    {
        public string Spot;
        public string Topic;
        public bool Greedy = DefaultValues.Greedy;
        public bool ExactMatch = DefaultValues.ExactMatch;
    }

    ///<summary> 
    ///     Complete description of the parameters on the <see href="https://dandelion.eu/docs/api/datatxt/cl/models/v1/">Dandelion page</see>
    ///</summary>
    public class CustomModelParameters : Parameters
    {
        public string Id;
        public CustomModelDataParameters Data;
    }

    public class CustomModelDataParameters
    {
        public LanguageOption Lang;
        public string Description;
        public List<CustomModelCategoryParameters> Categories;
    }

    public class CustomModelCategoryParameters
    {
        public string Name;
        public Dictionary<string, double> Topics;
    }
}