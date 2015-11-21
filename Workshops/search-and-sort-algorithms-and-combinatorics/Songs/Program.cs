namespace Songs
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            /*
            5
            3 1 2 5 4
            5 3 2 1 4

            3->0
            1->1
            2->2
            5->3
            4->4

            0 1 2 3 4
            3 0 2 1 4
            */

            int n = int.Parse(Console.ReadLine());

            var array1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var array2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rename = new int[n + 1];

            for (int i = 0; i < n; i++)
            {
                rename[array1[i]] = i;
            }

            for (int i = 0; i < n; i++)
            {
                array2[i] = rename[array2[i]];
            }

            //var inversions = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = i + 1; j < n; j++)
            //    {
            //        if (array2[i] > array2[j])
            //        {
            //            inversions++;
            //        }
            //    }
            //}
            //Console.WriteLine(inversions);

            Console.WriteLine(CountInversions(array2, 0, n));
        }

        static long CountInversions(int[] array, int left, int right)
        {
            if (left + 1 == right)
            {
                return 0;
            }

            int middle = (left + right) / 2;
            long inversions = CountInversions(array, left, middle) 
                            + CountInversions(array, middle, right);

            int[] sorted = new int[right - left];
            int i = left;
            int j = middle;
            int k = 0;

            while (i < middle && j < right)
            {
                if (array[i] < array[j])
                {
                    sorted[k] = array[i];
                    i++;
                }
                else
                {
                    inversions += middle - i;
                    sorted[k] = array[j];
                    j++;
                }
                k++;
            }

            while (i < middle)
            {
                sorted[k] = array[i];
                i++;
                k++;
            }

            while (j < right)
            {
                sorted[k] = array[j];
                j++;
                k++;
            }

            for (k = 0; k < sorted.Length; k++)
            {
                array[left + k] = sorted[k];
            }

            return inversions;
        }
    }
}

