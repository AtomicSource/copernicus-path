using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dijkstra
{
    public class DistanceCalculator
    {

        public IDictionary<string, double> CalculateDistances(Graph graph, string startingNode)
        {
//            if (!graph.Nodes.Any(n => n.Key == startingNode))
//                throw new ArgumentException("Starting node must be in graph.");
//		
            InitialiseGraph(graph, startingNode);
            ProcessGraph(graph, startingNode);
            return ExtractDistances(graph);
        }
		//
		public List<Node> CalculateNodePaths1(Graph graph, string startingNode)
		{
			List<Node> tempNodes = graph.Nodes.Values.ToList ();
			List<Node> nodepath = new List<Node> ();
			//			if (!graph.Nodes.Any(n => n.Key == startingNode))
			//				throw new ArgumentException("Starting node must be in graph.");
			//startingN = startingNode;
			bool finished = false;
			graph.Nodes [startingNode].isVisited = true;
			while ( !finished) {

				var nextNode = FindNextNode1 (graph, startingNode);
				if (nextNode != null) {
					nextNode.isVisited = true;
					nodepath.Add (nextNode);
					tempNodes.Remove (graph.Nodes[startingNode]);
					startingNode = nextNode.Name;
				} else {
					finished = true;
				}
			}
			return nodepath;
		}

		private Node FindNextNode1(Graph graph, string startingNode)
		{
			InitialiseGraph1(graph, startingNode);
			ProcessGraph1(graph, startingNode);
			return graph.Nodes.Values.ToList ().Where (m => m.Name != startingNode && m.isVisited != true).OrderBy (x => x.DistanceFromStart).FirstOrDefault ();

		}

		private void InitialiseGraph1(Graph graph, string startingNode)
		{
			foreach (Node node in graph.Nodes.Values)
				node.DistanceFromStart = double.PositiveInfinity;
			graph.Nodes[startingNode].DistanceFromStart = 0;
		}


		private void ProcessGraph1(Graph graph, string startingNode)
		{
			bool finished = false;
			var queue = graph.Nodes.Values.ToList();


			while (!finished)
			{
				Node nextNode = queue.OrderBy(n => n.DistanceFromStart).FirstOrDefault(n => !double.IsPositiveInfinity(n.DistanceFromStart));
				if (nextNode != null)
				{   
					ProcessNode(nextNode, queue);

					queue.Remove(nextNode);
				}
				else
				{
					finished = true;
				}
			}
		}


		//

		public List<Node> CalculateNodePaths(Graph graph, string startingNode)
		{
			//Graph temporaryGraph = graph;
			List<Node> nodepath = new List<Node> ();
			//			if (!graph.Nodes.Any(n => n.Key == startingNode))
			//				throw new ArgumentException("Starting node must be in graph.");
			//startingN = startingNode;
			bool finished = false;
			while (!finished) {

				var nextNode = FindNextNode (graph, startingNode);

				if (nextNode != null) {
					//nextNode.isVisited = true;
					nodepath.Add (nextNode);
					graph.Nodes.Remove (startingNode);
					startingNode = nextNode.Name;
				} else {
					finished = true;
				}
			}
			return nodepath;
		}


		private Node FindNextNode(Graph graph, string startingNode)
		{
			InitialiseGraph(graph, startingNode);
			ProcessGraph(graph, startingNode);
			return graph.Nodes.Values.Where(m => m.Name!= startingNode).OrderBy (x => x.DistanceFromStart).FirstOrDefault ();
		}

        private void InitialiseGraph(Graph graph, string startingNode)
        {
            foreach (Node node in graph.Nodes.Values)
                node.DistanceFromStart = double.PositiveInfinity;
            graph.Nodes[startingNode].DistanceFromStart = 0;
        }

	
		private void ProcessGraph(Graph graph, string startingNode)
        {
            bool finished = false;
            var queue = graph.Nodes.Values.ToList();


            while (!finished)
            {
                Node nextNode = queue.OrderBy(n => n.DistanceFromStart).FirstOrDefault(n => !double.IsPositiveInfinity(n.DistanceFromStart));
                if (nextNode != null)
                {   
                    ProcessNode(nextNode, queue);

                    queue.Remove(nextNode);
                }
                else
                {
                    finished = true;
                }
            }
        }

        private void ProcessNode(Node node, List<Node> queue)
        {
            var connections = node.Connections.Where(c => queue.Contains(c.Target));

            foreach (var connection in connections)
			{  
                double distance = node.DistanceFromStart + connection.Distance;

				if (distance < connection.Target.DistanceFromStart) {

					connection.Target.DistanceFromStart = distance;
					connection.Target.NodesVisited.Add (node.Name);
				}
            }
        }

        private IDictionary<string, double> ExtractDistances(Graph graph)
        {
			return graph.Nodes.ToDictionary(n => n.Key, n => n.Value.DistanceFromStart);

        }

    }
}
