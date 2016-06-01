using System;

namespace ExchangeDemo.Core
{
    public class NewMailStrategy<T> : StrategyBase<T>
    {
        public NewMailStrategy(IMessageStorage<T> storage) : base(storage)
        { }

        public override void ProcessEvent(T data)
        {
            base.ProcessEvent(data);
            Console.WriteLine("\n-------------Mail created:-------------");
        }
    }
}