namespace _01.CalculateSumAndAverageOfSeq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Write a program that reads from the console a sequence of positive integer numbers.
    // The sequence ends when empty line is entered.
    // Calculate and print the sum and average of the elements of the sequence.
    // Keep the sequence in List<int>.

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = new List<int>();

            while (true)
            {
                string current = Console.ReadLine();
                if (current == string.Empty)
                {
                    break;
                }
                numbers.Add(int.Parse(current));
            }

            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Average());
        }
    }
}
