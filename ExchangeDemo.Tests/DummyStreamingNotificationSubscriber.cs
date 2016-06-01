using System;
using ExchangeDemo.Core;
using ExchangeDemo.Core.Events;
using Moq;
using NUnit.Framework;

namespace ExchangeDemo.Tests
{
    public class DummyStreamingNotificationSubscriber : ISubscriber
    {
        private readonly IEventHandler<NotificationEventArgs, DisconnectEventArgs, ErrorEventArgs> _eventHandler;

        public DummyStreamingNotificationSubscriber(
            IEventHandler<NotificationEventArgs, DisconnectEventArgs, ErrorEventArgs> eventHandler)
        {
            _eventHandler = eventHandler;
        }

        public void Subscribe()
        {
            Console.WriteLine("Subscribing to streaming notification.");

            var streamingConnection = new DummyStreamingSubscriptionConnection();

            streamingConnection.OnNotification += _eventHandler.OnNotificationEvent;
            streamingConnection.OnDisconnect += _eventHandler.OnDisconnectEvent;
            streamingConnection.OnError += _eventHandler.OnErrorEvent;
        }

        public void Unsubcribe()
        {
            Console.WriteLine("Unsubscribing to streaming notification.");
        }
    }
}