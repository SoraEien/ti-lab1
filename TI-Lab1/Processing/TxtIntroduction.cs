using TI_Lab1.Models;

namespace TI_Lab1.Processing
{
    internal class TxtIntroduction
    {
        private string filePath;
        private readonly Alphabet alphabet;

        public string FilePath { get => filePath; set => filePath = value; }

        public async Task<string> InputFromSourse(string sourse)
        {
            try
            {
                FilePath = sourse;
                if (!File.Exists(filePath))
                {
                    Exception ex = new Exception("Файл не найден.");
                }

                string content = File.ReadAllText(filePath).ToLower();
                return content;
            }
            catch
            {
                Exception ex = new Exception("Ошибка при чтении файла.");
                return ex.Message;
            }
        }

        public async Task<LetterCounter> CountTheLetters(string content, LetterCounter letterCounter)
        {
            foreach (char c in content)
            {
                if (letterCounter.KeyValuePairs.ContainsKey(c))
                {
                    letterCounter.KeyValuePairs[c]++;
                }
            }

            for (int i = 0; i < content.Length - 1; i++)
            {
                var firstChar = content[i];
                var secondChar = content[i + 1];

                if (letterCounter.KeyValuePairs.ContainsKey(firstChar))
                    letterCounter.KeyValuePairs[firstChar]++;

                if (letterCounter.pairCount.ContainsKey(firstChar) && letterCounter.pairCount[firstChar].ContainsKey(secondChar))
                {
                    letterCounter.pairCount[firstChar][secondChar]++;
                }
            }
            return letterCounter;
        }
    }
}