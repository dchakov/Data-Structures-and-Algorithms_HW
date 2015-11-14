namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            QuickSort(collection, 0, collection.Count - 1);
        }

        private static void QuickSort(IList<T> arr, int lo, int hi)
        {
            if (lo < hi)
            {
                int p = Partition(arr, lo, hi);
                QuickSort(arr, lo, p - 1);
                QuickSort(arr, p + 1, hi);
            }
        }

        private static int Partition(IList<T> arr, int lo, int hi)
        {
            int pivotIndex = (lo + hi) / 2;
            T pivotValue = arr[pivotIndex];
            arr[pivotIndex] = arr[hi];
            arr[hi] = pivotValue;

            int storeIndex = lo;
            T temp;
            for (int i = lo; i <= hi - 1; i++)
            {
                if (arr[i].CompareTo(pivotValue) <= 0)
                {
                    temp = arr[i];
                    arr[i] = arr[storeIndex];
                    arr[storeIndex] = temp;
                    storeIndex++;
                }
            }

            temp = arr[storeIndex];
            arr[storeIndex] = arr[hi];
            arr[hi] = temp;

            return storeIndex;
        }
    }
}
