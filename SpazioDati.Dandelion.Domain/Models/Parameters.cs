using System.Collections.Generic;
using System;

namespace SpazioDati.Dandelion.Domain.Models
{
    public class SourceParameters
    {
        public string Text;
        public string Url;
        public string Html;
        public string HtmlFragment;
    }

    public class EntityExtractionParameters : SourceParameters
    {
        public LanguageOption Lang = LanguageOption.auto;
        public int TopEntities = 0;
        public double MinConfidence = 0.6;
        public int MinLength = 2;
        public bool SocialHashtag = false;
        public bool SocialMention = false;
        public List<IncludeOption> Include = null;
        public List<ExtraTypesOption> ExtraTypes = null;
        public CountryOption? Country = null;
        public string CustomSpots = "";
        public double Epsilon = 0.3;
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
        public LanguageOption Lang = LanguageOption.auto;
        public BowOption Bow = BowOption.never;
    }

    public class TextClassificationParameters : SourceParameters
    {
        public int Model;
        public double MinScore = 0.0;
        public int? MaxAnnotations = null;
        public List<IncludeOption> Include = null;
    }

    public class LanguageDetectionParameters : SourceParameters
    {
        public bool Clean = false;
    }

    public class SentimentAnalysisParameters : SourceParameters
    {
        public LanguageOption Lang = LanguageOption.auto;
    }

    public class WikisearchParameters
    {
        public string Text;
        public LanguageOption Lang = LanguageOption.en;
        public int Limit = 10;
        public int Offset = 0;
        public QueryOption Query = QueryOption.full;
        public List<IncludeOption> Include = null;
    }
}