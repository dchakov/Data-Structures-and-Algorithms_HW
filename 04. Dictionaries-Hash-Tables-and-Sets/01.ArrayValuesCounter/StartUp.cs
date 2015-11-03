namespace _01.ArrayValuesCounter
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            //Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
            
            double[] arr = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            IDictionary<double, int> dictionary = new SortedDictionary<double, int>();

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
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
