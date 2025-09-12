using MusicSoundAPI.Models;

namespace MusicSoundAPI.Data.Dtos.Artist
{
    public class ReadArtistDTO
    {
        public string Artista { get; set; }
        public string Genero { get; set; }
        public string Nacionalidade { get; set; }
        public DateTime? Nascimento { get; set; }
        public virtual ICollection<TbdSong> TbdSongs { get; set; }
        
    }
}
