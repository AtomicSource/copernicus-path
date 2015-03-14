using System;

namespace ShortestPaathFinder.Models
{
    public interface IGeocode
    {
        Vertex Vertex { get; set; }
    }
    public struct Vertex {
            public double lat;
            public double lon;
        };
    public class Geocode: IGeocode
    {
        //private Vertex vertex;
        public Geocode(Vertex v){
            Vertex = v;
        }

        public Vertex Vertex { get; set;} 
        
    }
}