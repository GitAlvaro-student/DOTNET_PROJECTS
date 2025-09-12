using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MusicSoundAPI.Models;

[Keyless]
[Table("TBD_PLAYLIST_MUSICS", Schema = "MUSICA")]
public partial class TbdPlaylistMusic
{
    [Column("ID_PLAYLIST", TypeName = "NUMBER")]
    public int IdPlaylist { get; set; }

    [Column("ID_MUSIC", TypeName = "NUMBER")]
    public int IdMusic { get; set; }

    [ForeignKey("IdMusic")]
    public virtual TbdSong IdMusicNavigation { get; set; }

    [ForeignKey("IdPlaylist")]
    public virtual TbdPlaylist IdPlaylistNavigation { get; set; }
}
