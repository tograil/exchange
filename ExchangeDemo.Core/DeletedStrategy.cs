using System;

namespace ExchangeDemo.Core
{
    public class DeletedStrategy<T> : StrategyBase<T>
    {
        public DeletedStrategy(IMessageStorage<T> storage) : base(storage)
        { }
        public override void ProcessEvent(T data)
        {
            base.ProcessEvent(data);
            Console.WriteLine("\n-------------Item or folder deleted:-------------");
        }
    }

    public class StrategyBase<T> : IEventTypeStartegy<T>
    {
        protected IMessageStorage<T> Storage;

        public StrategyBase(IMessageStorage<T> storage)
        {
            Storage = storage;
        }
        public virtual void ProcessEvent(T data)
        {
            Storage.Write(data);
        }
    }
}

