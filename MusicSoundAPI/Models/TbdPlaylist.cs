using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicSoundAPI.Models;

[Table("TBD_PLAYLIST", Schema = "MUSICA")]
public partial class TbdPlaylist
{
    [Key]
    [Column("ID_PLAYLIST", TypeName = "NUMBER")]
    public int IdPlaylist { get; set; }

    [Required]
    [Column("NOME_PLAYLIST")]
    [StringLength(100)]
    [Unicode(false)]
    public string NomePlaylist { get; set; }

    [Column("ANO", TypeName = "DATE")]
    public DateTime Ano { get; set; } = DateTime.Now;
}
