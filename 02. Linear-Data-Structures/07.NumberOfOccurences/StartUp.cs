namespace _07.NumberOfOccurences
{
    using System;

    //Write a program that finds in given array of integers(all belonging to the range[0..1000]) how many times each of them occurs.

    //Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
    //2 → 2 times
    //3 → 4 times
    //4 → 3 times

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = new[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            int[] occurences = new int[1001];

            for (int i = 0; i < numbers.Length; i++)
            {
                occurences[numbers[i]]++;
            }

            for (int j = 0; j < occurences.Length; j++)
            {
                if (occurences[j] != 0)
                {
                    Console.WriteLine("{0} => {1} times", j, occurences[j]);
                }
            }
        }
    }
}
