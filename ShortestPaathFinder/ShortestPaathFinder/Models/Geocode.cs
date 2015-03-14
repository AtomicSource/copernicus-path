using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortestPaathFinder.Models
{
    public interface IGeoCode
{
    double CalcDistance(Vertex v1, Vertex v2);
}
    public struct Vertex {
            public double lat;
            public double lon;
        };
    public class Geocode: IGeoCode
    {
        private Vertex v;
        public Geocode(Vertex v){
            this.v = v;
        }
        
        // these functions Modified from http://pietschsoft.com/post/2008/02/01/Calculate-Distance-Between-Geocodes-in-C-and-JavaScript
        public const double EarthRadius = 6371000; // meters
        public static double ToRadian(double val) { return val * (Math.PI / 180); }
        public static double DiffRadian(double val1, double val2) { return ToRadian(val2) - ToRadian(val1); }

        /// <summary> 
        /// Calculate the distance between two geocodes. Output's in meters.
        /// </summary>
        public  double CalcDistance(Vertex v1, Vertex v2)
        {
            double lat1, lon1, lat2, lon2;
            lat1 = v1.lat;
            lon1 = v1.lon;
            lat2 = v2.lat;
            lon2 = v2.lon;
            double radius = EarthRadius;
            return radius * 2 * Math.Asin(Math.Min(1, Math.Sqrt((Math.Pow(Math.Sin((DiffRadian(lat1, lat2)) / 2.0), 2.0) 
                + Math.Cos(ToRadian(lat1)) * Math.Cos(ToRadian(lat2)) * Math.Pow(Math.Sin((DiffRadian(lon1, lon2)) / 2.0), 2.0)))));
        }
    }
}