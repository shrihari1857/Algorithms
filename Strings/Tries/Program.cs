using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries
{
    class Program
    {
        //Reference - Coursera: Algorithms on Strings
        static void Main(string[] args)
        {
            var text = "panamabananas";
            var patterns = new List<string>
            {
                "banana", "pan", "and", "nab", "antenna", "bandana", "ananas", "nana"
            };

            var root = TrieConstruction(patterns);

            var patternsMatched = new List<string>();

            while (text != string.Empty)
            {
                PreFixTrieMatching(text, root, ref patternsMatched);
                text = text.Remove(0, 1);
            }
            Console.WriteLine("Matched Patterns: ");
            foreach (var pattern in patternsMatched)
                Console.WriteLine(pattern);

            Console.ReadLine();
        }

        private static void PreFixTrieMatching(string text, Trie root, ref List<string> patternsMatched)
        {
            var patternFound = string.Empty;
            var currentNode = root;

            var i = 0;
            while (true)
            {
                //get the node/trie that has a matching symbol
                var nodeFound =
                    from trie in currentNode.Nodes.AsEnumerable()
                    where trie.Symbol == text[i].ToString()
                    select trie;

                if (nodeFound.AsEnumerable().Any()) //if there isn't
                {
                    patternFound = patternFound + text[i];  //store
                    currentNode = nodeFound.First();    //set the current node as the one that matched
                    i++;
                }
                else if (!currentNode.Nodes.Any())  // if this is a leaf, this pattern has matched
                {
                    patternsMatched.Add(patternFound);
                    return;
                }
                else
                    return; // there are more nodes and hence this pattern hasn't matched
            }
        }

        private static Trie TrieConstruction(List<string> patterns)
        {
            var root = new Trie();
            Trie currentNode;

            foreach (var pattern in patterns.AsEnumerable())
            {
                currentNode = root;
                foreach (var chr in pattern)
                {
                    //If there exists no nodes/tries on current node or there exist no matching symbol in either of tries of current node then add a new trie/node
                    if (!currentNode.Nodes.AsEnumerable().Any() || 
                        !(from trie in currentNode.Nodes
                          where trie.Symbol == chr.ToString()
                          select trie).AsEnumerable().Any())
                    {
                        var newNode = new Trie
                        {
                            Symbol = chr.ToString()
                        };

                        var nodes = currentNode.Nodes;
                        nodes.Add(newNode); //add to the current node
                        currentNode = newNode;  //set the new node as current node
                    }
                    else
                    {
                        //set the current node as the one that matches
                        currentNode =
                            (from trie in currentNode.Nodes
                             where trie.Symbol == chr.ToString()
                             select trie).First();
                    }
                }
            }
            return root;
        }
    }
    

    public class Trie
    {
        string _symbol;
        List<Trie> _tries;

         public Trie()
         {
            _symbol = string.Empty;
            _tries = new List<Trie>();
         }
        public string Symbol
        {
            get
            {
                return this._symbol;
            }
            set
            {
            this._symbol = value;
            }
        } 
        public List<Trie> Nodes
        {
            get
            {
                return this._tries;
            }
            set
            {
                this._tries = value;
            }
        }
    }
}
