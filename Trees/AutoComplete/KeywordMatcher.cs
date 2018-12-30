using Gma.DataStructures.StringSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoComplete
{
    public class KeywordMatcher : IKeywordMatcher
    {
        public ITrie<int> _trieInstance { get; }
        public WordProvider _wordProvider;
        public KeywordMatcher(ITrie<int> trieInstance)
        {
            _trieInstance = trieInstance;
            _wordProvider = new WordProvider();
        }

        

        public int Count()
        {
            return _wordProvider.Words.Count();
        }

        public void Init()
        {
            var index = 0;
            foreach (var word in _wordProvider.Words)
                _trie.Add(word.ToLower(), index++);
        }

        public IEnumerable<string> Match(string query, int maxMatches)
        {
            var results = _trie.Retrieve(query.ToLower()).Take(maxMatches);
            var words = results.Select(x => _wordProvider.Words[x].ToLower());
            return words;
        }
    }
}
