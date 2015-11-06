namespace CompanyArticles
{
    using System;
    using System.Globalization;
    using System.IO;
    using Wintellect.PowerCollections;

    public class StartUp
    {
        public static void Main()
        {
            OrderedMultiDictionary<decimal, Article> articles =
                new OrderedMultiDictionary<decimal, Article>(true);

            ReadArticlesInfoFromFile("../../input.txt", articles);

            decimal startRange = 2.45M;
            decimal endRange = 4.80M;
            var searchedValues = articles.Range(startRange, true, endRange, true);

            foreach (var article in searchedValues)
            {
                Console.WriteLine(article.Key + " (Price/Products)");
                foreach (var item in article.Value)
                {
                    Console.WriteLine("   " + item.ToString());
                }
            }
        }

        private static void ReadArticlesInfoFromFile(string filePath, OrderedMultiDictionary<decimal, Article> articles)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                while (line != string.Empty && line != null)
                {
                    string[] data = line.Split('|');
                    int barcode = int.Parse(data[0].Trim());
                    string title = data[1].Trim();
                    string vendor = data[2].Trim();
                    decimal price = Math.Round(Decimal.Parse(data[3].Trim(), CultureInfo.InvariantCulture), 2);

                    articles.Add(price, new Article(barcode, title, vendor, price));

                    line = reader.ReadLine();
                }
            }
        }
    }
}
