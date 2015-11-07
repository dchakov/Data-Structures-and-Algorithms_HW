namespace BiDictionary
{
    using System;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            IBiDictionary<string, int, string> dictionaryPower = new BiDictionaryPC<string, int, string>();
            IBiDictionary<string, int, string> dictionary = new BiDictionary<string, int, string>();

            ReadDataFromFile("../../input.txt", dictionaryPower);
            ReadDataFromFile("../../input.txt", dictionary);

            var searchByFirstKey = dictionaryPower.SearchByFirstKey("Plovdiv");
            var searchByFirstKey1 = dictionary.SearchByFirstKey("Plovdiv");
            Console.WriteLine("Search by name:");
            Console.WriteLine(string.Join(", ", searchByFirstKey));
            Console.WriteLine();
            Console.WriteLine(string.Join(", ", searchByFirstKey1));

            var searchBySecondKey = dictionaryPower.SearchBySecondKey(23);
            Console.WriteLine("Search by age:");
            Console.WriteLine(string.Join(", ", searchBySecondKey));

            var serarchByTwoKeys = dictionaryPower.SearchByTwoKeys("Plovdiv", 20);
            var serarchByTwoKeys1 = dictionary.SearchByTwoKeys("Plovdiv", 20);
            Console.WriteLine("Search by sity and age:");
            Console.WriteLine(string.Join(", ", serarchByTwoKeys));
            Console.WriteLine();
            Console.WriteLine(string.Join(", ", serarchByTwoKeys1));
        }

        private static void ReadDataFromFile(string filePath, IBiDictionary<string, int, string> dictionary)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                while (line != string.Empty && line != null)
                {
                    string[] data = line.Split('|');
                    string name = data[0].Trim();
                    string city = data[1].Trim();
                    int age = int.Parse(data[2].Trim());

                    dictionary.Add(city, age, name);

                    line = reader.ReadLine();
                }
            }
        }
    }
}
