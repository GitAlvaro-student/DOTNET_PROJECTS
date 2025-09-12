using MusicSoundAPI.Models;

namespace MusicSoundAPI.Services.Azure
{
    public interface IAzureLogService
    {
        Task SendLogAsync(LogEntry logEntry);
        Task SendLogToEventHubAsync(LogEntry logEntry);
        Task SendLogToBlobStorageAsync(LogEntry logEntry);
    }
}
