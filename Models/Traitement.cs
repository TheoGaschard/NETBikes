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
            // Connection à l'API, récupération du json
            var streamTask = client.GetStreamAsync("https://download.data.grandlyon.com/ws/rdata/jcd_jcdecaux.jcdvelov/all.json");

            // déserialisation du json en objet
            var RetourAPI = await JsonSerializer.DeserializeAsync<RootObject>(await streamTask);

            var ListeStations = RetourAPI.values;

            // Tri par nom
            ListeStations.Sort((x, y) => x.name.CompareTo(y.name));

            return ListeStations;
        }

        public static async Task<List<StationBdx>> FindStationsBdx()
        {
            // Connection à l'API, récupération du json
            var streamTask = client.GetStreamAsync("https://api.alexandredubois.com/vcub-backend/vcub.php");

            // déserialisation du json en objet
            var RetourAPI = await JsonSerializer.DeserializeAsync<List<StationBdx>>(await streamTask);

            var ListeStations = RetourAPI;

            return ListeStations;
        }



    }
}
