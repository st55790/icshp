using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MultiGraphGC
{
    class Graph
    {
        Hashtable nodes = new Hashtable();
        HashSet<Edge> edges = new HashSet<Edge>();

        public Node FirstNode { get; set; }

        public void AddNode(Node node) {
            nodes.Add(node.Id, node);
        }

        public void AddEdge(Edge edge) {
            edges.Add(edge);
        }

        public Hashtable GetNodes() {
            return nodes;
        }
        public HashSet<Edge> GetEdges() {
            return edges;
        }
    }
}
