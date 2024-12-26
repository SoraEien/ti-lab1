using TI_Lab1.Models;

namespace TI_Lab1.Output
{
    internal class PrintWord
    {
        private readonly Alphabet alphabet = new Alphabet();
        private Random random;
        private int count;
        private LetterCounter letterCounter;

        public PrintWord(LetterCounter lettersCnt, int countOfLetter = 30)
        {
            random = new Random();
            count = countOfLetter;
            letterCounter = lettersCnt;
        }

        public async Task<string> MakeZeroString()
        {
            return MakeString(alphabet.RusAlphabet).Result;
        }

        public async Task<string> MakeFirstString()
        {
            var str = CreateRandomToList().Result;

            return MakeString(str).Result;
        }

        public async Task<string> MakeSecondString()
        {
            var str = CreateRandomToMatrix().Result;

            return MakeString(str).Result;
        }

        private async Task<string> CreateRandomToList()
        {
            string result = "";
            foreach (var letter in letterCounter.KeyValuePairs)
            {
                for (int i = 0; i < letter.Value; i++)
                {
                    result += letter.Key.ToString();
                }
            }
            return result;
        }

        private async Task<string> CreateRandomToList(Dictionary<char, int> dict)
        {
            string result = "";
            foreach (var letter in dict)
            {
                for (int i = 0; i < letter.Value; i++)
                {
                    result += letter.Key.ToString();
                }
            }
            return result;
        }

        private async Task<Dictionary<char, string>> CreateRandomToMatrix()
        {
            string element;
            var result = new Dictionary<char, string>();

            foreach (var letters in letterCounter.pairCount)
            {
                result[letters.Key] = CreateRandomToList(letters.Value).Result;
            }

            return result;
        }

        private async Task<string> MakeString(string alpha)
        {
            var res = "";
            for (var i = 0; i < count; i++)
            {
                var index = random.Next(alpha.Length);
                res += alpha[index];
            }
            if (res.Count() == 0)
                return new Exception("Предложение не создано").Message;

            return res.ToString();
        }

        private async Task<string> MakeString(Dictionary<char, string> alpha)
        {
            var res = "";

            var current = ' ';

            for (var i = 0; i < count; i++)
            {
                var index = random.Next(alpha[current].Length);
                res += alpha[current][index];
                current = alpha[current][index];
            }
            if (res.Count() == 0)
                return new Exception("Предложение не создано").Message;

            return res.ToString();
        }
    }
}
