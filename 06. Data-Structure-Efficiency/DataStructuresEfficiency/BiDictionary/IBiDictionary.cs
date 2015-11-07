namespace BiDictionary
{
    using System.Collections.Generic;

    public interface IBiDictionary<K1, K2, T>
    {
        void Add(K1 key1, K2 key2, T value);

        List<T> SearchByFirstKey(K1 key1);

        List<T> SearchBySecondKey(K2 key2);

        List<T> SearchByTwoKeys(K1 key1, K2 key2);
    }
}
