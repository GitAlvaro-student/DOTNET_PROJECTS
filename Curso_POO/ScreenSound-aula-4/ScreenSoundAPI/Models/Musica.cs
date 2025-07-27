using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ScreenSoundAPI.Models
{
    internal class Musica
    {
        private string[] tons = { "C", "C#", "D", "D#", "E", "F", };

        [JsonPropertyName("song")]
        public string Name { get; set; }
        [JsonPropertyName("artist")]
        public string Artista { get; set; }
        [JsonPropertyName("genre")]
        public string Gender { get; set; }
        [JsonPropertyName("duration_ms")]
        public int Duration { get; set; }
        [JsonPropertyName("year")]
        public string AnoLancamento { get; set; }
        [JsonPropertyName("key")]
        public int Key { get; set; }
        public string Tonalidade
        {
            get
            {
                return tons[Key];
            }
        }
        public void Detalhes()
        {
            Console.WriteLine($"Nome: {Name}\n" +
                $"Artista: {Artista}\n" +
                $"Duracao: {Duration / 1000}\n" +
                $"Genero: {Gender}");
        }
    }
}
