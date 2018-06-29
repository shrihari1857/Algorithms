using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory.Sets
{
    public class DisjointSet
    {
        Dictionary<int, DSNode> collection;
        public DisjointSet()
        {
            collection = new Dictionary<int, DSNode>();
        }
        public DSNode GetDSNode(int Index)
        {
            return collection[Index];
        }
        public int Count()
        {
            return collection.Count;
        }
        public void MakeSet(int _Data)
        {
            var node = new DSNode
            {
                Data = _Data,
                Rank = 0
            };
            node.Parent = node;
            collection.Add(_Data, node);
        }

        public void Union(int Data1, int Data2)
        {
            var node1 = collection[Data1];
            var node2 = collection[Data2];

            var parent1 = FindSet(node1);
            var parent2 = FindSet(node2);

            if (parent1.Data == parent2.Data)
                return;

            if (parent1.Rank >= parent2.Rank)
            {
                parent1.Rank = parent1.Rank == parent2.Rank? parent1.Rank + 1: parent1.Rank = parent1.Rank;
                parent2.Parent = parent1;
            }
            else
            {
                parent1.Parent = parent2;
            }

        }

        public DSNode FindSet (DSNode node)
        {
            if (node.Parent == node)
                return node;

            var parent = FindSet(node.Parent);
            node.Parent = parent;

            return parent;

        }
    }
}
