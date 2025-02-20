using System;
using System.Collections;
using System.Collections.Generic;
using myproject.IMap;

namespace YourProject.Implementations
{
    public class HashMap<K, V> : IMap<K, V>
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

        private const int DefaultCapacity = 16;
        private LinkedList<Entry>[] buckets;
        private int count;

        public HashMap(int capacity = DefaultCapacity)
        {
            buckets = new LinkedList<Entry>[capacity];
            count = 0;
        }

        private int GetBucketIndex(K key) => Math.Abs(key.GetHashCode()) % buckets.Length;

        public int Count => count;
        public bool IsEmpty => count == 0;

        public IEnumerable<K> Keys
        {
            get
            {
                foreach (var bucket in buckets)
                    if (bucket != null)
                        foreach (var entry in bucket)
                            yield return entry.Key;
            }
        }

        public IEnumerable<V> Values
        {
            get
            {
                foreach (var bucket in buckets)
                    if (bucket != null)
                        foreach (var entry in bucket)
                            yield return entry.Value;
            }
        }

        public V this[K key]
        {
            get
            {
                var bucket = buckets[GetBucketIndex(key)];
                if (bucket != null)
                {
                    foreach (var entry in bucket)
                        if (entry.Key.Equals(key))
                            return entry.Value;
                }
                throw new System.Collections.Generic.KeyNotFoundException(key.ToString());
            }
            set => Put(key, value);
        }

        public void Put(K key, V value)
        {
            int index = GetBucketIndex(key);
            if (buckets[index] == null)
                buckets[index] = new LinkedList<Entry>();

            foreach (var entry in buckets[index])
            {
                if (entry.Key.Equals(key))
                {
                    entry.Value = value;
                    return;
                }
            }

            buckets[index].AddLast(new Entry(key, value));
            count++;
        }

        public void Clear()
        {
            for (int i = 0; i < buckets.Length; i++)
                buckets[i] = null;
            count = 0;
        }

        public bool ContainsKey(K key)
        {
            var bucket = buckets[GetBucketIndex(key)];
            if (bucket != null)
            {
                foreach (var entry in bucket)
                    if (entry.Key.Equals(key))
                        return true;
            }
            return false;
        }

        public bool ContainsValue(V value)
        {
            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    foreach (var entry in bucket)
                        if (entry.Value.Equals(value))
                            return true;
                }
            }
            return false;
        }

        public void Remove(K key)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];
            if (bucket != null)
            {
                var node = bucket.First;
                while (node != null)
                {
                    if (node.Value.Key.Equals(key))
                    {
                        bucket.Remove(node);
                        count--;
                        return;
                    }
                    node = node.Next;
                }
            }
        }

        public IEnumerator<IMap<K, V>.IEntry> GetEnumerator()
        {
            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    foreach (var entry in bucket)
                        yield return entry;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }


}
