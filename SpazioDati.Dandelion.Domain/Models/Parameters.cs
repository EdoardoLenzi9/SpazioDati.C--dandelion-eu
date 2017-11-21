using System.Collections.Generic;
using System.Net.Http;

namespace SpazioDati.Dandelion.Domain.Models
{
    public class SourceParameters
    {
        public string Text;
        public string Url;
        public string Html;
        public string HtmlFragment;
        public HttpMethod HttpMethod = null;
    }

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

    public class TextSimilarityParameters
    /*TODO
        Did you know?
        You can use the Entity Extraction API's parameters as well, prefixing them with nex. (e.g: nex.min_confidence)  */
    {
        public string Text1;
        public string Text2;
        public string Url1;
        public string Url2;
        public string Html1;
        public string Html2;
        public string HtmlFragment1;
        public string HtmlFragment2;
        public LanguageOption Lang = DefaultValues.Lang;
        public BowOption Bow = DefaultValues.Bow;
        public HttpMethod HttpMethod = null;
    }

    public class TextClassificationParameters : SourceParameters
    {
        public int Model;
        public double MinScore = DefaultValues.MinScore;
        public int? MaxAnnotations = DefaultValues.MaxAnnotations;
        public List<IncludeOption> Include = DefaultValues.Include;
    }

    public class LanguageDetectionParameters : SourceParameters
    {
        public bool Clean = DefaultValues.Clean;
    }

    public class SentimentAnalysisParameters : SourceParameters
    {
        public LanguageOption Lang = DefaultValues.Lang;
    }

    public class WikisearchParameters
    {
        public string Text;
        public LanguageOption Lang = LanguageOption.en;
        public int Limit = DefaultValues.Limit;
        public int Offset = DefaultValues.Offset;
        public QueryOption Query = DefaultValues.Query;
        public List<IncludeOption> Include = DefaultValues.Include;
        public HttpMethod HttpMethod = null;
    }

    public class CustomSpotParameters
    {
        public string Id;
        public CustomSpotDataParameters Data;
    }

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

    public class CustomModelParameters
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