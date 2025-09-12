using MusicSoundAPI.Data.Dtos.PlayList;
using MusicSoundAPI.Models;

namespace MusicSoundAPI.Services.Playlist
{
    public interface IPlaylistService
    {
        Task<TbdPlaylist> GetTbdPlaylistById(int id);
        Task<ReadPlaylistDTO> GetPlaylistById(int id);
        Task<IEnumerable<ReadPlaylistDTO>> GetPlayLists();
        Task InsertPlaylist(CreatePlaylistDTO playlist);
    }
}
