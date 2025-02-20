using myproject.IMap;
using System.Collections;

namespace YourProject.Implementations
{
    public class ArrayMap<K, V> : IMap<K, V>
    {
        private class Entry : IMap<K, V>.IEntry
        {
            public K Key { get; }
            public V Value { get; set; }

            public Entry(K key, V value)
            {
                Key = key;
                Value = value;
            }
        }

        private List<Entry> entries = new List<Entry>();

        public int Count => entries.Count;
        public bool IsEmpty => Count == 0;
        public IEnumerable<K> Keys => entries.ConvertAll(entry => entry.Key);
        public IEnumerable<V> Values => entries.ConvertAll(entry => entry.Value);

        public V this[K key]
        {
            get
            {
                var entry = entries.Find(e => e.Key.Equals(key));
                if (entry == null) throw new System.Collections.Generic.KeyNotFoundException(key.ToString());
                return entry.Value;
            }
            set => Put(key, value);
        }

        public void Put(K key, V value)
        {
            var entry = entries.Find(e => e.Key.Equals(key));
            if (entry != null)
                entry.Value = value;
            else
                entries.Add(new Entry(key, value));
        }

        public void Clear() => entries.Clear();
        public bool ContainsKey(K key) => entries.Exists(e => e.Key.Equals(key));
        public bool ContainsValue(V value) => entries.Exists(e => e.Value.Equals(value));
        public void Remove(K key) => entries.RemoveAll(e => e.Key.Equals(key));

        public IEnumerator<IMap<K, V>.IEntry> GetEnumerator() => entries.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

//using myproject.IMap;

//namespace YourProject.Implementations
//{
//    public class ArrayMap<K, V> : IMap<K, V>
//    {
//        // Internal storage for the key-value pairs
//        private List<KeyValuePair<K, V>> items = new List<KeyValuePair<K, V>>();

//        // Implementing the Put method
//        public void Put(K key, V value)
//        {
//            // Check if the key already exists; if so, update the value
//            var existingItem = items.FirstOrDefault(item => EqualityComparer<K>.Default.Equals(item.Key, key));
//            if (existingItem.Key != null)
//            {
//                // Replace the value for the existing key
//                items.Remove(existingItem);
//            }
//            // Add new key-value pair
//            items.Add(new KeyValuePair<K, V>(key, value));
//        }

//        // Implementing ContainsKey method
//        public bool ContainsKey(K key)
//        {
//            return items.Any(item => EqualityComparer<K>.Default.Equals(item.Key, key));
//        }

//        // Implementing ContainsValue method
//        public bool ContainsValue(V value)
//        {
//            return items.Any(item => EqualityComparer<V>.Default.Equals(item.Value, value));
//        }

//        // Implementing GetEnumerator for iteration over entries
//        public IEnumerator<IMap<K, V>.IEntry> GetEnumerator()
//        {
//            foreach (var item in items)
//            {
//                yield return new Entry(item.Key, item.Value);
//            }
//        }

//        // IEnumerable interface for iteration
//        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

//        public void Clear()
//        {
//            throw new NotImplementedException();
//        }

//        public void Remove(K key)
//        {
//            throw new NotImplementedException();
//        }

//        // Implementing the Keys property
//        public IEnumerable<K> Keys => items.Select(item => item.Key);

//        // Implementing the Values property
//        public IEnumerable<V> Values => items.Select(item => item.Value);

//        // Implementing the Count property
//        public int Count => items.Count;

//        // Implementing the IsEmpty property
//        public bool IsEmpty => items.Count == 0;

//        public V this[K key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); } ///this...
//        /// </summary>

//        // Entry class implementing IMap.IEntry interface
//        private class Entry : IMap<K, V>.IEntry
//        {
//            public K Key { get; }
//            public V Value { get; set; }

//            public Entry(K key, V value)
//            {
//                Key = key;
//                Value = value;
//            }
//        }
//    }
//}
