using MusicSoundAPI.Models;
using MusicSoundAPI.Services.Azure;
using System.Diagnostics;

namespace MusicSoundAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAzureLogService _azureLogService;

        public LoggingMiddleware(RequestDelegate next, IAzureLogService azureLogService)
        {
            _next = next;
            _azureLogService = azureLogService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var correlationId = Guid.NewGuid().ToString();
            context.Items["CorrelationId"] = correlationId;

            var stopwatch = Stopwatch.StartNew();

            // Log da requisição
            await LogRequestAsync(context, correlationId);

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await LogExceptionAsync(context, ex, correlationId);
                throw;
            }
            finally
            {
                stopwatch.Stop();
                await LogResponseAsync(context, correlationId, stopwatch.ElapsedMilliseconds);
            }
        }

        private async Task LogRequestAsync(HttpContext context, string correlationId)
        {
            var logEntry = new LogEntry
            {
                Level = "Information",
                Message = $"HTTP {context.Request.Method} {context.Request.Path}",
                Source = "WebAPI",
                CorrelationId = correlationId,
                Properties = new Dictionary<string, object>
                {
                    ["RequestMethod"] = context.Request.Method,
                    ["RequestPath"] = context.Request.Path.Value,
                    ["RequestQuery"] = context.Request.QueryString.Value,
                    ["UserAgent"] = context.Request.Headers.UserAgent.ToString(),
                    ["RemoteIpAddress"] = context.Connection.RemoteIpAddress?.ToString()
                }
            };

            await _azureLogService.SendLogAsync(logEntry);
        }

        private async Task LogResponseAsync(HttpContext context, string correlationId, long elapsed)
        {
            var logEntry = new LogEntry
            {
                Level = "Information",
                Message = context.Items["Message"] as string,
                Source = context.Items["Source"] as string,
                CorrelationId = correlationId,
                Properties = context.Items["Properties"] as Dictionary<string, object>
            };

            await _azureLogService.SendLogAsync(logEntry);
        }

        private async Task LogExceptionAsync(HttpContext context, Exception ex, string correlationId)
        {
            var logEntry = new LogEntry
            {
                Level = "Error",
                Message = ex.Message,
                Source = "WebAPI",
                CorrelationId = correlationId,
                Properties = new Dictionary<string, object>
                {
                    ["ExceptionType"] = ex.GetType().Name,
                    ["StackTrace"] = ex.StackTrace,
                    ["RequestPath"] = context.Request.Path.Value
                }
            };

            await _azureLogService.SendLogAsync(logEntry);
        }
    }
}
