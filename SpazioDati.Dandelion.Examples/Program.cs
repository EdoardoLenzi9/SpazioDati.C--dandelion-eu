using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpazioDati.Dandelion.Domain.Models;

namespace SpazioDati.Dandelion.Examples
{
    class Program
    {
        public static string Url1 = "http://milano.repubblica.it/cronaca/2017/11/16/news/divorzio_berlusconi_veronica_lario-181256569/?ref=RHPPLF-BH-I0-C8-P2-S1.8-T2";
        public static string Url2 = "https://xunit.github.io/docs/getting-started-desktop.html";
        public static string Text = "ronaldo & ronaldinho";

        public static string Text1 = " a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a aa a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a a Silvio Berlusconi Mario Monti Robert De Niro";
        public static string Text2 = "a a a a a a a a  a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a a a  a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a  a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a  a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a aa a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a aa a a a a a a a  a a a a a a a a a a a a a a a a a a a Silvio Berlusconi Mario Monti Robert De Niro";
        public static string Token = "41d8b2b068754a9287cc3aeab1d4f079";

        public static void Main()
        {
            MainAsync().Wait();
        }

        public static async Task MainAsync()
        {
            /*
            var entities1 = await DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() {Text = Text, HttpMethod = HttpMethod.Get });
            Debug.WriteLine("\n\n\n Response: \n\n\n" + JsonConvert.SerializeObject(entities1));
            var entities2 = await DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() { Text = Text1, HttpMethod = HttpMethod.Get });
            Debug.WriteLine("\n\n\n Response: \n\n\n" + JsonConvert.SerializeObject(entities2));
            var entities3 = await DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() { Text = Text1, HttpMethod = HttpMethod.Post });
            Debug.WriteLine("\n\n\n Response: \n\n\n" + JsonConvert.SerializeObject(entities3));
            var entities4 = await DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() { Text = Text, HttpMethod = HttpMethod.Post });
            Debug.WriteLine("\n\n\n Response: \n\n\n" + JsonConvert.SerializeObject(entities4));
            */
            /*var entities5 = await DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() { Text = Text2, HttpMethod = HttpMethod.Get });
            Debug.WriteLine("\n\n\n Response: \n\n\n" + JsonConvert.SerializeObject(entities5));*/
            var entities6 = await Business.DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() { Token = Token, Text = Text, HttpMethod = HttpMethod.Post });
            Console.WriteLine("\n\n\n Response: \n\n\n" + JsonConvert.SerializeObject(entities6));
            Console.Read();
            //var response = await DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() { Include = new List<IncludeOption> { IncludeOption.image, IncludeOption.categories, IncludeOption.lod }, Url = Url1, Lang = LanguageOption.it });
            /*response = await DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() { Url = Url1, Lang = LanguageOption.it });
            response = await DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() { Url = Url2});
            response = await DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() { Url = Url2, Text = Text });*/


            //var response2 = await DandelionUtils.GetSimilaritiesAsync(new TextSimilarityParameters() { Url1 = Url1, Text1 = Text, Url2 = Url2 });

        }
    }
}

