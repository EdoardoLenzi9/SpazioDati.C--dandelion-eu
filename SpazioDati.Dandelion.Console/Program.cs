using System.Diagnostics;
using System.Threading.Tasks;
using SpazioDati.Dandelion.Domain.Models;
using Newtonsoft.Json;
using SpazioDati.Dandelion.Business;

namespace SpazioDati.Dandelion.ConsoleApp
{
    public class Program{
        public static void Main(){
            MainAsync().Wait();
        }

        public static async Task MainAsync() {
            new DandelionUtils();
            var response = JsonConvert.SerializeObject(await DandelionUtils.GetEntitiesAsync(new EntityExtractionParameters() { Text = "ronaldo & ronaldinho", Lang = LanguageOption.it }));
            Debug.WriteLine("\n\n\n Response: \n\n\n" + response);
        }
    }
}


