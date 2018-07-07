using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhoCorasick
{
    class Program
    {
        static void Main(string[] args)
        {
            //The Aho-Corasick Algorithm
            /*Reference
            David Esposito - https://www.youtube.com/watch?v=IcXimoT_YXA
            Roman Vashchegin - https://www.toptal.com/algorithms/aho-corasick-algorithm
            */
            var text = "bcaab";
            var patterns = new List<string> { "a", "ab", "bc", "aab", "aac", "bd" };

            var root = new Trie { CurrentChar = string.Empty };

            var tries = BuildTries(root, patterns);
            tries = BuildFail(tries);

            var results = Match(text, tries);

            Console.WriteLine("The Aho-Corasick Algorithm result - ");
            foreach (DictionaryEntry result in results)
                foreach (var item in (List<int>)result.Value)
                    Console.WriteLine($"{result.Key} found at {item}");
                
            Console.ReadLine();
        }

        private static Hashtable Match(string text, Trie tries)
        {
            var currentNode = tries;
            var i = 0;
            var matches = new Hashtable();
            
            //run each char of text through the trie
            while (i < text.Length)
            {
                //if the currentNode's children contain char from text, set the child as currentNode
                if (currentNode.Children.ContainsKey(text[i].ToString()))
                {
                    var node = (Trie)currentNode.Children[text[i].ToString()];
                    currentNode = node; 
                    if (node.Output.Any())  //if there exists an output, add to Matches Hashtable
                    {
                        foreach (var o in node.Output)
                        {
                            var position = i - o.Length + 1;    //poistion is i-Len(output) + 1
                            var list = new List<int>();
                            if (matches.ContainsKey(o))
                                list = (List<int>)matches[o];

                            list.Add(position);

                            matches[o] = list;
                        }
                        
                         i++;
                    }
                    else
                        i++;
                }
                else
                {
                    //if the currentNode's children do not have the char from text, move to Fail node
                    currentNode = currentNode.FailedLink;
                }
            }
            return matches;
        }

        private static Trie BuildFail(Trie tries)
        {
            var queue = new Queue<Trie>();
            queue.Enqueue(tries);   //BFS traverse

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.CurrentChar == string.Empty)   //identify root
                {
                    node.FailedLink = node; //root should fail to itself
                    foreach (DictionaryEntry child in node.Children)
                    {
                        var c = (Trie)child.Value;
                        c.FailedLink = node;    //root's children should to root as well
                    }
                }
                else
                {
                    var failNode = node.FailedLink;
                    //IMPORTANT - check if the currentNode's char is eqaul to parent's fail node - closest ancestor
                    foreach (DictionaryEntry child in node.Children)    
                    {
                        var s = (Trie)child.Value;
                        if (failNode.Children.ContainsKey(s.CurrentChar))
                        {
                            var newFailedLink = (Trie)failNode.Children[s.CurrentChar];
                            s.FailedLink = newFailedLink;   //if yes, point currentNode's fail node to the closest ancestor

                            s.Output.AddRange(newFailedLink.Output);    //add the ancestor's output to the currentNode's output
                        }
                        else
                            s.FailedLink = tries;   //If not, point the currentNode's fail node to root
                    }
                }


                //add currentNode's children to Queue
                if (node.Children.Count > 0)
                    foreach (DictionaryEntry child in node.Children)
                        queue.Enqueue((Trie)child.Value);
            }
            return tries;
        }

        private static Trie BuildTries(Trie root, List<string> patterns)
        {
            Trie currentNode;

            foreach (var pattern in patterns)
            {
                currentNode = root; //start from root for each pattern
                var i = 0;
                while (i < pattern.Length)
                {
                    //if the current node contains a child that has the same char as in the pattern's char, keep traversing if same char appears in children
                    if (currentNode.Children.ContainsKey(pattern[i].ToString()))
                    {
                        while (currentNode.Children.Count != 0 && currentNode.Children.ContainsKey(pattern[i].ToString()))
                        {
                            currentNode = (Trie)currentNode.Children[pattern[i].ToString()];
                            i++;    //increment the pointer 
                        }
                    }
                    var output = new List<string>();

                    if (i == (pattern.Length - 1))  //if it is a leaf, all the pattern to the new child
                        output.Add(pattern);    

                    //add new child with output
                    var newChild = new Trie
                    {
                        CurrentChar = pattern[i].ToString(),
                        Output = output
                    };
                    currentNode.Children[pattern[i].ToString()] = newChild;
                    currentNode = (Trie)currentNode.Children[pattern[i].ToString()];    // let the new node be the currentNode
                    i++;    //move on the next char
                    
                }
            }
            return root;
        }
    }

    public class Trie
    {
        public string CurrentChar { get; set; } //Save the char that this trie houses
        public Hashtable Children { get; set; }
        public List<string> Output { get; set; } //there could be more than 1 output string for a trie
        public Trie FailedLink { get; set; }    // failback link

        public Trie()
        {
            Children = new Hashtable();
        }
    }
}
