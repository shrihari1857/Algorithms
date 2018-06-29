using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var graph = getGraph();
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
            while(!pq.isEmpty())
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

        //private static Vertex getGraph()
        //{
        //    var u = new Vertex{ Name = "u" };
        //    var v = new Vertex { Name = "v" };
        //    var x = new Vertex { Name = "x" };
        //    var y = new Vertex { Name = "y" };
        //    var w = new Vertex { Name = "w" };
        //    var z = new Vertex { Name = "z" };
        //    u.Neighbors = new List<Neighbor>
        //    {
        //        new Neighbor(v, 2),
        //        new Neighbor(w, 5),
        //        new Neighbor(x, 1)
        //    };
        //    v.Neighbors = new List<Neighbor>
        //    {
        //        new Neighbor(u, 2),
        //        new Neighbor(x, 2),
        //        new Neighbor(w, 3)
        //    };
        //    x.Neighbors = new List<Neighbor>
        //    {
        //        new Neighbor(u, 1),
        //        new Neighbor(v, 2),
        //        new Neighbor(w, 3),
        //        new Neighbor(y, 1)
        //    };
        //    y.Neighbors = new List<Neighbor>
        //    {
        //        new Neighbor(x, 1),
        //        new Neighbor(z, 1),
        //        new Neighbor(w, 1)
        //    };
        //    z.Neighbors = new List<Neighbor>
        //    {
        //        new Neighbor(y, 1),
        //        new Neighbor(w, 5)
        //    };
        //    w.Neighbors = new List<Neighbor>
        //    {
        //        new Neighbor(u, 5),
        //        new Neighbor(v, 3),
        //        new Neighbor(x, 3),
        //        new Neighbor(y, 1),
        //        new Neighbor(z, 5)
        //    };

        //    return u;
        //}
    }
}
