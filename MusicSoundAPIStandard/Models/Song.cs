using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSoundAPIStandard.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Artista { get; set; } = "";
        public string MusicaNome { get; set; } = "";
        public string? Genero { get; set; }
        public int Popularidade { get; set; }
        public int Duracao { get; set; }
        public int Ano { get; set; }
    }
}
