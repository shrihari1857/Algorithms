using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = wordSquares(
                new string[]
                {
                    "ball","area","lead","lady"
                });
        }

        public static List<ArrayList> wordSquares(String[] words)
        {
            TrieNode root = buildTrie(words);
            var squares = new List<ArrayList>();

            foreach(var word in words)
            {
                var square = new List<string>();
                square.Add(word);
                wordSquares(root, word.Length, square, squares);
            }
            return squares;
        }

        private static TrieNode buildTrie(string[] words)
        {
            TrieNode root = new TrieNode();
            foreach(string word in words)
            {
                TrieNode current = root;
                foreach (char c in word)
                {
                    int index = c - 'a';
                    if (current.children[index] == null)
                    {
                        current.children[index] = new TrieNode();
                    }
                    current = current.children[index];
                }
                current.isWord = true;
            }
            return root;
        }

        private static void wordSquares(TrieNode root, int len, List<string> square, List<ArrayList> squares)
        {
            if (square.Count == len)
            {
                squares.Add(new ArrayList(square));
                return;
            }

            String prefix = getPrefix(square, square.Count);
            TrieNode node = search(root, prefix);
            if (node == null)
            {
                return;
            }

            List<String> children = new List<String>();
            getChildren(node, prefix, children);
            foreach(String child in children)
            {
                square.Add(child);
                wordSquares(root, len, square, squares);
                square.RemoveAt(square.Count - 1);
            }
        }
        private static String getPrefix(List<String> square, int index)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < index; i++)
            {
                sb.Append(square[i][index]);
            }
            return sb.ToString();
        }

        private static TrieNode search(TrieNode root, String prefix)
        {
            TrieNode current = root;
            foreach(char c in prefix)
            {
                int index = c - 'a';
                if (current.children[index] == null)
                {
                    return null;
                }
                current = current.children[index];
            }
            return current;
        }

        private static void getChildren(TrieNode node, String s, List<String> children)
        {
            if (node.isWord)
            {
                children.Add(s);
                return;
            }

            for (int i = 0; i < 26; i++)
            {
                if (node.children[i] != null)
                {
                    getChildren(node.children[i], s + (char)('a' + i), children);
                }
            }
        }
    }

    public class TrieNode
    {
        public TrieNode[] children;
        public bool isWord;

        public TrieNode()
        {
            children = new TrieNode[26];
        }
    }
}
