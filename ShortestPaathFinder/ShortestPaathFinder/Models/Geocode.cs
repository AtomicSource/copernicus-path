using Newtonsoft.Json;
using System;

namespace ShortestPaathFinder.Models
{
    //public struct Vertex {
    //        public double lat;
    //        public double lon;
    //    };
    public class Geocode
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("lat")]
        public double Lat { get; set; }
        [JsonProperty("lon")]
        public double Lon { get; set; }

        //private Vertex vertex;
        public Geocode(string id, string name, double lat, double lon){
            Id = id;
            Name = name;
            Lat = lat;
            Lon = lon;
        }
    }
}