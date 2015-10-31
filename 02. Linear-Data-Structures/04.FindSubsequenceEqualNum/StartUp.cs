namespace _04.FindSubsequenceEqualNum
{
    using System;
    using System.Collections.Generic;

    // Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.
    // Write a program to test whether the method works correctly.

    public class StartUp
    {
        public static void Main()
        {
            List<int> list = new List<int>() { 2, 3, 3, 3, 3, 5, 3, 4, 4, 4 };

            List<int> longestSequence = FindLongestSubsequence(list);
            Console.WriteLine(string.Join(", ", longestSequence));
            Console.WriteLine(longestSequence.Count == 4);
            Console.WriteLine(longestSequence[0] == 3);
        }

        private static List<int> FindLongestSubsequence(List<int> list)
        {
            List<int> longestSubsequence = new List<int>();
            int currentCounter = 1;
            int maxCounter = 0;
            int currentNumber = int.MinValue;
            int number = 0;

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] == list[i - 1])
                {
                    currentCounter++;
                    currentNumber = list[i - 1];
                }
                else
                {
                    currentCounter = 1;
                }
                if (currentCounter >= maxCounter)
                {
                    number = currentNumber;
                    maxCounter = currentCounter;
                }
            }
            for (int i = 0; i < maxCounter; i++)
            {
                longestSubsequence.Add(number);
            }

            return longestSubsequence;
        }
    }
}
