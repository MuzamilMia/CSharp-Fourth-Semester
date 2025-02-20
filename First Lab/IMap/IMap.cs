
namespace myproject.IMap
{
    public interface IMap<K, V> : IEnumerable<IMap<K, V>.IEntry>
    {
        public interface IEntry
        {
            K Key { get; }
            V Value { get; set; }
        }

        void Put(K key, V value);
        void Clear();
        bool ContainsKey(K key);
        bool ContainsValue(V value);
        void Remove(K key);

        int Count { get; }
        bool IsEmpty { get; }
        V this[K key] { get; set; }
        IEnumerable<K> Keys { get; }
        IEnumerable<V> Values { get; }
    }
}

