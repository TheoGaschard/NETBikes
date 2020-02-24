using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace BikeWatcher.Models
{
    public static class Traitement
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<Station>> FindStations()
        {
            // Connection à l'API
            var streamTask = client.GetStreamAsync("https://download.data.grandlyon.com/ws/rdata/jcd_jcdecaux.jcdvelov/all.json");

            // déserialisation du json en objet
            var RetourAPI = await JsonSerializer.DeserializeAsync<RootObject>(await streamTask);


            var ListeStations = RetourAPI.values;

            return ListeStations;

        }




    }
}
