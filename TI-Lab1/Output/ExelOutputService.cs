using OfficeOpenXml;

namespace TI_Lab1.Output
{
    public class ExelOutputService
    {
        public void ExportToExcel(Dictionary<char, int> data, string filePath)
        {
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Data");
            var column = 1;

            foreach (var item in data)
            {
                worksheet.Cells[1, column].Value = item.Key;
                worksheet.Cells[2, column].Value = item.Value;
                column++;
            }

            FileInfo file = new FileInfo(filePath);
            package.SaveAs(file);
        }

        public void ExportToExcel(Dictionary<string, int> data, string filePath)
        {
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Data");
            var column = 1;

            foreach (var item in data)
            {
                worksheet.Cells[1, column].Value = item.Key;
                worksheet.Cells[2, column].Value = item.Value;
                column++;
            }

            FileInfo file = new FileInfo(filePath);
            package.SaveAs(file);
        }

        public void ExportToExcel(List<(string, string, string, string, string, string, string)> data, string filePath)
        {
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Data");
            var column = 2;

            worksheet.Cells[1, 1].Value = "Word1";
            worksheet.Cells[2, 1].Value = "Word2";
            worksheet.Cells[3, 1].Value = "Html1";
            worksheet.Cells[4, 1].Value = "Html2";
            worksheet.Cells[5, 1].Value = "word1 + word2";
            worksheet.Cells[6, 1].Value = "word2 + word1";
            worksheet.Cells[7, 1].Value = "ngi";

            foreach (var item in data)
            {
                worksheet.Cells[1, column].Value = item.Item1;
                worksheet.Cells[2, column].Value = item.Item2;
                worksheet.Cells[3, column].Value = item.Item3;
                worksheet.Cells[4, column].Value = item.Item4;
                worksheet.Cells[5, column].Value = item.Item5;
                worksheet.Cells[6, column].Value = item.Item6;
                worksheet.Cells[7, column].Value = item.Item7;
                column++;
            }

            FileInfo file = new FileInfo(filePath);
            package.SaveAs(file);
        }

        public void ExportToExcel(Dictionary<string, int> data, string filePath, bool big)
        {
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Data");
            var column = 1;
            var row = 1;

            foreach (var item in data)
            {
                worksheet.Cells[row, column].Value = item.Key;
                worksheet.Cells[row + 1, column].Value = item.Value;
                column++;
                if (column > 50)
                {
                    column = 1;
                    row += 2;
                }
            }

            FileInfo file = new FileInfo(filePath);
            package.SaveAs(file);
        }

        public void ExportToExcel(Dictionary<char, Dictionary<char, int>> data, string filePath)
        {
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Data");
            var column = 2;
            var row0 = 2;

            foreach (var elem in data)
            {
                worksheet.Cells[row0, 1].Value = elem.Key;
                row0++;
            }

            foreach (var item in data)
            {
                worksheet.Cells[1, column].Value = item.Key;

                var row = 2;

                foreach (var elem in item.Value)
                {
                    worksheet.Cells[row, column].Value = elem.Value;
                    row++;
                }
                column++;
            }

            FileInfo file = new FileInfo(filePath);
            package.SaveAs(file);
        }
    }
}
