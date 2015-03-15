using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ShortestPaathFinder.Models
{
    public class Marker
    {
        [JsonProperty("mid")]
        public string Mid { get; set; }
        [JsonProperty("uid")]
        public string Uid { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("reivew")]
        public short Review { get; set; }
        [JsonProperty("lat")]
        public double Lat { get; set; }
        [JsonProperty("lon")]
        public double Lon { get; set; }

        //private Vertex vertex;
        public Marker(string mid, string uid, string name, string time, string notes, short review, 
            double lat, double lon){
            Mid = mid;
            Uid = uid;
            Name = name;
            Time = time;
            Notes = notes;
            Review = review;
            Lat = lat;
            Lon = lon;
        }
    }
}