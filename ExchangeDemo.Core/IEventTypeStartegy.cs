namespace ExchangeDemo.Core
{
    public interface IEventTypeStartegy<T>
    {
        void ProcessEvent(T data);
    }
}