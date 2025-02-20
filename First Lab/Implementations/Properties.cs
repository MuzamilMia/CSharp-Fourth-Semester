
using myproject.IMap;

namespace YourProject.Implementations
{
    public class Properties : IMap<string, string>
    {
        private readonly HashMap<string, string> internalMap = new HashMap<string, string>();

        public int Count => internalMap.Count;
        public bool IsEmpty => internalMap.IsEmpty;
        public IEnumerable<string> Keys => internalMap.Keys;
        public IEnumerable<string> Values => internalMap.Values;

        public string this[string key]
        {
            get => internalMap[key];
            set => internalMap.Put(key, value);
        }

        public void Put(string key, string value) => internalMap.Put(key, value);
        public void Clear() => internalMap.Clear();
        public void Remove(string key) => internalMap.Remove(key);
        public bool ContainsKey(string key) => internalMap.ContainsKey(key);
        public bool ContainsValue(string value) => internalMap.ContainsValue(value);

        public IEnumerator<IMap<string, string>.IEntry> GetEnumerator() => internalMap.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }


}
