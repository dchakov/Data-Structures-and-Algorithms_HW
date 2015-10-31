namespace _08.MajorantOfAnArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
    // Write a program to find the majorant of given array(if exists).
    // Example:
    // {2, 2, 3, 3, 2, 3, 4, 3, 3} → 3
    // {1} -> 1

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            int majorant = FindMajorant(numbers);
            numbers.Sort();

            //int counter = 1;
            //for (int i = 0; i < numbers.Count - 1; i++)
            //{
            //    if (numbers[i] == numbers[i + 1])
            //    {
            //        counter++;
            //    }
            //    else if (counter >= numbers.Count / 2 + 1)
            //    {
            //        majorant = numbers[i];
            //        break;
            //    }
            //    else
            //    {
            //        counter = 1;
            //    }
            //}

            Console.WriteLine(majorant == int.MinValue ? "Majorant does not exist" : "The majorant is {0}", majorant);
        }

        private static int FindMajorant(List<int> numbers)
        {
            int majorant = int.MinValue;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (!dictionary.ContainsKey(numbers[i]))
                {
                    dictionary.Add(numbers[i], 1);
                }
                else
                {
                    dictionary[numbers[i]]++;
                }
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine("{0} => {1} times", item.Key, item.Value);
            }
            majorant = dictionary.OrderByDescending(x => x.Value).FirstOrDefault().Key;

            return majorant;
        }
    }
}
