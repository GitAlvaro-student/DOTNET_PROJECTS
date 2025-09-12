namespace MusicSoundAPI.Models
{
    public record LogEntry
    {
        public string Timestamp { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        public string Level { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public Dictionary<string, object> Properties { get; set; } = new();
        public string CorrelationId { get; set; } = Guid.NewGuid().ToString();
    }
}
