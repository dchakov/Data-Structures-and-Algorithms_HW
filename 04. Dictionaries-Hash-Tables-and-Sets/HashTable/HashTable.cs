namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /*
    Implement the data structure hash table in a class HashTable<K,T>. Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) with initial capacity of 16. When the hash table load runs over 75%, perform resizing to 2 times larger capacity. Implement the following methods and properties:
    Add(key, value)
    Find(key)->value
    Remove(key)
    Count
    Clear()
    this[]
    Keys
    */

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const int InitialCapacity = 16;
        private const float LoadFactor = 0.75f;
        private LinkedList<KeyValuePair<K, T>>[] hashTable;
        private int count;
        private int currentLoad;
        private int currentCapacity;

        public HashTable(int capacity)
        {
            this.hashTable = new LinkedList<KeyValuePair<K, T>>[capacity];
            this.count = 0;
            this.currentCapacity = capacity;
        }

        public HashTable()
            : this(InitialCapacity)
        {
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.currentCapacity;
            }
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                if (this.ContainsKey(key))
                {
                    this.Remove(key);
                    this.Add(key, value);
                }
                else
                {
                    this.Add(key, value);
                }
            }
        }

        public List<K> Keys
        {
            get
            {
                List<K> keys = new List<K>();
                foreach (var list in this.hashTable)
                {
                    if (list != null)
                    {
                        foreach (var pair in list)
                        {
                            keys.Add(pair.Key);
                        }
                    }
                }

                return keys;
            }
        }

        public void Add(K key, T value)
        {
            if (currentLoad > hashTable.Length * 0.75)
            {
                Resize();
            }
            int hashCode = GetHash(key);
            if (hashTable[hashCode] == null)
            {
                var newList = new LinkedList<KeyValuePair<K, T>>();
                newList.AddFirst(new KeyValuePair<K, T>(key, value));
                hashTable[hashCode] = newList;
                count++;
                currentLoad++;
            }
            else
            {
                foreach (var item in hashTable[hashCode])
                {
                    if (item.Key.Equals(key))
                    {
                        throw new ArgumentOutOfRangeException("Key is already in a HashTable");
                    }
                }
                hashTable[hashCode].AddLast(new KeyValuePair<K, T>(key, value));
            }
        }

        public T Find(K key)
        {
            if (hashTable[GetHash(key)] != null)
            {
                foreach (KeyValuePair<K, T> item in hashTable[GetHash(key)])
                {
                    if (key.Equals(item.Key))
                    {
                        return item.Value;
                    }
                }
            }
            throw new ArgumentOutOfRangeException("Key not exist.");
        }

        public bool ContainsKey(K key)
        {
            if (hashTable[GetHash(key)] != null)
            {
                foreach (var item in this.hashTable[GetHash(key)])
                {
                    if (key.Equals(item.Key))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Remove(K key)
        {
            int hashCode = GetHash(key);
            if (hashTable[hashCode] == null)
            {
                return;
            }
            var pairToRemove = new KeyValuePair<K, T>();
            foreach (var item in hashTable[hashCode])
            {
                if (item.Key.Equals(key))
                {
                    pairToRemove = item;
                }
            }
            hashTable[hashCode].Remove(pairToRemove);
            this.count--;
        }

        public void Clear()
        {
            this.hashTable = new LinkedList<KeyValuePair<K, T>>[InitialCapacity];
            this.count = 0;
            this.currentLoad = 0;
        }

        private void Resize()
        {
            this.currentCapacity *= 2;
            LinkedList<KeyValuePair<K, T>>[] oldHashTable = this.hashTable;
            LinkedList<KeyValuePair<K, T>>[] newHashTable = new LinkedList<KeyValuePair<K, T>>[currentCapacity];
            hashTable = newHashTable;
            count = 0;
            currentLoad = 0;
            foreach (var item in oldHashTable)
            {
                if (item != null)
                {
                    foreach (KeyValuePair<K, T> element in item)
                    {
                        Add(element.Key, element.Value);
                    }
                }
            }
        }

        private int GetHash(K key)
        {
            return Math.Abs(key.GetHashCode() % hashTable.Length);
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var list in this.hashTable)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
