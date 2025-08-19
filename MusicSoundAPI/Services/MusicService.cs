using AutoMapper;
using MusicSoundAPI.Data.Dtos;
using MusicSoundAPI.Models;
using MusicSoundAPI.Repository.Music;
using System;

namespace MusicSoundAPI.Services
{
    public class MusicService : IMusicService
    {
        private readonly IMusicRepository _musicRepository;
        private readonly IMapper _mapper;

        public MusicService(IMusicRepository musicRepository, IMapper mapper)
        {
            _musicRepository = musicRepository;
            _mapper = mapper;
        }

        public async Task<TbdSong> GetTbdSongById(int idTbdSong)
        {
            return await _musicRepository.GetMusicById(idTbdSong);
        }

        public async Task<ReadMusicDTO> GetMusicById(int idMusic)
        {
            var songs = await _musicRepository.GetMusicById(idMusic);
            return _mapper.Map<ReadMusicDTO>(songs);
        }
        public async Task<IEnumerable<ReadMusicDTO>> GetMusics()
        {
            var songs = await _musicRepository.GetMusics();
            return _mapper.Map<List<ReadMusicDTO>>(songs);

        }

        public async Task InsertMusic(CreateMusicDTO music)
        {
            var song = _mapper.Map<TbdSong>(music);
            await _musicRepository.InsertMusic(song);
        }

        public async Task UpdateMusic(TbdSong song, UpdateMusicDTO music)
        {
            var musicUpdating = _mapper.Map<TbdSong>(music);
            musicUpdating.IdMusic = song.IdMusic;

            await _musicRepository.UpdateMusic(song, musicUpdating);
        }

        public async Task DeleteMusic(TbdSong music)
        {
            await _musicRepository.DeleteMusic(music);
        }
    }
}
