using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.Sets
{
    public class DSNode
    {
        public DSNode Parent { get; set; }
        public int Data { get; set; }
        public int Rank { get; set; }
    }
}
