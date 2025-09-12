using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FailureLogging.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string _loggerName;
        private readonly CustomLoggerProviderConfiguration _configuration;

        public CustomLogger(string nome,  CustomLoggerProviderConfiguration configuration)
        {
            this._loggerName = nome;
            this._configuration = configuration;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var mensagem = string.Format($"{logLevel}: {eventId}" +
                $" - {formatter(state, exception)}");
            WriteOnFile(mensagem);
        }

        private void WriteOnFile(string message)
        {
            string filePath = @$"C:\Users\cardo\source\Logs\{DateTime.Now:yyyy-MM-dd}";

            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
                File.Create(filePath).Dispose();
            }

            using StreamWriter streamWriter = new StreamWriter(filePath, true);
            streamWriter.WriteLine(message);
            streamWriter.Close();
        }
    }
}
