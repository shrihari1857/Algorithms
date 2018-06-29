using GraphTheory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraCSharp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();
            graph.AddEdge("u", "v", 2);
            graph.AddEdge("u", "w", 5);
            graph.AddEdge("u", "x", 1);
            graph.AddEdge("v", "x", 2);
            graph.AddEdge("v", "w", 3);
            graph.AddEdge("x", "w", 5);
            graph.AddEdge("x", "y", 1);
            graph.AddEdge("y", "w", 1);
            graph.AddEdge("w", "z", 5);
            graph.AddEdge("y", "z", 1);

            var source = graph.GetVertex("u");
            source.Distance = 0;
            var pq = new PriorityQueue();

            foreach (var neighbor in graph.GetEnumerator())
            {
                pq.Insert(neighbor);
            }
            while (!pq.isEmpty())
            {
                var currentVertex = pq.DeleteMinimum();
                foreach (var nextVertex in currentVertex.Neighbors())
                {
                    var newDistance = currentVertex.Distance + nextVertex.EdgeWeight;
                    if (newDistance < nextVertex.ToVertex.Distance)
                    {
                        nextVertex.ToVertex.Distance = newDistance;
                        nextVertex.ToVertex.Pi = currentVertex;
                        pq.DecreaseKey(nextVertex.ToVertex, newDistance);
                    }
                }
            }

        }
    }
}
