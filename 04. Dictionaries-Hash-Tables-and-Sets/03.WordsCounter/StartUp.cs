namespace _03.WordsCounter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            //Write a program that counts how many times each word from given text file words.txt appears in it.The character casing differences should be ignored.The result words should be ordered by their number of occurrences in the text. Example:
            //This is the TEXT.Text, text, text – THIS TEXT!Is this the text?

            string text = string.Empty;
            try
            {
                using (StreamReader reader = new StreamReader("../../input.txt"))
                {
                    text = reader.ReadToEnd();
                    Console.WriteLine(text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            string[] arr = text.Split(new char[] { ',', ' ', '!', '?', '-', '.' }, StringSplitOptions.RemoveEmptyEntries);
            IDictionary<string, int> dictionary = new SortedDictionary<string, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int count = 1;
                if (dictionary.ContainsKey(arr[i].ToLower()))
                {
                    count = dictionary[arr[i].ToLower()] + 1;
                }
                dictionary[arr[i].ToLower()] = count;
            }

            var words = dictionary.OrderBy(x => x.Value);

            foreach (var pair in words)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
