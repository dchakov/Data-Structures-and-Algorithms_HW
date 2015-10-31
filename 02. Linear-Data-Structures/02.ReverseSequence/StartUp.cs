namespace _02.ReverseSequence
{
    using System;
    using System.Collections.Generic;

    // Write a program that reads N integers from the console and reverses them using a stack.
    // Use the Stack<int> class.

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("Please enter number of integers:");
            int numberOfIntegers = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(numberOfIntegers);

            for (int i = 0; i < numberOfIntegers; i++)
            {
                stack.Push(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
