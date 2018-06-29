using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraCSharp
{
    public class Graph 
    {
        Dictionary<string, Vertex> vertices;

        public Graph()
        {
            vertices = new Dictionary<string, Vertex>();
        }

        public List<Neighbor> GetNeighbors(string vertex)
        {
            return vertices[vertex].Neighbors();
        }

        public Vertex GetVertex(string name)
        {
            return vertices[name];
        }

        public void AddEdge(string from, string to, int weight)
        {
            Vertex source = null;
            Vertex destination = null;

            if (vertices.ContainsKey(from))
                source = vertices[from];
            else
            {
                source = new Vertex(from);
                vertices.Add(source.Name, source);
            }

            if (vertices.ContainsKey(to))
                destination = vertices[to];
            else
            {
                destination = new Vertex(to);
                vertices.Add(destination.Name, destination);
            }
            source.AddNeighbor(destination, weight);
            destination.AddNeighbor(source, weight);
        }

        public List<PQtype> GetEnumerator()
        {
            return 
                    (from vertex in vertices
                    select new PQtype(vertex.Value.Distance, vertex.Value)).ToList();
        }

    }
}
