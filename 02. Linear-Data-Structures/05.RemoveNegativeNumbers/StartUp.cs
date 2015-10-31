namespace _05.RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;

    // Write a program that removes from given sequence all negative numbers.

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = new List<int>() { 2, 3, -3, 3, -3, 5, 3, -4, -4, 4 };
            List<int> positiveNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= 0)
                {
                    positiveNumbers.Add(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(", ", positiveNumbers));
        }
    }
}
