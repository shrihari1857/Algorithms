using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var bTree = new BTree(3, true);
            bTree.Insert(1);
            bTree.Insert(2);
            bTree.Insert(3);
            bTree.Insert(4);
            bTree.Insert(5);
            bTree.Insert(6);

        }
    }

    public class BTree
    {
        int _minDegree;
        int _noOfKeys;
        int[] _keys;
        bool _leaf;
        BTree[] _children;
        BTree _root;

        public BTree(int minDegree, bool leaf)
        {
            _minDegree = minDegree;
            _keys = new int[2 * minDegree - 1];
            _children = new BTree[2 * minDegree - 1];
            _leaf = leaf;
        }

        public Node Search(int key)
        {
            return new Node();
        }

        public void Insert(int key)
        {
            if (_root == null)
            {
                _root = new BTree(_minDegree, true);
                _root._keys[0] = key;
                _root._noOfKeys = 1;
            }
            else
            {
                if (_root._noOfKeys == 2 * _minDegree - 1)
                {
                    var newRoot = new BTree(_minDegree, false);
                    newRoot._children[0] = _root;
                    SplitChild(0, _root);

                    var g = 0;
                    if (newRoot._keys[0] < key)
                        g++;

                    _children[g] = InsertNonFull(key);
                    _root = newRoot;
                }
                else
                {
                    _root._keys[_root._noOfKeys] = key;
                    _root._noOfKeys = _root._noOfKeys + 1;
                }
                    
            }
        }

        private BTree InsertNonFull(int key)
        {
            // Initialize index as index of rightmost element
            int i = _noOfKeys - 1;

            // If this is a leaf node
            if (_leaf == true)
            {
                // The following loop does two things
                // a) Finds the location of new key to be inserted
                // b) Moves all greater keys to one place ahead
                while (i >= 0 && _keys[i] > key)
                {
                    _keys[i + 1] = _keys[i];
                    i--;
                }

                // Insert the new key at found location
                _keys[i + 1] = key;
                _noOfKeys = _noOfKeys + 1;
            }
            else // If this node is not leaf
            {
                // Find the child which is going to have the new key
                while (i >= 0 && _keys[i] > key)
                    i--;

                // See if the found child is full
                if (_children[i + 1]._noOfKeys == 2 * _minDegree - 1)
                {
                    // If the child is full, then split it
                    SplitChild(i + 1, _children[i + 1]);

                    // After split, the middle key of C[i] goes up and
                    // C[i] is splitted into two.  See which of the two
                    // is going to have the new key
                    if (_keys[i + 1] < key)
                        i++;
                }
                _children[i + 1] = InsertNonFull(key);
            }
        }

        private void SplitChild(int v, BTree existingNode)
        {
            //create a new node to save (min degree - 1) keys
            var newNode = new BTree(_minDegree, true)
            {
                _noOfKeys = _minDegree - 1
            };

            //copy the last (min degree - 1) keys of the root to newNode
            for (int i = 0; i < _minDegree - 1; i++)
                newNode._keys[i] = existingNode._keys[i + _minDegree];

            //if the existing node is not leaf, it is required to copy all it's last (min degree - 1) children to the new node
            if (!existingNode._leaf)
                for (int i = 0; i < _minDegree - 1; i++)
                    newNode._children[i] = existingNode._children[i + _minDegree];

            //reduce the number of keys in the existing node
            existingNode._noOfKeys = _minDegree - 1;

            // Since this node is going to have a new child,
            // create space of new child
            for (int i = _noOfKeys; i >= v + 1; i--)
                _children[i + 1] = _children[i];

            //link the new child node
            _children[v + 1] = newNode;

            // A key of y will move to this node. Find location of
            // new key and move all greater keys one space ahead
            for (int j = _noOfKeys - 1; j >= v; j--)
                _keys[j + 1] = _keys[j];

            // Copy the middle key of y to this node
            _keys[v] = existingNode._keys[_minDegree - 1];

            // Increment count of keys in this node
            _noOfKeys = _noOfKeys + 1;

        }

        public void Delete(int key)
        {

        }

    }
}
