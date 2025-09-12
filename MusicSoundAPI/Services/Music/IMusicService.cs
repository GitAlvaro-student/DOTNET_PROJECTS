using MusicSoundAPI.Data.Dtos.Music;
using MusicSoundAPI.Models;

namespace MusicSoundAPI.Services.Music
{
    public interface IMusicService
    {
        Task<TbdSong> GetTbdSongById(int id);
        Task<ReadMusicDTO> GetMusicById(int id);
        Task<IEnumerable<ReadMusicDTO>> GetMusics();
        //Task<IEnumerable<ReadMusicDTO>> GetMusicsByArtist(int idArtist);
        Task InsertMusic(CreateMusicDTO music);
        Task UpdateMusic(TbdSong music, UpdateMusicDTO newSong);
        Task DeleteMusic(TbdSong music);
    }
}
