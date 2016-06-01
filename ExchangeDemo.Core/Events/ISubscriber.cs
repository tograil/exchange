namespace ExchangeDemo.Core.Events
{
    public interface ISubscriber
    {
        void Subscribe();
        void Unsubcribe();
    }
}