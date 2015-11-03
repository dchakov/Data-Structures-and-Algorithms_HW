namespace HashTable
{
    using System.Collections;
    using System.Collections.Generic;

    /*
    Implement the data structure set in a class HashedSet<T> using your class HashTable<K,T> to hold the elements. Implement all standard set operations like
    Add(T)
    Find(T)
    Remove(T)
    Count
    Clear()
    union and
    intersect
    */

    public class HashedSet<T> : IEnumerable<T>
    {
        HashTable<T, T> hashTable;

        public HashedSet()
        {
            this.hashTable = new HashTable<T, T>();
        }

        public int Count
        {
            get
            {
                return this.hashTable.Count;
            }
        }

        public void Add(T item)
        {
            this.hashTable.Add(item, item);
        }

        public T Find(T item)
        {
            return this.hashTable.Find(item);
        }

        public void Remove(T item)
        {
            this.hashTable.Remove(item);
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }

        public void Union(HashedSet<T> hashedSet)
        {
            foreach (var item in hashedSet)
            {
                if (!(this.hashTable.ContainsKey(item)))
                {
                    this.Add(item);
                }
            }
        }

        public void Intersect(HashedSet<T> hashedSet)
        {
            HashTable<T, T> newtable = new HashTable<T, T>();
            foreach (var item in hashedSet)
            {
                if (this.hashTable.ContainsKey(item))
                {
                    newtable.Add(item, item);
                }
            }
            this.hashTable = newtable;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.hashTable.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.hashTable.Keys.GetEnumerator();
        }
    }
}
