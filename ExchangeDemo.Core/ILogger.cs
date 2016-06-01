using System;

namespace ExchangeDemo.Core
{
    public interface ILogger
    {
        void LogError(Exception exception);
    }
}