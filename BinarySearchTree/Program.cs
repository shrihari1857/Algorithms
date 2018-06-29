using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        //Build a Binary Search Tree
        static void Main(string[] args)
        {
            var bst = new BST();
            var arr = new int[] { 8, 6, 9, 3, 4, 5, 10, 3, 25, 40, 35, 55, 1 };
            foreach (var item in arr)
            {
                bst.Insert(item, 0);
            }
            bst.Insert(23, 0);
            bst.FindAndDelete(bst.Root(), 1);
            var successorNode = bst.inSuccessor(55);
            var min = bst.Minimum(bst.Root());
            var max = bst.Maximum(bst.Root());
        }
    }
}
