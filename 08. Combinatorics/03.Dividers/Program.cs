namespace _03.Dividers
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static List<int> numArr = new List<int>();

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int[] arr = new int[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            GeneratePermutations(arr, 0);
            var counter = 0;
            var min = int.MaxValue;
            var result = 0;
            foreach (var item in numArr)
            {
                for (int i = 1; i < item; i++)
                {
                    if (item % i == 0)
                    {
                        counter++;
                    }
                }
                if (min > counter)
                {
                    min = counter;
                    result = item;
                }
                if (min == counter)
                {
                    result = result > item ? item : result;
                }
                counter = 0;
            }
            Console.WriteLine(result);
        }

        static void GeneratePermutations<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Print<T>(T[] arr)
        {
            //Console.WriteLine(string.Join("", arr));
            numArr.Add(int.Parse(string.Join("", arr)));
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
