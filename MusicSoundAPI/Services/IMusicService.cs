using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using MusicSoundAPI.Data.Dtos;
using MusicSoundAPI.Models;
using MusicSoundAPI.Repository.Music;

namespace MusicSoundAPI.Services
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
