using Microsoft.Exchange.WebServices.Data;


namespace ExchangeDemo.Core
{
    public interface INotificationProcessor
    {
        void OnEvent(object sender, NotificationEventArgs args);
        void OnDisconnect(object sender, SubscriptionErrorEventArgs args);
        void OnError(object sender, SubscriptionErrorEventArgs args);
    }
}