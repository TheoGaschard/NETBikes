using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeWatcher.Models
{
    public class Station
    {
        public string number { get; set; }
        public string pole { get; set; }
        public string available_bikes { get; set; }
        public string code_insee { get; set; }
        public string lng { get; set; }
        public string availability { get; set; }
        public string availabilitycode { get; set; }
        public string etat { get; set; }
        public string startdate { get; set; }
        public string langue { get; set; }
        public string bike_stands { get; set; }
        public string last_update { get; set; }
        public string available_bike_stands { get; set; }
        public string gid { get; set; }
        public string titre { get; set; }
        public string status { get; set; }
        public string commune { get; set; }
        public string description { get; set; }
        public string nature { get; set; }
        public string bonus { get; set; }
        public string address2 { get; set; }
        public string address { get; set; }
        public string lat { get; set; }
        public string last_update_fme { get; set; }
        public string enddate { get; set; }
        public string name { get; set; }
        public string banking { get; set; }
        public string nmarrond { get; set; }

        public Station()
        {


        }

        public Station(StationBdx stationBdx)
        {
            lat = stationBdx.latitude;
            lng = stationBdx.longitude;
            name = stationBdx.name;
            status = stationBdx.is_online ? "OPEN" : "CLOSED";
            available_bikes = stationBdx.bike_count_total.ToString();
        }

    }

    public class StationBdx
    {
        public int id { get; set; }
        public string name { get; set; }
        public int bike_count { get; set; }
        public int electric_bike_count { get; set; }
        public int bike_count_total { get; set; }
        public int slot_count { get; set; }
        public bool is_online { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class RootObject
    {
        public List<string> fields { get; set; }
        public List<Station> values { get; set; }
        public int nb_results { get; set; }
        public string table_href { get; set; }
        public string layer_name { get; set; }
    }


}
