using myproject.IMap;
using System.Collections;

namespace YourProject.Implementations
{
    public class LinkedMap<K, V> : IMap<K, V>
    {
        private class Node
        {
            public K Key { get; }
            public V Value { get; set; }
            public Node Next { get; set; }

            public Node(K key, V value)
            {
                Key = key;
                Value = value;
                Next = null;
            }
        }

        private Node head;
        private int count = 0;

        public int Count => count;
        public bool IsEmpty => count == 0;
        public IEnumerable<K> Keys
        {
            get
            {
                var current = head;
                while (current != null)
                {
                    yield return current.Key;
                    current = current.Next;
                }
            }
        }

        public IEnumerable<V> Values
        {
            get
            {
                var current = head;
                while (current != null)
                {
                    yield return current.Value;
                    current = current.Next;
                }
            }
        }

        public V this[K key]
        {
            get
            {
                var current = head;
                while (current != null)
                {
                    if (current.Key.Equals(key))
                        return current.Value;
                    current = current.Next;
                }
                throw new System.Collections.Generic.KeyNotFoundException(key.ToString());
            }
            set => Put(key, value);
        }

        public void Put(K key, V value)
        {
            var current = head;
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    current.Value = value;
                    return;
                }
                current = current.Next;
            }
            var newNode = new Node(key, value);
            newNode.Next = head;
            head = newNode;
            count++;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public bool ContainsKey(K key)
        {
            var current = head;
            while (current != null)
            {
                if (current.Key.Equals(key))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public bool ContainsValue(V value)
        {
            var current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void Remove(K key)
        {
            if (head == null) return;

            if (head.Key.Equals(key))
            {
                head = head.Next;
                count--;
                return;
            }

            var current = head;
            while (current.Next != null)
            {
                if (current.Next.Key.Equals(key))
                {
                    current.Next = current.Next.Next;
                    count--;
                    return;
                }
                current = current.Next;
            }
        }

        public IEnumerator<IMap<K, V>.IEntry> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return new Entry(current.Key, current.Value);
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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
    }

}
