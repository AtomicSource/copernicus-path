using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Dijkstra
{
    [DebuggerDisplay("-> {Target.Name} ({Distance})")]
    public class NodeConnection
    {
        public Node Target { get; private set; }
        public double Distance { get; private set; }

        public NodeConnection(Node target, double distance)
        {
            Target = target;
            Distance = distance;
        }
    }
}
