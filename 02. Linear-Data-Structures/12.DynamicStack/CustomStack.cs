namespace _12.DynamicStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomStack<T> : IEnumerable<T>
    {
        private T[] arr;
        private int count;
        private const int InitialCapacity = 4;

        public CustomStack()
        {
            this.arr = new T[InitialCapacity];
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }

        public void Push(T item)
        {
            if (this.count + 1 == arr.Length)
            {
                T[] extendArr = new T[arr.Length * 2];
                Array.Copy(this.arr, extendArr, arr.Length);
                this.arr = extendArr;
            }
            this.arr[this.count] = item;
            this.count++;

        }

        public T Pop()
        {
            this.count--;
            return this.arr[this.count];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.count; i++)
            {
                yield return this.arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
