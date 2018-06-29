using GraphTheory.Sets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleUndirectedGraphUsingDisjointSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new G();
            g.AddEdge(1, 2);
            g.AddEdge(1, 3);
            g.AddEdge(3, 4);
            g.AddEdge(4, 5);
            g.AddEdge(5, 6);
            g.AddEdge(6, 3);

            var djSet = new DisjointSet();
            foreach (var vertex in g.Vertices())
            {
                djSet.MakeSet(vertex.Number);
            }

            foreach(var vert1 in g.Vertices())
            {
                foreach (var nbr in vert1.Neighbors)
                {
                    var vert2 = nbr.Vertex;

                    if (!vert1.Neighbors.Where(x => x.Vertex == vert2).First().visited)
                    {
                        var n1 = vert1.Neighbors.Where(x => x.Vertex == vert2);
                        n1.First().visited = true;

                        var n2 = vert2.Neighbors.Where(x => x.Vertex == vert1);
                        n2.First().visited = true;

                        var parent1 = djSet.FindSet(djSet.GetDSNode(vert1.Number));
                        var parent2 = djSet.FindSet(djSet.GetDSNode(vert2.Number));

                        if (parent1 == parent2)
                        {
                            Console.WriteLine("Cycle exists");
                            return;
                        }

                        djSet.Union(parent1.Data, parent2.Data);
                    }
                }
            }
            Console.WriteLine("Cycle does not exists");
        }

        
    }
    public class G
    {
        Dictionary<int, Vert> vertices = new Dictionary<int, Vert>();

        public List<Vert> Vertices()
        {
            return vertices.Select(x => x.Value).ToList();
        }
        public void AddEdge(int Number1, int Number2)
        {
            Vert vert1 = new Vert();
            Vert vert2 = new Vert();
            if (vertices.ContainsKey(Number1))
                vert1 = vertices[Number1];
            else
            {
                vert1 = new Vert { Number = Number1 };
                vertices.Add(Number1, vert1);
            }

            if (vertices.ContainsKey(Number2))
                vert2 = vertices[Number2];
            else
            {
                vert2 = new Vert { Number = Number2 };
                vertices.Add(Number2, vert2);
            }

            vert1.AddNeighbor(new Neighbr {Vertex = vert2 });
            vert2.AddNeighbor(new Neighbr {Vertex = vert1 });
        }
    }
    public class Vert
    {
        int _Number;
        List<Neighbr> _Neighbors;
        public Vert()
        {
            _Number = 0;
            _Neighbors = new List<Neighbr>();
        }
        public int Number { get { return _Number; } set { _Number = value; } }
        public List<Neighbr> Neighbors { get { return _Neighbors; } set { _Neighbors = value; } }

        public void AddNeighbor(Neighbr nbr)
        {
            _Neighbors.Add(nbr);
        }

    }

    public class Neighbr
    {
        public Vert Vertex { get; set; }
        public int EdgeWeight { get; set; }

        public bool visited { get; set; }
    }
}
