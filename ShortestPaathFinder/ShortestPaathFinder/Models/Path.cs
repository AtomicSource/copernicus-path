using System;
using ShortestPaathFinder.Models;

namespace ShortestPaathFinder.Models
{
    public interface IPath
    {
        double CalcDistance(Marker m1, Marker m2);
    }
    public struct Edge
    {
        public Geocode Gc1;
        public Geocode Gc2;
        public double Dist;
    };
    public class Path
    {
        private Edge path;
        public Path(Edge p)
        {
            path = p;
        }

        // these functions Modified from http://pietschsoft.com/post/2008/02/01/Calculate-Distance-Between-Geocodes-in-C-and-JavaScript
        public const double EarthRadius = 6371000; // meters
        public static double ToRadian(double val) { return val * (Math.PI / 180); }
        public static double DiffRadian(double val1, double val2) { return ToRadian(val2) - ToRadian(val1); }

        /// <summary> 
        /// Calculate the distance between two Markers. Output is in meters.
        /// </summary>
        public static double CalcDistance(Marker m1, Marker m2)
        {
            double lat1, lon1, lat2, lon2;
            
            lat1 = m1.Lat;
            lon1 = m1.Lon;
            lat2 = m2.Lat;
            lon2 = m2.Lon;
            return EarthRadius * 2 * Math.Asin(Math.Min(1, Math.Sqrt((Math.Pow(Math.Sin((DiffRadian(lat1, lat2)) / 2.0), 2.0)
                + Math.Cos(ToRadian(lat1)) * Math.Cos(ToRadian(lat2)) * Math.Pow(Math.Sin((DiffRadian(lon1, lon2)) / 2.0), 2.0)))));
        }
    }
}