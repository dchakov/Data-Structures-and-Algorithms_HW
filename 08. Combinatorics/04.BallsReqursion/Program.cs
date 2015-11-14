namespace _04.BallsReqursion
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static HashSet<string> hash;

        static void Main(string[] args)
        {
            char[] arr = Console.ReadLine().ToCharArray();
            hash = new HashSet<string>();
            GeneratePermutations(arr, 0);
            Console.WriteLine(hash.Count);
        }

        static void GeneratePermutations(char[] arr, int k)
        {
            if (k >= arr.Length)
            {
                hash.Add(string.Join("", arr));
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    if (arr[k]!=arr[i])
                    {
                        Swap(ref arr[k], ref arr[i]);
                        GeneratePermutations(arr, k + 1);
                        Swap(ref arr[k], ref arr[i]);
                    }
                }
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
