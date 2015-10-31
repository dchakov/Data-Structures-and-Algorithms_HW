namespace _13.DynamicQuene
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DynamicQuene<T> : IEnumerable<T>
    {
        private LinkedList<T> list;

        public DynamicQuene()
        {
            this.list = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public void Enquene(T item)
        {
            this.list.AddLast(item);
        }

        public T Dequene()
        {
            if (this.list.Count == 0)
            {
                throw new ArgumentNullException("Quene is empty");
            }

            T item = this.list.First.Value;
            this.list.RemoveFirst();

            return item;
        }

        public T Peek()
        {
            if (this.list.Count == 0)
            {
                throw new ArgumentNullException("Quene is empty");
            }

            return this.list.First.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
