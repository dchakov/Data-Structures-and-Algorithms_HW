namespace _06.RemoveOddtimesNumbers
{
    using System;
    using System.Collections.Generic;

    // Write a program that removes from given sequence all numbers that occur odd number of times.
    //Example:
    //{4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} → {5, 3, 3, 5}

    public class StartUp
    {
        public static void Main()
        {
            //List<int> numbers = new List<int>() { 1, 1, 1, 1, 1, 3, 2, 3, 2, 5, 2 };
            List<int> numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            List<int> resultSequence = RemoveAllNumbersOcurrences(numbers);

            Console.WriteLine(string.Join(", ", resultSequence));
        }

        private static List<int> RemoveAllNumbersOcurrences(List<int> numbers)
        {
            List<int> resultSequence = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int counter = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[j] == numbers[i])
                    {
                        counter++;
                    }
                }
                if (counter % 2 == 0)
                {
                    resultSequence.Add(numbers[i]);
                }
            }
            return resultSequence;
        }
    }
}
