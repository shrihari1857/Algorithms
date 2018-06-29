using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class Neighbor
    {
        private Vertex _ToVertex;
        private int _EdgeWeight;

        public Neighbor(Vertex ToVertex, int EdgeWeight)
        {
            _ToVertex = ToVertex;
            _EdgeWeight = EdgeWeight;
        }

        public Vertex ToVertex
        {
            get
            {
                return _ToVertex;
            }

        }
        public int EdgeWeight { get { return _EdgeWeight; } }
    }
}
