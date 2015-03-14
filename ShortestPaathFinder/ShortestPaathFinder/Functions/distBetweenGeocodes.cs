// Modified from http://pietschsoft.com/post/2008/02/01/Calculate-Distance-Between-Geocodes-in-C-and-JavaScript

using System;

namespace ShortestPaathfinder
{
    /// <summary>
    /// Functions to calc dist between Geocodes
    /// </summary>
    public static class DistBetweenGeocodes
    {
        public const double EarthRadius = 6371000; // meters
        public static double ToRadian(double val) { return val * (Math.PI / 180); }
        public static double DiffRadian(double val1, double val2) { return ToRadian(val2) - ToRadian(val1); }

        /// <summary> 
        /// Calculate the distance between two geocodes. Output's in meters.
        /// </summary>
        public static double CalcDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radius = EarthRadius;
            return radius * 2 * Math.Asin(Math.Min(1, Math.Sqrt((Math.Pow(Math.Sin((DiffRadian(lat1, lat2)) / 2.0), 2.0) + Math.Cos(ToRadian(lat1)) * Math.Cos(ToRadian(lat2)) * Math.Pow(Math.Sin((DiffRadian(lng1, lng2)) / 2.0), 2.0)))));
        }
    }
}