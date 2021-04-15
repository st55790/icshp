using System;
using System.Collections.Generic;
using System.Text;

namespace MultiGraphGC
{
    class Edge
    {

        public int Source { get; set; }
        public int Target { get; set; }

        public Edge(int source, int target)
        {
            Source = source;
            Target = target;
        }
    }
}
