using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricTree
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
             For example, this binary tree [1,2,2,3,4,4,3] is symmetric:
             
                1
               / \
              2   2
             / \ / \
            3  4 4  3
             */
            //var root =
            //   new TreeNode
            //   {
            //       val = 1,
            //       left = 
            //        new TreeNode
            //        {
            //            val = 2,
            //            left = 
            //                new TreeNode
            //                {
            //                    val = 3,
            //                    left = null,
            //                    right = null
            //                },
            //            right = 
            //                new TreeNode
            //                {
            //                    val = 4,
            //                    left = null,
            //                    right = null
            //                }
            //        },
            //       right =
            //       new TreeNode
            //       {
            //           val = 2,
            //           left =
            //                new TreeNode
            //                {
            //                    val = 4,
            //                    left = null,
            //                    right = null
            //                },
            //           right =
            //                new TreeNode
            //                {
            //                    val = 3,
            //                    left = null,
            //                    right = null
            //                }
            //       }
            //   };
            var root =
                new TreeNode
                {
                    val = 1,
                    left =
                    new TreeNode
                    {
                        val = 2
                    },
                    right = null
                };
            var leftList = new List<int?>();
         //   leftList.Add(root.val);

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            while (queue.Count > 0)
            {
                var newnode = queue.Dequeue();

                //if (newnode == null)
                //    leftList.Add(null);
                //else
                if (newnode != null)
                {
                    leftList.Add(newnode.val);
                    queue.Enqueue(newnode.right);
                    queue.Enqueue(newnode.left);
                }
            }

            var rightList = new List<int?>();
           // rightList.Add(root.val);

            queue.Enqueue(root.right);
            while (queue.Count > 0)
            {
                var newnode = queue.Dequeue();

                if (newnode != null)
                {
                    rightList.Add(newnode.val);
                    queue.Enqueue(newnode.left);
                    queue.Enqueue(newnode.right);
                }
            }

            int?[] leftArr = leftList.ToArray();
            int?[] rightArr = rightList.ToArray();

            bool result = true;
            if (leftArr.Length != rightArr.Length)
                result = false;

            for (int i = 0; i < leftArr.Length; i++)
            {
                if(leftArr[i] != rightArr[i])
                {
                    result = false;
                    break;
                }

            }

            //return result;
        }

        private static void TraverseUsingQ(TreeNode node, List<int?> list)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                var newnode = queue.Dequeue();

                if (newnode == null)
                    list.Add(null);
                else
                {
                    list.Add(newnode.val);
                    queue.Enqueue(newnode.left);
                    queue.Enqueue(newnode.right);
                }
            }
        }

        private static void Traverse(TreeNode node, List<int?> list)
        {
            if (node == null)
            {
                list.Add(null);
            }
            else
            {

                list.Add(node.val);

                //if (node.left == null)
                //    list.Add(null);
                //else
                Traverse(node.left, list);

                //if (node.right == null)
                //    list.Add(null);
                //else
                Traverse(node.right, list);
            }

        }
    }

    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
  }
}
