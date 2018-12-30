using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoComplete
{
    public interface IKeywordMatcher
    {
        /*
         The general idea of trie is to represent a number of strings in a single tree structure.
         Each edge represents a character choice
             
             */
        void Init();
        IEnumerable<string> Match(string query, int maxMatched);
        int Count();
    }
}
