using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowestAncestorBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var root = BuildTree();

            var node = LCA(root, new TreeNode(4), new TreeNode(7));
        }

        
        public static TreeNode LCA(TreeNode root, TreeNode x, TreeNode y)
        {
            if (root == null) return null;
            if (root.val == x.val || root.val == y.val) return root;

            TreeNode leftSubTree = LCA(root.left, x, y);
            TreeNode rightSubTree = LCA(root.right, x, y);

            //x is in one subtree and and y is on other subtree of root
            if (leftSubTree != null && rightSubTree != null) return root;
            //either x or y is present in one of the subtrees of root or none present in either side of the root
            return leftSubTree != null ? leftSubTree : rightSubTree;
        }
       
        private static TreeNode BuildTree()
        {
            var root = new TreeNode(1);
            var N4 = new TreeNode(4);
            var N5 = new TreeNode(5);
            var N2 = new TreeNode(2);
            N2.left = N4;
            N2.right = N5;
            root.left = N2;

            var N6 = new TreeNode(6);
            var N7 = new TreeNode(7);
            var N3 = new TreeNode(3);
            N3.left = N6;
            N3.right = N7;
            root.right = N3;

            return root;

        }
    }

    public class TreeNode
    {
      public int val;
    public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }
}
