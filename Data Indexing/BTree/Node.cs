using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTree
{
    public class Node
    {
        public int[] Keys { get; set; }
        public int Degree { get; set; }
        public Node[] Children { get; set; }
        public int Count { get; set; }
        public bool Leaf { get; set; }

        public Node()
        {
            Leaf = true;
        }
    }


}
