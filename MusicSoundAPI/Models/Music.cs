using System.Text.Json.Serialization;

namespace MusicSoundAPI.Models
{
    public class Music
    {
        [JsonPropertyName("song")]
        public string MusicName { get; set; }
        [JsonPropertyName("artist")]
        public string Artista { get; set; }
        [JsonPropertyName("genre")]
        public string Gender { get; set; }
        [JsonPropertyName("duration_ms")]
        public int Duration { get; set; }
        [JsonPropertyName("year")]
        public string AnoLancamento { get; set; }
        [JsonPropertyName("popularity")]
        public string Popularity { get; set; }
    }
}
