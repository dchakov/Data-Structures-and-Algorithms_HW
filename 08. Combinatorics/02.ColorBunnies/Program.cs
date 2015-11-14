namespace _02.ColorBunnies
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            var result = 0;
            int numberOfBunnies = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBunnies; i++)
            {
                var current = int.Parse(Console.ReadLine());
                if (!dict.ContainsKey(current))
                {
                    dict[current] = 1;
                }
                else
                {
                    dict[current]++;
                }
            }
            foreach (var item in dict)
            {
                if (item.Value > 1)
                {
                    result += (item.Key + 1) * (int)Math.Ceiling((double)item.Value / (item.Key + 1));
                }
                else
                {
                    result += item.Key + 1;
                }
            }
            Console.WriteLine(result);
        }
    }
}
