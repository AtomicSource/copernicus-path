using System;
using ShortestPaathFinder.Models;

namespace ShortestPaathFinder.Models
{
    public interface IEdge
    {
        double CalcDistance(Vertex v1, Vertex v2);
    }
    public struct Edge
    {
        public IGeoCode gc1;
        public IGeoCode gc2;
        public double dist;
    };
    public class Edge
    {
        private Edge e;
        public Edge(Edge e)
        {
            this.e = e;
        }


    }
}