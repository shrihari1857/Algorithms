using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraCSharp
{
    public class PQtype
    {
        private int _distance;
        private Vertex _vertex;

        public PQtype(int distance, Vertex vertex)
        {
            _distance = distance;
            _vertex = vertex;
        }

        public int Distance { get { return _distance; } set { _distance = value; } }
        public Vertex Vertex { get { return _vertex; } }
    }
}
