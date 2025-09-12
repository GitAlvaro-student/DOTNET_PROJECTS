using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Azure.Storage.Blobs;
using MusicSoundAPI.Models;
using System.Text;
using System.Text.Json;

namespace MusicSoundAPI.Services.Azure
{
    public class AzureLogService : IAzureLogService
    {
        private readonly EventHubProducerClient _eventHubClient;
        private readonly BlobContainerClient _blobContainerClient;
        private readonly ILogger<AzureLogService> _logger;

        public AzureLogService(IConfiguration configuration, ILogger<AzureLogService> logger)
        {
            _logger = logger;

            var eventHubConnectionString = configuration["Azure:EventHub:ConnectionString"];
            var eventHubName = configuration["Azure:EventHub:HubName"];
            _eventHubClient = new EventHubProducerClient(eventHubConnectionString, eventHubName);

            var storageConnectionString = configuration["Azure:Storage:ConnectionString"];
            var containerName = configuration["Azure:Storage:ContainerName"];
            _blobContainerClient = new BlobContainerClient(storageConnectionString, containerName);
        }

        public async Task SendLogAsync(LogEntry logEntry)
        {
            var tasks = new[]
            {
            SendLogToEventHubAsync(logEntry),
            SendLogToBlobStorageAsync(logEntry)
        };

            await Task.WhenAll(tasks);
        }

        public async Task SendLogToEventHubAsync(LogEntry logEntry)
        {
            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(logEntry);
                var eventData = new EventData(Encoding.UTF8.GetBytes(json));

                // Adicionar propriedades para roteamento
                eventData.Properties.Add("source", logEntry.Source);
                eventData.Properties.Add("level", logEntry.Level);

                using var eventBatch = await _eventHubClient.CreateBatchAsync();
                eventBatch.TryAdd(eventData);

                await _eventHubClient.SendAsync(eventBatch);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao enviar log para EventHub");
            }
        }

        public async Task SendLogToBlobStorageAsync(LogEntry logEntry)
        {
            try
            {
                var json = JsonSerializer.Serialize(logEntry);
                var blobName = $"logs/{DateTime.UtcNow:yyyy/MM/dd}/{Guid.NewGuid()}.json";

                var blobClient = _blobContainerClient.GetBlobClient(blobName);
                await blobClient.UploadAsync(
                    new MemoryStream(Encoding.UTF8.GetBytes(json)),
                    overwrite: true
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao enviar log para Blob Storage");
            }
        }
    }
}
