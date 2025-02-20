//using myproject.IMap;
//using YourProject.Implementations;

//namespace myproject1.Utils
//{

//    public static class MapUtils
//    {

//        public delegate IMap<K, V> MapConstructorDelegate<K, V>();
//        public delegate bool CheckDelegate<K, V>(IMap<K, V>.IEntry entry);
//        public delegate void ActionDelegate<K, V>(IMap<K, V>.IEntry entry);


//        public static bool Exists<K, V>(IMap<K, V> map, CheckDelegate<K, V> predicate)
//        {
//            foreach (var entry in map)
//                if (predicate(entry)) return true;
//            return false;
//        }

//        public static IMap<K, V> FindAll<K, V>(IMap<K, V> map, CheckDelegate<K, V> predicate, MapConstructorDelegate<K, V> constructor)
//        {
//            IMap<K, V> result = constructor();
//            foreach (var entry in map)
//                if (predicate(entry))
//                    result.Put(entry.Key, entry.Value);
//            return result;
//        }

//        public static void ForEach<K, V>(IMap<K, V> map, ActionDelegate<K, V> action)
//        {
//            foreach (var entry in map)
//                action(entry);
//        }

//        public static bool CheckForAll<K, V>(IMap<K, V> map, CheckDelegate<K, V> predicate)
//        {
//            foreach (var entry in map)
//                if (!predicate(entry)) return false;
//            return true;
//        }

//        public static readonly MapConstructorDelegate<K, V> ArrayMapConstructor = () => new ArrayMap<K, V>();
//        public static readonly MapConstructorDelegate<K, V> LinkedMapConstructor = () => new LinkedMap<K, V>();
//        public static readonly MapConstructorDelegate<K, V> HashMapConstructor = () => new HashMap<K, V>();
//    }

//    public class V
//    {
//    }

//    public class K
//    {
//    }
//}

using myproject.IMap;

using YourProject.Implementations;

namespace myproject1.Utils
{
    public static class MapUtils
    {
        public delegate IMap<K, V> MapConstructorDelegate<K, V>();
        public delegate bool CheckDelegate<K, V>(IMap<K, V>.IEntry entry);
        public delegate void ActionDelegate<K, V>(IMap<K, V>.IEntry entry);

        public static bool Exists<K, V>(IMap<K, V> map, CheckDelegate<K, V> predicate)
        {
            foreach (var entry in map)
                if (predicate(entry)) return true;
            return false;
        }

        public static IMap<K, V> FindAll<K, V>(IMap<K, V> map, CheckDelegate<K, V> predicate, MapConstructorDelegate<K, V> constructor)
        {
            IMap<K, V> result = constructor();
            foreach (var entry in map)
                if (predicate(entry))
                    result.Put(entry.Key, entry.Value);
            return result;
        }

        public static void ForEach<K, V>(IMap<K, V> map, ActionDelegate<K, V> action)
        {
            foreach (var entry in map)
                action(entry);
        }

        public static bool CheckForAll<K, V>(IMap<K, V> map, CheckDelegate<K, V> predicate)
        {
            foreach (var entry in map)
                if (!predicate(entry)) return false;
            return true;
        }
        public static IMap<K, V> CreateArrayMap<K, V>() => new ArrayMap<K, V>();
        public static IMap<K, V> CreateLinkedMap<K, V>() => new LinkedMap<K, V>();
        public static IMap<K, V> CreateHashMap<K, V>() => new HashMap<K, V>();
    }
}

