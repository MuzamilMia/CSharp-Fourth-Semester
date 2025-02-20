//using myproject.IMap;
//using YourProject.Implementations;
//using myproject1.Utils;

//class Program
//{
//    static void Main()
//    {
//        IMap<int, string> map = new HashMap<int, string>();
//        map.Put(1, "One");
//        map.Put(2, "Two");

//        Console.WriteLine("HashMap:");
//        foreach (var entry in map)
//            Console.WriteLine($"{entry.Key} -> {entry.Value}");
//    }
//}
using System;
using myproject.IMap;
using YourProject.Implementations;

class Program
{
    static void Main()
    {

        IMap<int, string> map = new HashMap<int, string>();
        map.Put(1, "One");
        map.Put(2, "Two");
        map.Put(3, "Three");
        map.Put(4, "Four");
        Console.WriteLine("HashMap:");
        PrintMap(map);

        // Access value by key
        int keyToAccess = 1;
        if (map.ContainsKey(keyToAccess))
        {
            Console.WriteLine($"\nValue for key {keyToAccess}: {map[keyToAccess]}");
        }

        // Removing entry
        map.Remove(1);
        Console.WriteLine("\nAfter removing key 1:");
        PrintMap(map);
    }

    static void PrintMap(IMap<int, string> map)
    {
        foreach (var entry in map)
        {
            Console.WriteLine($"{entry.Key} -> {entry.Value}");
        }
    }
}

