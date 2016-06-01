using System;
using ExchangeDemo.Core.Events;

namespace ExchangeDemo.Tests
{
    public class DummyService : IService
    {
        private readonly ISubscriber _subscriber;

        public DummyService(ISubscriber subscriber)
        {
            _subscriber = subscriber;
        }

        public void Start()
        {
            Console.WriteLine("Starting service.");

            _subscriber.Subscribe();
        }

        public void Stop()
        {
            Console.WriteLine("Stopping service.");

            _subscriber.Unsubcribe();
        }
    }
}