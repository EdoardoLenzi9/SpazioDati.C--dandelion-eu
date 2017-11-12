using System.Collections.Generic;

namespace SpazioDati.Dandelion.Models
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
        public static string Datagraph = "datagraph";
        public static string Token = "41d8b2b068754a9287cc3aeab1d4f079"; //TODO get set token
        public static string Url = "https://dandelion.eu/docs/api/datatxt/sim/v1/";
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
    }
}