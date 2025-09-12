using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSoundAPI.Data.Dtos.Music
{
    public class ReadMusicDTO
    {
        public string Musica { get; set; }
        public int Popularidade { get; set; }
        public int Duracao { get; set; }
        public int Ano { get; set; }
        public int IdArtist { get; set; }
    }
}
