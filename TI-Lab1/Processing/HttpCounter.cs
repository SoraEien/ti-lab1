using HtmlAgilityPack;

namespace TI_Lab1.Processing
{
    internal class HttpCounter
    {
        public async Task<int> HttpCounterFind(string word)
        {
            string searchQuery = word; // Замените на ваш запрос
            string url = "https://www.google.com/search?q=" + Uri.EscapeDataString(searchQuery);

            using HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response);

            // Найдите элемент, который содержит количество результатов
            // Обычно это находится в элементе, который содержит текст "примерно X результатов"
            var resultStatsNode = htmlDoc.DocumentNode;

            if (resultStatsNode != null)
            {
                Console.WriteLine(resultStatsNode.InnerLength);
            }
            else
            {
                Console.WriteLine("Не удалось найти количество результатов.");
            }

            return htmlDoc.RemainderOffset;
        }
    }
}
