using System.Diagnostics;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Domain.Models;
using Newtonsoft.Json;
using SpazioDati.Dandelion.Business;
using System.Collections.Generic;

namespace SpazioDati.Dandelion.ConsoleApp
{
    public class Program
    {
        public static string Url1 = "http://milano.repubblica.it/cronaca/2017/11/16/news/divorzio_berlusconi_veronica_lario-181256569/?ref=RHPPLF-BH-I0-C8-P2-S1.8-T2";
        public static string Url2 = "https://xunit.github.io/docs/getting-started-desktop.html";
        public static string Text = "ronaldo & ronaldinho";
        public static void Main()
        {
            MainAsync().Wait();
        }

        public static async Task MainAsync()
        {
            new DandelionUtils();
            var response = await DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() { Include = new List<IncludeOption> { IncludeOption.image, IncludeOption.categories, IncludeOption.lod }, Url = Url1, Lang = LanguageOption.it });
            /*response = await DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() { Url = Url1, Lang = LanguageOption.it });
            response = await DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() { Url = Url2});
            response = await DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() { Url = Url2, Text = Text });*/
            var responseJson = JsonConvert.SerializeObject(response);
            Debug.WriteLine("\n\n\n Response: \n\n\n" + responseJson);

            //var response2 = await DandelionUtils.GetSimilaritiesAsync(new TextSimilarityParameters() { Url1 = Url1, Text1 = Text, Url2 = Url2 });

        }
    }
}


