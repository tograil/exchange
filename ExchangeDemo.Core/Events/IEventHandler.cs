using System;

namespace ExchangeDemo.Core.Events
{
    public interface IEventHandler
        <TOnNotification, TOnDisconnect, TOnSubscriptionError>
        where TOnNotification : EventArgs
        where TOnDisconnect : EventArgs
        where TOnSubscriptionError : EventArgs
    {
        event EventHandler<TOnNotification> OnNotification;
        event EventHandler<TOnDisconnect> OnDisconnect;
        event EventHandler<TOnSubscriptionError> OnSubscriptionError;

        void OnNotificationEvent(object sender, TOnNotification args);
        void OnDisconnectEvent(object sender, TOnDisconnect args);
        void OnErrorEvent(object sender, TOnSubscriptionError args);
    }
}