namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var n = collection.Count;
            int i, j;

            for (j = 0; j < n - 1; j++)
            {
                int iMin = j;
                for (i = j + 1; i < n; i++)
                {
                    if (collection[i].CompareTo(collection[iMin]) < 0)
                    {
                        iMin = i;
                    }
                }
                if (iMin != j)
                {
                    var smallest = collection[iMin];
                    collection[iMin] = collection[j];
                    collection[j] = smallest;
                }
            }
        }
    }
}
