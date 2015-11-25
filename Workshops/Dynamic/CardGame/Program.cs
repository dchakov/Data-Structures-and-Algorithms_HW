namespace CardGame
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = Console.ReadLine().Split(' ')
                .Select(a => int.Parse(a)).ToArray();

            int[,] arr = new int[n, n];

            for (int lenght = 3; lenght <= n; lenght++)
            {
                for (int i = 0; i <= n - lenght; i++)
                {
                    for (int j = i + 1; j < i + lenght - 1; j++)
                    {
                        int current = arr[i, j] + arr[j, i + lenght - 1]
                             + numbers[j] * (numbers[i] + numbers[i + lenght - 1]);

                        if (arr[i, i + lenght - 1] < current)
                        {
                            arr[i, i + lenght - 1] = current;
                        }
                    }
                }
            }
            Console.WriteLine(arr[0, n - 1]);
        }
    }
}
