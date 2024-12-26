namespace TI_Lab1.Models
{
    public class LetterCounter
    {
        private readonly Alphabet alphabet = new Alphabet();
        public Dictionary<char, int> KeyValuePairs = new Dictionary<char, int>();
        public Dictionary<char, Dictionary<char, int>> pairCount = new Dictionary<char, Dictionary<char, int>>();

        public LetterCounter()
        {
            foreach (char letter in alphabet.RusAlphabet)
            {
                KeyValuePairs[letter] = 0;
            }

            foreach (char firstChar in alphabet.RusAlphabet)
            {
                pairCount[firstChar] = new Dictionary<char, int>();
                foreach (char secondChar in alphabet.RusAlphabet)
                {
                    pairCount[firstChar][secondChar] = 0;
                }
            }
        }
    }
}
