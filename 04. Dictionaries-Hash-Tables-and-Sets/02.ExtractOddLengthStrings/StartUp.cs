namespace _02.ExtractOddLengthStrings
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            // Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. 

            string[] arr = new[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            IDictionary<string, int> dictionary = new Dictionary<string, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int count = 1;
                if (dictionary.ContainsKey(arr[i]))
                {
                    count = dictionary[arr[i]] + 1;
                }
                dictionary[arr[i]] = count;
            }

            foreach (var pair in dictionary)
            {
                if (pair.Value % 2 != 0)
                {
                    Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
                }
            }
        }
    }
}
