using TI_Lab1.Models;

namespace TI_Lab1.Processing
{
    internal class WordTopMaker
    {
        private WordsWithCounter words;

        public WordTopMaker()
        {

        }


        public WordTopMaker(WordsWithCounter wwc)
        {
            words = wwc;
        }

        public async Task<WordsWithCounter> MakeTop(List<string> allWords)
        {
            foreach (var word in allWords)
            {
                if (words.Word[word] != null)
                    words.Word[word]++;
                else
                    words.Word[word] = 0;
            }
            return words;
        }

        public async Task<IEnumerable<string>> MakeWordsList(string text)
        {
            return text.Split(new char[] { ' ', ',', '.', '!', '?', '”', '“', '[', ']', ':', ';', '(', ')', '-' },
                                                            StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
