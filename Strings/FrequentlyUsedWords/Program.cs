using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequentlyUsedWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashPuncs = new Hashtable();
            var hashExclList = new Hashtable();
            var hashAllAlphas = new Hashtable();
            var hashFoundWords = new Hashtable();

            var puncsAndSpace = new List<string> { " ", ".", ",", "?", "!", "'", ":", ";", "...", "-" };
            var exclusionList = new List<string> { "and", "he", "the", "to", "is", "Jack", "Jill" };
            var allAphas = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "h", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            var text = "Jack and Jill went went to the market to buy bread and cheese Cheese is Jack's and Jill's favourite food.";

            foreach (var item in puncsAndSpace)
                hashPuncs[item] = item;

            foreach (var item in exclusionList)
                hashExclList[item.ToLower()] = item;

            foreach (var item in hashAllAlphas)
                hashAllAlphas[item] = item;

            var i = 0;
            var str = string.Empty;

            while (i < text.Length)
            {
                if (!hashPuncs.ContainsKey(text[i].ToString()) || hashAllAlphas.ContainsKey(text[i].ToString().ToLower()))
                    str = str + text[i];
                else
                {
                    if (str != string.Empty && !hashExclList.ContainsKey(str.ToLower()))
                    {
                        if (hashFoundWords.ContainsKey(str.ToLower()))
                            hashFoundWords[str.ToLower()] = (int)hashFoundWords[str.ToLower()] + 1;
                        else
                            hashFoundWords[str.ToLower()] = 1;
                        
                    }
                    str = string.Empty;
                }
                i++;
            }

            var results =
                (from DictionaryEntry item in hashFoundWords
                 where (int)item.Value > 1
                 select item.Key.ToString()).ToList();


        }
    }
}
