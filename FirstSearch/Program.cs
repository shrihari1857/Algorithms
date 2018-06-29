using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = sampleTree();
            //Console.WriteLine("BFS => ");
            //bfsTraversal(tree);

            Console.WriteLine("DFS ");
            dfsTraversal(tree);
            
        }

        private static void dfsTraversal(Node node)
        {
            if (node == null)
                return;
            dfsTraversal(node.Left);
            Console.WriteLine(node.Data);
            dfsTraversal(node.Right);
        }

        private static void bfsTraversal(Node node)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var deque = queue.Dequeue();
                Console.WriteLine(deque.Data);

                if (deque.Left != null)
                    queue.Enqueue(deque.Left);

                if (deque.Right != null)
                    queue.Enqueue(deque.Right);
            }
        }

        private static Node sampleTree()
        {
            return new Node
            {
                Data = "A",
                Left = new Node
                {
                    Data = "B",
                    Left = new Node
                    {
                        Data = "C",
                        Left = null,
                        Right = null
                    },
                    Right = new Node
                    {
                        Data = "D",
                        Left = null,
                        Right = null
                    }
                },
                Right = new Node
                {
                    Data = "E",
                    Left = new Node
                    {
                        Data = "F",
                        Left = null,
                        Right = null
                    },
                    Right = new Node
                    {
                        Data = "G",
                        Left = new Node
                        {
                            Data = "H",
                            Left = null,
                            Right = null
                        },
                        Right = null
                    }
                }
            };
        }
    }
}
