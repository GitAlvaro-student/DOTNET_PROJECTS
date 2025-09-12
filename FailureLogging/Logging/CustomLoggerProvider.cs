using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace FailureLogging.Logging
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        private readonly CustomLoggerProviderConfiguration? _loggerConfiguration;
        private readonly ConcurrentDictionary<string, CustomLogger> loggers = new ConcurrentDictionary<string, CustomLogger>();

        public CustomLoggerProvider(CustomLoggerProviderConfiguration? loggerConfiguration)
        {
            this._loggerConfiguration = loggerConfiguration;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, nome => new CustomLogger(nome, _loggerConfiguration));
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
