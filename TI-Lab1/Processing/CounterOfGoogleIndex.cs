using TI_Lab1.Models;

namespace TI_Lab1.Processing
{
    internal class CounterOfGoogleIndex
    {
        private WordsWithCounter topFromText;
        private WordsWithCounter topFromFull;
        private List<string> topWords;
        private List<(string, string)> topWordsPairs;
        public CounterOfGoogleIndex(WordsWithCounter small, WordsWithCounter big)
        {
            topFromText = small;
            topFromFull = big;
            topWords = new List<string>();
            topWordsPairs = new List<(string, string)>();
        }

        public async Task<Dictionary<string, int>> CountGoogleIndex(Dictionary<string, int> vls)
        {
            var top = vls.OrderByDescending(x => x.Value);
            int cnt = 0;
            var topWords = new Dictionary<string, int>();
            foreach (var word in top)
            {
                topWords[word.Key] = word.Value;
            }
            return topWords;
        }
    }
}
