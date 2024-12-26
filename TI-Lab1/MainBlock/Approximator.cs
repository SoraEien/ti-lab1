using TI_Lab1.Models;
using TI_Lab1.Output;
using TI_Lab1.Processing;

namespace TI_Lab1.MainBlock
{
    internal class Approximator
    {
        public Approximator()
        {
            LetterCounter letterCounter = new LetterCounter();
            TxtIntroduction txtIntroduction = new TxtIntroduction();
            ExelOutputService exelOutputService = new ExelOutputService();

            var text = txtIntroduction.InputFromSourse("forinput.txt").Result;
            letterCounter = txtIntroduction.CountTheLetters(text, letterCounter).Result;

            PrintWord printWord = new PrintWord(letterCounter);

            var zeroRes = printWord.MakeZeroString().Result;

            var firstRes = printWord.MakeFirstString().Result;

            var secondRes = printWord.MakeSecondString().Result;

            Console.WriteLine(zeroRes);
            Console.WriteLine(firstRes);
            Console.WriteLine(secondRes);

            exelOutputService.ExportToExcel(letterCounter.KeyValuePairs, "listOut.xlsx");
            exelOutputService.ExportToExcel(letterCounter.pairCount, "matrixOut.xlsx");
        }
    }
}
