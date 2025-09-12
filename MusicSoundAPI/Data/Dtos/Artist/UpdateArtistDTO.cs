using Microsoft.EntityFrameworkCore;
using MusicSoundAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSoundAPI.Data.Dtos.Artist
{
    public class UpdateArtistDTO
    {

        [Required]
        [Column("ARTISTA")]
        [StringLength(100)]
        [Unicode(false)]
        public string Artista { get; set; }

        [Column("GENERO")]
        [StringLength(50)]
        [Unicode(false)]
        public string Genero { get; set; }

        [Required]
        [Column("NACIONALIDADE")]
        [StringLength(100)]
        [Unicode(false)]
        public string Nacionalidade { get; set; }

        [Column("NASCIMENTO", TypeName = "DATE")]
        public DateTime? Nascimento { get; set; }

    }
}
