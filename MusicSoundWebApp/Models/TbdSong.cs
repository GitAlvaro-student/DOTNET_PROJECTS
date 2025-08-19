using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicSoundWebApp.Models;

[Table("TBD_SONGS", Schema = "MUSICA")]
public partial class TbdSong
{
    [Key]
    [Column("ID_MUSIC", TypeName = "NUMBER")]
    public int IdMusic { get; set; }

    [Column("ARTISTA")]
    [StringLength(100)]
    [Unicode(false)]
    public string Artista { get; set; } = null!;

    [Column("MUSICA")]
    [StringLength(200)]
    [Unicode(false)]
    public string Musica { get; set; } = null!;

    [Column("GENERO")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Genero { get; set; }

    [Column("POPULARIDADE")]
    [Precision(3)]
    public int? Popularidade { get; set; }

    [Column("DURACAO")]
    [Precision(10)]
    public int Duracao { get; set; }

    [Column("ANO")]
    [Precision(4)]
    public int Ano { get; set; }
}
