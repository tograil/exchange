using System;
using System.Reflection;
using ExchangeDemo.Core.Events;


namespace ExchangeDemo.Tests
{
    public class DummyEventHandler :
        EventHandlerBase<Microsoft.Exchange.WebServices.Data.NotificationEventArgs, DisconnectEventArgs, System.IO.ErrorEventArgs>
    {
        public override void OnNotificationEvent(object sender, Microsoft.Exchange.WebServices.Data.NotificationEventArgs args)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod());
        }

        public override void OnDisconnectEvent(object sender, DisconnectEventArgs args)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod());
        }

        public override void OnErrorEvent(object sender, System.IO.ErrorEventArgs args)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod());
        }


    }
}