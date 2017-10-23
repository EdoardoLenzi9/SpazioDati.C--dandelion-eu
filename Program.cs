using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace SpazioDati.Dandelion
{
    class Program
    {
        public static string BaseUrl = "https://api.dandelion.eu";
        public static string DataTxt = "datatxt";
        public static string EntityExtraction = "nex/v1";
        public static string TextSimilarity = "sim/v1";
        public static string TextClassification = "cl/v1";
        public static string LanguageDetection = "li/v1";
        public static string SentimentAnalysis = "sent/v1";
        public static string WikiSearch = "wikisearch/v1";
        public static string Datagraph = "datagraph";
        public static string Token = "41d8b2b068754a9287cc3aeab1d4f079";
        public static string Url = "https://dandelion.eu/docs/api/datatxt/sim/v1/";

        static void Main(string[] args)
        {
            MainAsync();
            Console.ReadLine();
        }

        public static async void MainAsync()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync($"{BaseUrl}/{DataTxt}/{LanguageDetection}?token={Token}&url={Url}");
            var resultJson = JsonConvert.DeserializeObject<ResponseDto>(result);
            Console.WriteLine(result);
        }
        
    }
}
