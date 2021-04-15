using System;
using System.Collections.Generic;
using System.Text;

namespace MultiGraphGC
{
    class Node
    {

        public int Id { get; set; }
        public string Label { get; set; }

        public Node(int id, string label)
        {
            Id = id;
            Label = label;
        }
    }
}
