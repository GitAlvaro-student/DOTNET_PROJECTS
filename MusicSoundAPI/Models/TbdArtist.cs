using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicSoundAPI.Models;

[Table("TBD_ARTISTS", Schema = "MUSICA")]
public partial class TbdArtist
{
    [Key]
    [Column("ID_ARTIST", TypeName = "NUMBER")]
    public int IdArtist { get; set; }

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

    [InverseProperty("IdArtistNavigation")]
    public virtual ICollection<TbdSong> TbdSongs { get; set; } = new List<TbdSong>();
}
