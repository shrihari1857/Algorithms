using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterComibinationBacktracking
{
    class Program
    {
        public static List<string> collection = new List<string>();
        public static Hashtable hTable = new Hashtable();
        static void Main(string[] args)
        {
            hTable.Add("2", new List<string>{"a", "b", "c"});
            hTable.Add("3", new List<string>{"d", "e", "f"});
            hTable.Add("4", new List<string>{"g", "h", "i"});
            hTable.Add("5", new List<string>{"j", "k", "l"});
            hTable.Add("6", new List<string>{"m", "n", "o"});
            hTable.Add("7", new List<string>{"p", "q", "r", "s"});
            hTable.Add("8", new List<string>{"t", "u", "v"});
            hTable.Add("9", new List<string>{"x", "y", "z"});

            var digits = "23";

            var result = LetterCombinations(digits, 0, string.Empty, collection);
        }

        private static List<string> LetterCombinations(string digits, int index, string str, List<string> collection)
        {
            if (digits.Length == 0)
                return collection;

            Combinations(digits, index, str, collection);
            return collection;
        }

        private static void Combinations(string digits, int index, string str, List<string> collection)
        {
            if(str.Length >= digits.Length)
            {
                collection.Add(str);
                return;
            }

            List<string> alphas = (List<string>)hTable[digits[index].ToString()];

            foreach (var alpha in alphas)
            {
                Combinations(digits, index + 1, str + alpha, collection);
            }
        }
    }
}
