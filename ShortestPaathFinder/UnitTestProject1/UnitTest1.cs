using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortestPaathFinder.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DistanceTest1()
        {
            Vertex v1 = new Vertex(), v2 = new Vertex();
            v1.lat = 37.4;
            v1.lon = 42.42;
            v2.lat = 37.9;
            v2.lon = 42.52;
            IGeocode gc1 = new Geocode(v1);
            IGeocode gc2 = new Geocode(v2);
            Edge e = new Edge();
            e.gc1 = gc1;
            e.gc2 = gc2;
            IPath p = new Path(e);
            double dist = p.CalcDistance();

            Assert.Equals(dist, 56290.192933584549);
        }

    }
}
