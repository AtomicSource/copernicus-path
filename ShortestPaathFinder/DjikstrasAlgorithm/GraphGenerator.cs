using System;
using System.Collections.Generic;

namespace Dijkstra
{
	public class GraphGenerator
	{
	 public GraphGenerator ()
		{

		}
		/// <summary>
		/// Generates a random graph for testing
		/// </summary>
		/// <returns></returns>
        public Graph GenerateGraph()
		{
			Graph graph = new Graph();
			Random random = new Random ();


			for (int i = 1; i <= 50; i++) {graph.AddNode (i.ToString ());}


			for (int i = 1; i <= 50; i++)
				for (int j = i + 1; j <= 50; j++)
					graph.AddConnection (i.ToString (), j.ToString (), random.Next (1, 10),true);

				return graph;
		}
        //public Graph GenerateGraph(List<Node> )
        //{
            //Exception.NoImplemented();
            //Graph graph = new Graph();
            //Random random = new Random();


            //for (int i = 1; i <= 50; i++) { graph.AddNode(i.ToString()); }


            //for (int i = 1; i <= 50; i++)
            //    for (int j = i + 1; j <= 50; j++)
            //        graph.AddConnection(i.ToString(), j.ToString(), random.Next(1, 10), true);

            //return graph;
        //}
	}
}

