using System;

namespace ExchangeDemo.Tests
{
    public class DummyStreamingSubscriptionConnection
    {
        public event EventHandler<NotificationEventArgs> OnNotification;
        public event EventHandler<DisconnectEventArgs> OnDisconnect;
        public event EventHandler<ErrorEventArgs> OnError;
    }
}