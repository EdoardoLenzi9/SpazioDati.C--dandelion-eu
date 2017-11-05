using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpazioDati.Dandelion.Models;
using SpazioDati.Dandelion.Services;

namespace SpazioDati.Dandelion
{
    class Dandelion
    {


        static void Main(string[] args)
        {
            MainAsync();
            Console.ReadLine();
        }

        public static async void MainAsync()
        {
            Console.WriteLine(JsonConvert.SerializeObject(await GetEntitiesAsync(new EntityExtractionParameters{Text = "hello world"})));
        }

        public static Task<EntitiesDto> GetEntitiesAsync (EntityExtractionParameters parameters)
        {
            return EntityExtractionService.GetEntitiesAsync(parameters);
        }
    }
}
