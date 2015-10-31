namespace _11.LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable
    {
        private ListItem<T> firstItem;

        public LinkedList()
        {
        }

        public LinkedList(ListItem<T> firstItem)
        {
            this.firstItem = firstItem;
        }

        public ListItem<T> FirstElement { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            var newItem = this.FirstElement;

            while (newItem != null)
            {
                yield return newItem.Value;
                newItem = newItem.NextItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
