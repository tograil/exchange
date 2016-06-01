using System;

namespace ExchangeDemo.Core.Events
{
    public abstract class EventHandlerBase<TOnNotification, TOnDisconnect, TOnError>
        : IEventHandler<TOnNotification, TOnDisconnect, TOnError>
        where TOnNotification : EventArgs
        where TOnDisconnect : EventArgs
        where TOnError : EventArgs
    {
        public event EventHandler<TOnNotification> OnNotification;
        public event EventHandler<TOnDisconnect> OnDisconnect;
        public event EventHandler<TOnError> OnSubscriptionError;

        public abstract void OnNotificationEvent(object sender, TOnNotification args);
        public abstract void OnDisconnectEvent(object sender, TOnDisconnect args);
        public abstract void OnErrorEvent(object sender, TOnError args);
    }
}