using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicSoundAPI.Models;

[Table("TBD_SONGS", Schema = "MUSICA")]
public partial class TbdSong
{
    [Key]
    [Column("ID_MUSIC", TypeName = "NUMBER")]
    public int IdMusic { get; set; }

    [Required]
    [Column("MUSICA")]
    [StringLength(200)]
    [Unicode(false)]
    public string Musica { get; set; }

    [Column("POPULARIDADE")]
    [Precision(3)]
    public int? Popularidade { get; set; }

    [Column("DURACAO")]
    [Precision(10)]
    public int Duracao { get; set; }

    [Column("ANO")]
    [Precision(4)]
    public int Ano { get; set; }

    [Column("ID_ARTIST", TypeName = "NUMBER")]
    public int? IdArtist { get; set; }

    [ForeignKey("IdArtist")]
    [InverseProperty("TbdSongs")]
    public virtual TbdArtist IdArtistNavigation { get; set; }
}
