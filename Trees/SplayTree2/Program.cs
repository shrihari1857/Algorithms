using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplayTree2
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Node { key = 100 };
            root.left = new Node { key = 50 };
            root.right = new Node { key = 200 };
            root.left.left = new Node { key = 40 };
            root.left.left.left = new Node { key = 30 };
            root.left.left.left.left = new Node { key = 20 };
            root = insert(root, 25);
        }

        // This function brings the key at root if key is present in tree. 
        // If key is not present, then it brings the last accessed item at 
        // root.  This function modifies the tree and returns the new root
        private static Node Splay(Node root, int k)
        {
            // Base cases: root is null or key is present at root 
            if (root == null || root.key == k)
                return root;

            // Key lies in left subtree 
            if (root.key > k)
            {
                // Key is not in tree, we are done 
                if (root.left == null) return root;

                // Zig-Zig (Left Left) 
                if (root.left.key > k)
                {
                    // First recursively bring the key as root of left-left 
                    root.left.left = Splay(root.left.left, k);

                    // Do first rotation for root, second rotation is done after else 
                    root = rightRotate(root);
                }
                else if (root.left.key < k) // Zig-Zag (Left Right) 
                {
                    // First recursively bring the key as root of left-right 
                    root.left.right = Splay(root.left.right, k);

                    // Do first rotation for root.left 
                    if (root.left.right != null)
                        root.left = leftRotate(root.left);
                }

                // Do second rotation for root 
                return (root.left == null) ? root : rightRotate(root);
            }
            else // Key lies in right subtree 
            {
                // Key is not in tree, we are done 
                if (root.right == null) return root;

                // Zig-Zag (Right Left) 
                if (root.right.key > k)
                {
                    // Bring the key as root of right-left 
                    root.right.left = Splay(root.right.left, k);

                    // Do first rotation for root.right 
                    if (root.right.left != null)
                        root.right = rightRotate(root.right);
                }
                else if (root.right.key < k)// Zag-Zag (Right Right) 
                {
                    // Bring the key as root of right-right and do first rotation 
                    root.right.right = Splay(root.right.right, k);
                    root = leftRotate(root);
                }

                // Do second rotation for root 
                return (root.right == null) ? root : leftRotate(root);
            }
        }

        private static Node leftRotate(Node x)
        {
            var y = x.right; 
            x.right = y.left; 
            y.left = x; 
            return y;
        }

        private static Node rightRotate(Node x)
        {
            var y = x.left; 
            x.left = y.right; 
            y.right = x; 
            return y; 
        }

        // Function to insert a new key k in splay tree with given root 
        private static Node insert(Node root, int k)
        {
            // Simple Case: If tree is empty 
            if (root == null) return new Node{ key = k};

            // Bring the closest leaf node to root 
            root = Splay(root, k);

            // If key is already present, then return 
            if (root.key == k) return root;

            // Otherwise allocate memory for new node 
            var newnode  = new Node { key = k }; 
  
            // If root's key is greater, make root as right child 
            // of newnode and copy the left child of root to newnode 
            if (root.key > k) 
            { 
                newnode.right = root; 
                newnode.left = root.left; 
                root.left = null; 
            } 
  
            // If root's key is smaller, make root as left child 
            // of newnode and copy the right child of root to newnode 
            else
            { 
                newnode.left = root; 
                newnode.right = root.right; 
                root.right = null; 
            } 
  
            return newnode; // newnode becomes new root 
        }
    }

    public class Node
    {
        public int key { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
    }

}
