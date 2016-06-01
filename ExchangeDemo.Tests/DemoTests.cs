using System;
using System.Collections.Generic;
using ExchangeDemo.Core;
using ExchangeDemo.Core.Events;
using Microsoft.Exchange.WebServices.Data;
using Moq;
using NUnit.Framework;

namespace ExchangeDemo.Tests
{
    // Only used to mimic EWS' StreamingSubscriptionConnection class

    // Mimics EWS' NotificationEventArgs class
    public class NotificationEventArgs : EventArgs { }

    // Mimics EWS' SubscriptionErrorEventArgs class
    public class ErrorEventArgs : EventArgs { }

    // Mimics EWS' SubscriptionErrorEventArgs class
    public class DisconnectEventArgs : EventArgs { }

    

    [TestFixture]
    public class DemoTests
    {
        [Test]
        public void Test1()
        {
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(x => x.LogError(Moq.It.IsAny<Exception>()));
            MemoryStorage<string> storage = new MemoryStorage<string>();
            var notificationProcessor = new DemoNotificationProcessor<string>(loggerMock.Object, storage);
            var exchangeService = new ExchangeService();
            StreamingSubscription streamingsubscription = exchangeService.SubscribeToStreamingNotifications(
                new FolderId[] { WellKnownFolderName.Inbox },
                EventType.NewMail,
                EventType.Created,
                EventType.Deleted);


            
            //notificationProcessor.OnEvent(new object(), new NotificationEventArgs(streamingsubscription, new List<NotificationEvent>()));
        }
    }
}
