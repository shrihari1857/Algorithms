using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraCSharp
{
    public class Vertex
    {
        private string _Name;
        private List<Neighbor> _Neighbors;
        private int _distance;

        public Vertex(string Name)
        {
            _Name = Name;
            _Neighbors = new List<Neighbor>();
            _distance = int.MaxValue;
        }
        public string Name { get { return _Name; } }
        public void AddNeighbor(Vertex neighbor, int weight)
        {
            _Neighbors.Add(new Neighbor(neighbor, weight));
        }

        public List<Neighbor> Neighbors()
        {
            return _Neighbors;
        }
        public int Distance
        {
            get{return _distance;}
            set{ _distance = value; }
        }
        public Vertex Pi { get; set; }
    }
}
