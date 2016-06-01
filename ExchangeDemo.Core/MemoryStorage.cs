using System.Collections.Generic;

namespace ExchangeDemo.Core
{
    public class MemoryStorage<T> : IMessageStorage<T>
    {
        private static List<T> _storage = new List<T>();
        public void Write(T message)
        {
            _storage.Add(message);
        }

        public T Read(int id)
        {
            return _storage[id];
        }
    }
}