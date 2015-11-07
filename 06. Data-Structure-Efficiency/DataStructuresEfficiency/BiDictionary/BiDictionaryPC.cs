namespace BiDictionary
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class BiDictionaryPC<K1, K2, T> : IBiDictionary<K1, K2, T>
    {
        private MultiDictionary<K1, MultiDictionary<K2, T>> biDictionary;
        private int count;

        public BiDictionaryPC()
        {
            this.biDictionary = new MultiDictionary<K1, MultiDictionary<K2, T>>(true);
            this.count = 0;
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            MultiDictionary<K2, T> entry = new MultiDictionary<K2, T>(true);
            entry.Add(key2, value);
            this.biDictionary.Add(key1, entry);
            this.count++;
        }

        public List<T> SearchByFirstKey(K1 key1)
        {
            List<T> result = new List<T>();
            if (this.biDictionary.ContainsKey(key1))
            {
                foreach (MultiDictionary<K2, T> dictionaryCollection in this.biDictionary[key1])
                {
                    foreach (KeyValuePair<K2, ICollection<T>> pair in dictionaryCollection)
                    {
                        var foundValues = pair.Value;
                        foreach (var value in foundValues)
                        {
                            result.Add(value);
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Key does not exist");
            }

            return result;
        }

        public List<T> SearchBySecondKey(K2 key2)
        {
            List<T> result = new List<T>();

            foreach (var dictionaryCollection in this.biDictionary)
            {
                foreach (MultiDictionary<K2, T> dictionary in dictionaryCollection.Value)
                {
                    if (dictionary.ContainsKey(key2))
                    {
                        var foundValues = dictionary[key2];
                        foreach (var value in foundValues)
                        {
                            result.Add(value);
                        }
                    }
                }
            }
            if (result.Count == 0)
            {
                throw new ArgumentException("Key does not exist");
            }

            return result;
        }

        public List<T> SearchByTwoKeys(K1 key1, K2 key2)
        {
            List<T> result = new List<T>();
            if (this.biDictionary.ContainsKey(key1))
            {
                foreach (MultiDictionary<K2, T> dictionary in this.biDictionary[key1])
                {
                    if (dictionary.ContainsKey(key2))
                    {
                        var foundValues = dictionary[key2];
                        foreach (var value in foundValues)
                        {
                            result.Add(value);
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Key does not exist");
            }

            return result;
        }
    }
}
