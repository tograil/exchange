namespace ExchangeDemo.Core
{
    public interface IMessageStorage<T>
    {
        void Write(T message);
        T Read(int id);
    }
}