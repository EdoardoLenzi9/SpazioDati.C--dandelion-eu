using System.Collections.Generic;

namespace SpazioDati.Dandelion.Domain.Models
{
    public class Localizations
    {
        public static string BaseUrl = "https://api.dandelion.eu";
        public static string DataTxt = "datatxt";
        public static string EntityExtractionUri = "nex/v1";
        public static string TextSimilarity = "sim/v1";
        public static string TextClassification = "cl/v1";
        public static string LanguageDetection = "li/v1";
        public static string SentimentAnalysis = "sent/v1";
        public static string WikiSearch = "wikisearch/v1";
        public static string CustomSpot = "custom-spots/v1";
        public static string Datagraph = "datagraph";
        public static string Token = "41d8b2b068754a9287cc3aeab1d4f079"; //TODO get set token
        public static string Url = "https://dandelion.eu/docs/api/datatxt/sim/v1/";
    }

    public class ErrorMessages
    {
        public static string InvalidToken = "Invalid token";
        public static string WrongEpsilon = "Epsilon must be between 0.0 and 0.5";
        public static string WrongTopEntities = "TopEntities cannot be negative";
        public static string WrongMinConfidence = "MinConfidence must be between 0.0 and 1.0";
        public static string WrongMinLength = "MinLength must be greater then 1";
        public static string WrongInclude1 = "Include cannot assume score_details value";
        public static string WrongInclude2 = "Include can assume only score_details value";
        public static string WrongLang1 = "Lang can assume only en | it | auto values";
        public static string WrongLang2 = "Lang cannot assume value auto";
        public static string WrongUrl = "Not well formed Url";
        public static string WrongText = "Text must be set";
        public static string WrongSource = "At least one filed between Text, Url, Html and HtmlFragment must be set";
        public static string MultipleSources = "Only one parameter between Text, Url, Html and HtmlFragment must be set";
        public static string WrongSource1 = "Only one parameter between Text1, Url1, Html1 and HtmlFragment1 must be set";
        public static string WrongSource2 = "Only one parameter between Text2, Url2, Html2 and HtmlFragment2 must be set";
        public static string WrongSources = "Two text sources are needed";
        public static string WrongMinScore = "MinScore must be between 0.0 and 1.0";
        public static string WrongMaxAnnotations = "MaxAnnotations must be greater than 0";
        public static string WrongLimit = "Limit must be between 1 and 50";
        public static string WrongSpot = "Spot required";
        public static string WrongTopic = "Topic required";
        public static string WrongId = "Id must be set";
        public static string MissingParameters = "Missing Paramenters";
        public static string MissingData = "Missing Data";
        public static string MissingList = "Missing List";

        public static string Token = "Token";
        public static string Epsilon = "Epsilon";
        public static string TopEntities = "TopEntities";
        public static string MinConfidence = "MinConfidence";
        public static string MinLength = "MinLength";
        public static string Include = "Include";
        public static string Lang = "Lang";
        public static string Url = "Url";
        public static string Text = "Text";
        public static string MinScore = "MinScore";
        public static string MaxAnnotations = "MaxAnnotations";
        public static string Limit = "Limit";
        public static string Html = "Html";
        public static string HtmlFragment = "HtmlFragment";
        public static string Url1 = "Url1";
        public static string Html1 = "Html1";
        public static string HtmlFragment1 = "HtmlFragment1";
        public static string Url2 = "Url2";
        public static string Html2 = "Html2";
        public static string HtmlFragment2 = "HtmlFragment2";
        public static string Spot = "Spot";
        public static string Topic = "Topic";
        public static string Id = "Id";
    }

    public class DefaultValues
    {
        public static LanguageOption Lang = LanguageOption.auto;
        public static int TopEntities = 0;
        public static double MinConfidence = 0.6;
        public static int MinLength = 2;
        public static bool SocialHashtag = false;
        public static bool SocialMention = false;
        public static List<IncludeOption> Include = null;
        public static List<ExtraTypesOption> ExtraTypes = null;
        public static string CustomSpots = "";
        public static BowOption Bow = BowOption.never;
        public static double MinScore = 0.0;
        public static int? MaxAnnotations = null;
        public static bool Clean = false;
        public static LanguageOption WikiLang = LanguageOption.en;
        public static int Limit = 10;
        public static int Offset = 0;
        public static QueryOption Query = QueryOption.full;
        public static bool Greedy = false;
        public static bool ExactMatch = false;
    }
}