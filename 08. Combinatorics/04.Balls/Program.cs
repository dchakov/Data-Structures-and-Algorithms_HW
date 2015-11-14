namespace _04.Balls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            char[] arr = Console.ReadLine().ToCharArray();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                {
                    dict[arr[i]] = 1;
                }
                else
                {
                    dict[arr[i]]++;
                }
            }
            List<int> list = dict.Values.ToList();
            list.Sort();

            long result = Factorial(arr.Length, list.Last());
            for (int i = 0; i < list.Count - 1; i++)
            {
                result /= Factorial(list[i], 1);
            }
           
            Console.WriteLine(result);
        }

        private static long Factorial(int num, int last)
        {
            if (num == last)
            {
                return 1;
            }
            else
            {
                return num * Factorial(num - 1, last);
            }
        }
    }
}
