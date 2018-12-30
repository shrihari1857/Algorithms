using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gma.DataStructures.StringSearch;

namespace AutoComplete
{
    public class KeywordPrefixMatcher : KeywordMatcher
    {
        public KeywordPrefixMatcher(ITrie<int> trieInstance) : base(trieInstance)
        {
        }
    }
}
