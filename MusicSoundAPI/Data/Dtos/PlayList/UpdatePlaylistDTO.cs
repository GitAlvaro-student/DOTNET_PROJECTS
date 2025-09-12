using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSoundAPI.Data.Dtos.PlayList
{
    public class UpdatePlaylistDTO
    {

        [Required]
        [Column("NOME_PLAYLIST")]
        [StringLength(100)]
        [Unicode(false)]
        public string NomePlaylist { get; set; }

        [Column("ANO", TypeName = "DATE")]
        public DateTime Ano { get; set; }
    }
}
