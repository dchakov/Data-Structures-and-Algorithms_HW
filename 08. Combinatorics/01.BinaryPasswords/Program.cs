namespace _01.BinaryPasswords
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        const int n = 2;
        static int k;
        static int[] objects = new int[n] { 0, 1 };
        static int[] arr;
        static char[] result;
        static int counter;

        static void Main()
        {
            string input = Console.ReadLine();
            result = input.ToCharArray();
            k = Regex.Matches(input, @"\*").Count;
            arr = new int[k];

            GenerateVariationsWithRepetitions(0);
            Console.WriteLine(counter);
        }

        static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= k)
            {
                counter++;
                PrintVariations();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i;
                    GenerateVariationsWithRepetitions(index + 1);
                }
            }
        }

        static void PrintVariations()
        {
            var j = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == '*')
                {
                    Console.Write(objects[arr[j]]);
                    j++;
                }
                else
                {
                    Console.Write(result[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
