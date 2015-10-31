namespace _03.SortSequenceOfIntegers
{
    using System;
    using System.Collections.Generic;

    // Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.

    public class StartUp
    {
        public static void Main()
        {
            List<int> list = new List<int>();
            string current;

            while (true)
            {
                current = Console.ReadLine();
                if (current == string.Empty)
                {
                    break;
                }
                list.Add(int.Parse(current));
            }
            list.Sort();
            Console.WriteLine(string.Join(", ",list));
        }
    }
}
