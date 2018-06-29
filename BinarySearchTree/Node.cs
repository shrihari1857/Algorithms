using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Node
    {
        public int key { get; set; }
        public int data { get; set; }

        public Node left { get; set; }
        public Node right { get; set; }
        public Node parent { get; set; }

    }

    public class BST
    {
        Node root = null;

        public Node Root()
        {
            return root;
        }

        internal void FindAndDelete(Node node, int key)
        {
            var _node = Search(node, key);

            if (_node.left == null && _node.right == null)
                UpdateParent(_node, null);
            else if (_node.left == null && _node.right != null)
                UpdateParent(_node, _node.right);
            else if (_node.left != null && _node.right == null)
                UpdateParent(_node, _node.left);
            else
            {
                var successor = inSuccessor(key);
                UpdateParent(successor, null);
                UpdateParent(_node, successor);
                
            }
        }

        private void UpdateParent(Node _node, Node newNode)
        {
            if (newNode !=null)
            {
                newNode.left = _node.left;
                newNode.right = _node.right;
            }

            if (_node == _node.parent.left)
                _node.parent.left = newNode;
            else
                _node.parent.right = newNode;
        }

        public void Insert(int _key, int _data)
        {
            if(root == null)
                root = new Node
                {
                    key = _key,
                    data = _data,
                    parent = null
                };
            else
                SearchAndInsert(root, _key, _data);

        }
        public int Minimum(Node node)
        {
            if (node.left == null)
                return node.key;

            return Minimum(node.left);
            
        }

        public Node inSuccessor(int key)
        {
            var node = Search(root, key);
            if (node.right != null)
                return Left(node.right);
            else if (node.left == null && node.right == null && node == node.parent.right)
                return null;
             else
                return node.parent;

        }

        private Node Left(Node node)
        {
            if (node.left == null)
                return node;

            return Left(node.left);
        }

        private Node Search(Node node, int _key)
        {
            if (node.key == _key)
                return node;
            else if (node.key >= _key)
                return Search(node.left, _key);
            else return Search(node.right, _key);
        }

        public int Maximum(Node node)
        {
            if (node.right == null)
                return node.key;

            return Maximum(node.right);

        }
        private void SearchAndInsert(Node node, int _key, int _data)
        {
            if (node.key >= _key)
            {
                if (node.left == null)
                {
                    node.left = new Node
                    {
                        key = _key,
                        data = _data,
                        parent = node
                    };
                    return;
                }
                SearchAndInsert(node.left, _key, _data);
            }
            else
            {
                if (node.right == null)
                {
                    node.right = new Node
                    {
                        key = _key,
                        data = _data,
                        parent = node
                    };
                    return;
                }
                SearchAndInsert(node.right, _key, _data);
            }
        }
    }
}
