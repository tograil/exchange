using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using ExchangeDemo.Core;

namespace ExchangeDemo.Core
{
    public class StrategyManager<T>
    {
        private static readonly Dictionary<EventType, IEventTypeStartegy<T>> Startegies = new Dictionary<EventType, IEventTypeStartegy<T>>();

        public StrategyManager(IMessageStorage<T> storage)
        {
            Startegies.Add(EventType.NewMail, new NewMailStrategy<T>(storage));
            Startegies.Add(EventType.Copied, new CreatedStrategy<T>(storage));
            Startegies.Add(EventType.Deleted, new DeletedStrategy<T>(storage));
        }

        public static void ProcessEvent(EventType type, T data)
        {
            Startegies[type].ProcessEvent(data);
        }
    }
}
