using DijkstraCSharp;
//using GraphTheory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopologicalSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var topo = new Topo();
            topo.Sort();
        }

        public class Topo
        {
            HashSet<Vertex> set = null;
            Stack<Vertex> stack = null;
            public Topo()
            {
                set = new HashSet<Vertex>();
                stack = new Stack<Vertex>();
            }

            public void Sort()
            {
                var graph = new Graph();
                graph.AddEdge("A", "C", 0);
                graph.AddEdge("B", "C", 0);
                graph.AddEdge("B", "E", 0);
                graph.AddEdge("C", "D", 0);
                graph.AddEdge("D", "F", 0);
                graph.AddEdge("E", "F", 0);
                graph.AddEdge("F", "G", 0);

                var vertices = graph.GetEnumerator().Select(x => x.Vertex);

                foreach (var vertex in vertices.AsEnumerable())
                {
                    if (!set.Contains(vertex))
                    {
                        set.Add(vertex);
                        foreach (var neighbor in vertex.Neighbors())
                        {
                            if (!set.Contains(neighbor.ToVertex))
                            {
                                set.Add(neighbor.ToVertex);
                                FindChild(neighbor.ToVertex);
                                stack.Push(neighbor.ToVertex);
                            }
                        }
                        stack.Push(vertex);
                    }
                    
                }
                Console.WriteLine("Topological sort is ");
                while (stack.Count > 0)
                    Console.Write(stack.Pop().Name + " ");

                Console.ReadLine();
            }

            private void FindChild(Vertex vertex)
            {
                foreach (var neighbor in vertex.Neighbors())
                {
                    if (!set.Contains(neighbor.ToVertex))
                    {
                        set.Add(neighbor.ToVertex);
                        FindChild(neighbor.ToVertex);
                        stack.Push(neighbor.ToVertex);
                    }
                }
                return;
            }
        }
        
    }
}
