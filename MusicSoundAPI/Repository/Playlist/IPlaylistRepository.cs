using MusicSoundAPI.Models;

namespace MusicSoundAPI.Repository.Playlist
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<TbdPlaylist>> GetAll();
        Task<TbdPlaylist> GetById(int id);
        Task InsertPlaylist(TbdPlaylist playlist);
    }
}
