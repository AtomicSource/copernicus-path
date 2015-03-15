using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Dijkstra
{
	public class NodePath
	{
		public List<string> nodes;
		public double distance;
		public NodePath()
		{
			 nodes = new List<string> ();
			 distance = 0.0;

		}

	}

    [DebuggerDisplay("Node {Name} (Connections = {_connections.Count}, Distance = {DistanceFromStart})")]
    public class Node
    {
        IList<NodeConnection> _connections;

        public string Name { get; private set; }

        public double DistanceFromStart { get; set; }
		public List<string> NodesVisited{ get; set;}
		public bool isVisited { get; set;}

        public IEnumerable<NodeConnection> Connections
        {
            get { return _connections; }
        }

        public Node(string name)
        {
            Name = name;
            _connections = new List<NodeConnection>();
			NodesVisited = new List<string> ();
        }

        public void AddConnection(Node targetNode, double distance, bool twoWay)
        {
            if (targetNode == null) throw new ArgumentNullException("targetNode");
            if (targetNode == this) throw new ArgumentException("Node may not connect to itself.");
            if (distance <= 0) throw new ArgumentException("Distance must be positive.");

            _connections.Add(new NodeConnection(targetNode, distance));
            if (twoWay) targetNode.AddConnection(this, distance, false);
        }
    }
}
