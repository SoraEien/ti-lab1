using TI_Lab1.Models;
using TI_Lab1.Output;
using TI_Lab1.Processing;

namespace TI_Lab1.MainBlock
{
    internal class СountMaker
    {
        private List<string> bestWords = new List<string>();
        private HttpCounter httpCounter = new HttpCounter();
        public СountMaker()
        {
            TxtIntroduction txtIntroduction = new TxtIntroduction();
            ExelOutputService exelOutputService = new ExelOutputService();

            var text = txtIntroduction.InputFromSourse("forinput.txt").Result;
            var fulltext = txtIntroduction.InputFromSourse("kapital.txt").Result;

            var tmp = new WordTopMaker();

            var words = tmp.MakeWordsList(text).Result.ToList();
            var fullWords = tmp.MakeWordsList(fulltext).Result.ToList();

            var textWithTop = new WordsWithCounter(words);
            var fullTextWithTop = new WordsWithCounter(fullWords);

            WordTopMaker wordTopMaker = new WordTopMaker(textWithTop);
            WordTopMaker wordTopMaker2 = new WordTopMaker(fullTextWithTop);

            var topFromInput = wordTopMaker.MakeTop(words).Result;
            var topFromFull = wordTopMaker2.MakeTop(fullWords).Result;

            var cgi = new CounterOfGoogleIndex(topFromInput, topFromFull);

            var tmb = cgi.CountGoogleIndex(topFromInput.Word).Result;
            var tmb2 = cgi.CountGoogleIndex(topFromFull.Word).Result;

            exelOutputService.ExportToExcel(tmb, "TopWordsFromInput.xlsx");
            exelOutputService.ExportToExcel(tmb2, "TopWordsFromFull.xlsx", true);

            //bestWords.Add("производство");
            //bestWords.Add("более");
            //bestWords.Add("стоимость");
            //bestWords.Add("исследования");
            //bestWords.Add("развитие");
            //bestWords.Add("форма");

            //var full = httpCounter.HttpCounterFind("в").Result;

            //var list = new List<(string, string, string, string, string, string, string)>();

            //foreach (var word1 in bestWords)
            //{
            //    foreach (var word2 in bestWords)
            //    {
            //        var res1 = httpCounter.HttpCounterFind(word1).Result;
            //        var res2 = httpCounter.HttpCounterFind(word2).Result;
            //        var res3 = httpCounter.HttpCounterFind(word1 + word2).Result;
            //        var res4 = httpCounter.HttpCounterFind(word2 + word1).Result;
            //        double ngi = (Math.Max(Math.Log(res1), Math.Log(res2)) - Math.Max(Math.Log(res3), Math.Log(res4))) / (Math.Log(full) - Math.Min(Math.Log(res1), Math.Log(res2)));

            //        list.Add((word1.ToString(), word2.ToString(), res1.ToString(), res2.ToString(), res3.ToString(), res4.ToString(), ngi.ToString()));
            //    }
            //}

            //exelOutputService.ExportToExcel(list, "HtmlRequestsRes.xlsx");
        }
    }
}
