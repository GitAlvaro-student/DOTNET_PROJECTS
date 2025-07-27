using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicas_Oracle.Models
{
    public class MusicaJson
    {
        public string artist { get; set; } = string.Empty;
        public string song { get; set; } = string.Empty;
        public int duration_ms { get; set; }
        public string @explicit { get; set; } = string.Empty;
        public string year { get; set; } = string.Empty;
        public string popularity { get; set; } = string.Empty;
        public string danceability { get; set; } = string.Empty;
        public string energy { get; set; } = string.Empty;
        public int key { get; set; }
        public string loudness { get; set; } = string.Empty;
        public string mode { get; set; } = string.Empty;
        public string speechiness { get; set; } = string.Empty;
        public string acousticness { get; set; } = string.Empty;
        public string instrumentalness { get; set; } = string.Empty;
        public string liveness { get; set; } = string.Empty;
        public string valence { get; set; } = string.Empty;
        public string tempo { get; set; } = string.Empty;
        public string genre { get; set; } = string.Empty;
    }
}
