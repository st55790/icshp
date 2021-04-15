using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MultiGraphGC
{
    class Program
    {

        static void Main(string[] args)
        {
            Graph graph = LoadEdgesAndNodes();
            ArrayList arrayAlg2 = Algorithm2(graph);
            List<Hashtable> listAlg1 = Algorithm1(graph);

            Console.WriteLine("Algoritmus 1:");

            foreach (Hashtable hashtable in listAlg1)
            {
                foreach (DictionaryEntry item in hashtable)
                {
                    Console.Write((item.Value as Node).Label + ", ");
                }
                Console.WriteLine("\n");

            }

            Console.WriteLine("\nAlgoritmus 2:");
            foreach (Node item in arrayAlg2)
            {
                Console.WriteLine(item.Label);
            }
            Console.ReadLine();
        }

        public static List<Hashtable> Algorithm1(Graph graph)
        {
            Queue queue = new Queue();
            Hashtable nodes = graph.GetNodes();        
            HashSet<Edge>.Enumerator edgesEnum = graph.GetEdges().GetEnumerator();

            Hashtable comletedNodes = new Hashtable();
            queue.Enqueue(nodes[0]);

            while (queue.Count != 0)
            {
                Node node = (Node)queue.Dequeue();
                if (!comletedNodes.Contains(node.Id))
                {
                    comletedNodes.Add(node.Id, node);
                }


                while (edgesEnum.MoveNext())
                {
                    Edge edge = edgesEnum.Current;
                    if (edge.Source == node.Id)
                    {
                        if (!comletedNodes.Contains(edge.Target))
                        {
                            queue.Enqueue(nodes[edge.Target]);
                        }

                    }
                }
                edgesEnum = graph.GetEdges().GetEnumerator();

            }

            foreach (DictionaryEntry item in comletedNodes)
            {
                nodes.Remove(item.Key);
            }

            List<Hashtable> list = new List<Hashtable>();

            foreach (DictionaryEntry actual in nodes)
            {
                bool contains = false;
                foreach (Hashtable item in list)
                {
                    foreach (DictionaryEntry subitem in item)
                    {
                        if (subitem.Key.Equals(actual.Key))
                        {
                            contains = true;
                        }
                    }
                }
                if (!contains)
                {
                    Queue front = new Queue();
                    front.Enqueue(actual.Value);
                    Hashtable hashtable = new Hashtable();

                    while (front.Count != 0)
                    {
                        Node node = (Node)front.Dequeue();
                        if (!hashtable.Contains(node.Id))
                        {
                            hashtable.Add(node.Id, node);
                        }
                        while (edgesEnum.MoveNext())
                        {
                            Edge edge = edgesEnum.Current;
                            if ((edge.Source == node.Id) || (edge.Target == node.Id))
                            {
                                if (!hashtable.Contains(edge.Source))
                                {
                                    front.Enqueue(nodes[edge.Source]);
                                }
                                if (!hashtable.Contains(edge.Target))
                                {
                                    if (nodes.Contains(edge.Target))
                                    {
                                        front.Enqueue(nodes[edge.Target]);
                                    }

                                }

                            }
                        }
                        edgesEnum = graph.GetEdges().GetEnumerator();
                    }
                    list.Add(hashtable);
                }
            }

            return list;
        }
        public static ArrayList Algorithm2(Graph graph)
        {
            ArrayList list = new ArrayList();
            Edge edge;
            HashSet<Edge>.Enumerator enumerator = graph.GetEdges().GetEnumerator();
            enumerator.MoveNext();
            while ((edge = enumerator.Current) != null)
            {
                if (edge.Source == edge.Target)
                {
                    list.Add(graph.GetNodes()[edge.Source]);
                }
                enumerator.MoveNext();
            }
            return list;
        }
        public static Graph LoadEdgesAndNodes()
        {
            Graph graph = new Graph();
            using (var stream = new StreamReader(Directory.GetCurrentDirectory() + @"\vstup.dat"))
            {
                if (stream != null)
                {
                    string line;
                    while ((line = stream.ReadLine()) != null)
                    {
                        if (line == "\tnode")
                        {
                            stream.ReadLine();
                            line = stream.ReadLine();
                            line = line.Substring(5);
                            string label = stream.ReadLine();
                            label = label.Substring(9);
                            label = label.Remove(label.Length - 1);
                            graph.AddNode(new Node(Int32.Parse(line), label));

                        }
                        else if (line == "\tedge")
                        {
                            stream.ReadLine();
                            line = stream.ReadLine();
                            line = line.Substring(9);
                            string label = stream.ReadLine();
                            label = label.Substring(9);
                            graph.AddEdge(new Edge(Int32.Parse(line), Int32.Parse(label)));
                        }
                    }

                }
                stream.Close();
            }
            return graph;
        }
    }
}
