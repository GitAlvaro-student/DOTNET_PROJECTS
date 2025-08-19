using Microsoft.AspNetCore.JsonPatch;
using MusicSoundAPI.Data.Dtos;
using MusicSoundAPI.Models;

namespace MusicSoundAPI.Repository.Music
{
    public interface IMusicRepository
    {
        Task<IEnumerable<TbdSong>> GetMusics();
        Task<TbdSong> GetMusicById(int idMusic);
        Task<IEnumerable<TbdSong>> GetMusicsByArtist(int idArtist);
        Task InsertMusic(TbdSong music);
        Task UpdateMusic(TbdSong music, TbdSong newSong);
        Task DeleteMusic(TbdSong music);
    }
}
