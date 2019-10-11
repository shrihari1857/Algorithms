using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvertBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(4);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);
            root.right = new TreeNode(7);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(9);
            var treeNode = InvertBinaryTree(root);
        }

        private static TreeNode InvertBinaryTree(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            TreeNode temp;
            TreeNode current;

            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                if(current.left != null)
                    queue.Enqueue(current.left);
                if (current.right != null)
                    queue.Enqueue(current.right);
                temp = current.right;
                current.right = current.left;
                current.left = temp;
            }

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
