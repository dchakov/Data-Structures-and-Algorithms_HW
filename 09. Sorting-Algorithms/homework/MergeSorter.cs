namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            T[] bCollection = new T[collection.Count];
            TopDownSplitMerge(collection, 0, collection.Count, bCollection);
        }

        private static void TopDownSplitMerge(IList<T> collection, int iBegin, int iEnd, IList<T> bCollection)
        {
            if ((iEnd - iBegin) < 2)
            {
                return;
            }
            int iMiddle = (iEnd + iBegin) / 2;

            TopDownSplitMerge(collection, iBegin, iMiddle, bCollection);
            TopDownSplitMerge(collection, iMiddle, iEnd, bCollection);
            TopDownMerge(collection, iBegin, iMiddle, iEnd, bCollection);

            for (int k = iBegin; k < iEnd; k++)
            {
                collection[k] = bCollection[k];
            }
        }

        private static void TopDownMerge(IList<T> collection, int iBegin, int iMiddle, int iEnd, IList<T> bCollection)
        {
            int i0 = iBegin;
            int i1 = iMiddle;

            for (int j = iBegin; j < iEnd; j++)
            {
                if (i0 < iMiddle && (i1 >= iEnd || collection[i0].CompareTo(collection[i1]) <= 0))
                {
                    bCollection[j] = collection[i0];
                    i0++;
                }
                else
                {
                    bCollection[j] = collection[i1];
                    i1++;
                }
            }
        }
    }
}
