using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSoundAPI.Data.Dtos.Music
{
    public class CreateMusicDTO
    {
        [Required]
        [Column("MUSICA")]
        [StringLength(200)]
        [Unicode(false)]
        public string Musica { get; set; }

        [Column("POPULARIDADE")]
        [Precision(3)]
        public int Popularidade { get; set; }

        [Column("DURACAO")]
        [Precision(10)]
        public int Duracao { get; set; }

        [Column("ANO")]
        [Precision(4)]
        public int Ano { get; set; }

        [Column("ID_ARTIST", TypeName = "NUMBER")]
        public int IdArtist { get; set; }
    }
}
