using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;


namespace ExchangeDemo.Core
{
    public class NotifcationManager
    {
        private ExchangeService _service;
        private INotificationProcessor _processor;

        public NotifcationManager(ExchangeService service, INotificationProcessor processor)
        {
            _service = service;
            _processor = processor;
        }
        public void SetStreamingNotifications(StreamingSubscription streamingSubscription, int lifetime)
        {
            // Subscribe to streaming notifications on the Inbox folder, and listen 
            // for "NewMail", "Created", and "Deleted" events. 

            var connection = new StreamingSubscriptionConnection(_service, lifetime);

            connection.AddSubscription(streamingSubscription);
            // Delegate event handlers. 
            connection.OnNotificationEvent +=
                new StreamingSubscriptionConnection.NotificationEventDelegate(OnEvent);
            connection.OnSubscriptionError +=
                new StreamingSubscriptionConnection.SubscriptionErrorDelegate(OnError);
            connection.OnDisconnect +=
                new StreamingSubscriptionConnection.SubscriptionErrorDelegate(OnDisconnect);
            connection.Open();

            Console.WriteLine("--------- StreamSubscription event -------");
        }
        private void OnEvent(object sender, NotificationEventArgs args)
        {
            _processor.OnEvent(sender, args);
        }
        private void OnDisconnect(object sender, SubscriptionErrorEventArgs args)
        {
            _processor.OnDisconnect(sender, args);
        }

        private void OnError(object sender, SubscriptionErrorEventArgs args)
        {
            _processor.OnError(sender, args);
        }
    }
}
