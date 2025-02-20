
namespace myproject.IMap
{
    public class MapException : Exception
    {
        public MapException(string message) : base(message) { }
    }
    public class KeyNotFoundException : MapException
    {
        public KeyNotFoundException(string key) : base($"Key not found: {key}") { }
    }
}
