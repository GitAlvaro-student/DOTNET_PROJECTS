using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSoundAPI.Data.Dtos.PlayList
{
    public class ReadPlaylistDTO
    {
        public string NomePlaylist { get; set; }
        public DateTime Ano { get; set; }
    }
}
