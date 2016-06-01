using System;
using Microsoft.Exchange.WebServices.Data;


namespace ExchangeDemo.Core
{
    public class DemoNotificationProcessor<T> : INotificationProcessor
    {
        private readonly ILogger _logger;
        private IMessageStorage<T> _storage;
        private StrategyManager<T> _strategyManager;

        public DemoNotificationProcessor(ILogger logger, MemoryStorage<T> storage)
        {
            _logger = logger;
            _storage = storage;
            _strategyManager = new StrategyManager<T>(_storage);
        }

        public void OnEvent(object sender, NotificationEventArgs args)
        {
            StreamingSubscription subscription = args.Subscription;
            // Loop through all item-related events. 
            foreach (NotificationEvent notification in args.Events)
            {
                StrategyManager<string>.ProcessEvent(notification.EventType, notification.ToString());
            }
        }

        public void OnDisconnect(object sender, SubscriptionErrorEventArgs args)
        {
            throw new System.NotImplementedException();
        }

        public void OnError(object sender, SubscriptionErrorEventArgs args)
        {
            Exception e = args.Exception;
            _logger.LogError(e);
        }
    }
}