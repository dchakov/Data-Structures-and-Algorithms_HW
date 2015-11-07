namespace BiDictionary
{
    using System.Collections.Generic;

    public class BiDictionary<K1, K2, T> : IBiDictionary<K1, K2, T>
    {
        private Dictionary<K1, List<KeyValuePair<int, T>>> key1;
        private Dictionary<K2, List<KeyValuePair<int, T>>> key2;
        private int count;

        public BiDictionary()
        {
            this.key1 = new Dictionary<K1, List<KeyValuePair<int, T>>>();
            this.key2 = new Dictionary<K2, List<KeyValuePair<int, T>>>();
            this.count = 0;
        }

        public Dictionary<K1, List<KeyValuePair<int, T>>> Key1
        {
            get
            {
                return this.key1;
            }
            set
            {
                this.key1 = value;
            }
        }

        public Dictionary<K2, List<KeyValuePair<int, T>>> Key2
        {
            get
            {
                return this.key2;
            }
            set
            {
                this.key2 = value;
            }
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            KeyValuePair<int, T> newEntry = new KeyValuePair<int, T>(this.count, value);
            if (this.Key1.ContainsKey(key1))
            {
                this.Key1[key1].Add(newEntry);
            }
            else
            {
                this.Key1.Add(key1, new List<KeyValuePair<int, T>>() { newEntry });
            }

            if (this.Key2.ContainsKey(key2))
            {
                this.Key2[key2].Add(newEntry);
            }
            else
            {
                this.Key2.Add(key2, new List<KeyValuePair<int, T>>() { newEntry });
            }

            this.count++;
        }

        public List<T> SearchByTwoKeys(K1 key1, K2 key2)
        {
            List<T> rezult = new List<T>();
            List<KeyValuePair<int, T>> firstKeyRezults = new List<KeyValuePair<int, T>>();
            List<KeyValuePair<int, T>> secondKeyRezults = new List<KeyValuePair<int, T>>();
            this.key1.TryGetValue(key1, out firstKeyRezults);
            this.key2.TryGetValue(key2, out secondKeyRezults);

            if (firstKeyRezults.Count != 0 && secondKeyRezults.Count != 0)
            {
                if (firstKeyRezults.Count > secondKeyRezults.Count)
                {
                    foreach (var firstKey in secondKeyRezults)
                    {
                        foreach (var secondKey in firstKeyRezults)
                        {
                            if (firstKey.Key == secondKey.Key)
                            {
                                rezult.Add(firstKey.Value);
                            }
                        }
                    }
                }

                if (secondKeyRezults.Count >= firstKeyRezults.Count)
                {
                    foreach (var firstKey in firstKeyRezults)
                    {
                        foreach (var secondKey in secondKeyRezults)
                        {
                            if (firstKey.Key == secondKey.Key)
                            {
                                rezult.Add(firstKey.Value);
                            }
                        }
                    }
                }
            }

            return rezult;
        }

        public List<T> SearchByFirstKey(K1 key1)
        {
            List<T> result = new List<T>();
            List<KeyValuePair<int, T>> res = new List<KeyValuePair<int, T>>();
            if (this.key1.TryGetValue(key1, out res))
            {
                foreach (var item in res)
                {
                    result.Add(item.Value);
                }
            }

            return result;
        }

        public List<T> SearchBySecondKey(K2 key2)
        {
            List<T> result = new List<T>();
            List<KeyValuePair<int, T>> res = new List<KeyValuePair<int, T>>();
            if (this.key2.TryGetValue(key2, out res))
            {
                foreach (var item in res)
                {
                    result.Add(item.Value);
                }
            }

            return result;
        }
    }
}
