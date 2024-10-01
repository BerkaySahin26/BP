using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace BP.Api.Logging
{
    public class MyCustomLoggerFactory : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new MyCustomLogger();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public class MyCustomLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state) where TState : notnull
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel) // minimum level settings
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                string LogMsg = formatter(state, exception);

                LogMsg = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] - {LogMsg}";
                Console.WriteLine(LogMsg);
            }
        }
    }
}
