using System;
using ShortestPaathFinder.Models;

namespace ShortestPaathFinder.Models
{
    public interface IPath
    {
        double CalcDistance();
    }
    public struct Edge
    {
        public IGeocode gc1;
        public IGeocode gc2;
        public double dist;
    };
    public class Path : IPath
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
        /// Calculate the distance between two geocodes. Output's in meters.
        /// </summary>
        public double CalcDistance()
        {
            double lat1, lon1, lat2, lon2;
            lat1 = path.gc1.Vertex.lat;
            lon1 = path.gc1.Vertex.lon;
            lat2 = path.gc2.Vertex.lat;
            lon2 = path.gc2.Vertex.lon;
            double radius = EarthRadius;
            return radius * 2 * Math.Asin(Math.Min(1, Math.Sqrt((Math.Pow(Math.Sin((DiffRadian(lat1, lat2)) / 2.0), 2.0)
                + Math.Cos(ToRadian(lat1)) * Math.Cos(ToRadian(lat2)) * Math.Pow(Math.Sin((DiffRadian(lon1, lon2)) / 2.0), 2.0)))));
        }
    }
}