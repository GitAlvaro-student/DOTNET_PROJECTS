using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicSoundWebApp.Models;

[Table("TBD_ARTISTS", Schema = "MUSICA")]
public partial class TbdArtist
{
    [Key]
    [Column("ID_ARTIST", TypeName = "NUMBER")]
    public decimal IdArtist { get; set; }

    [Column("ARTISTA")]
    [StringLength(100)]
    [Unicode(false)]
    public string Artista { get; set; } = null!;

    [Column("GENERO")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Genero { get; set; }

    [Column("NACIONALIDADE")]
    [StringLength(100)]
    [Unicode(false)]
    public string Nacionalidade { get; set; } = null!;

    [Column("NASCIMENTO", TypeName = "DATE")]
    public DateTime? Nascimento { get; set; }
}
