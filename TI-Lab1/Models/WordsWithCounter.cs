using TI_Lab1.Processing;

namespace TI_Lab1.Models
{
    internal class WordsWithCounter
    {
        private TxtIntroduction txtIntroduction = new TxtIntroduction();

        public Dictionary<string, int> Word = new Dictionary<string, int>();

        public WordsWithCounter(List<string> fulltext)
        {
            foreach (var word in fulltext)
            {
                Word[word] = 0;
            }
        }
    }
}
