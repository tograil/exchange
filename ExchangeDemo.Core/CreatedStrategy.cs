using System;

namespace ExchangeDemo.Core
{
    public class CreatedStrategy<T> : StrategyBase<T>
    {
        public CreatedStrategy(IMessageStorage<T> storage) : base(storage)
        { }
        public override void ProcessEvent(T data)
        {
            base.ProcessEvent(data);
            Console.WriteLine("\n-------------Item or folder created:-------------");
        }

       
    }
}