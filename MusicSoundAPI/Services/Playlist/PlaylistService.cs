using AutoMapper;
using MusicSoundAPI.Data.Dtos.Music;
using MusicSoundAPI.Data.Dtos.PlayList;
using MusicSoundAPI.Models;
using MusicSoundAPI.Repository.Playlist;

namespace MusicSoundAPI.Services.Playlist
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMapper _mapper;

        public PlaylistService(IPlaylistRepository playlistRepository, IMapper mapper)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
        }

        public async Task<TbdPlaylist> GetTbdPlaylistById(int idTbdPlaylist)
        {
            return await _playlistRepository.GetById(idTbdPlaylist);
        }

        public async Task<ReadPlaylistDTO> GetPlaylistById(int idTbdPlaylist)
        {
            var playlist = await _playlistRepository.GetById(idTbdPlaylist);
            return _mapper.Map<ReadPlaylistDTO>(playlist);
        }

        public async Task<IEnumerable<ReadPlaylistDTO>> GetPlayLists()
        {
            var playLists = await _playlistRepository.GetAll();
            return _mapper.Map<List<ReadPlaylistDTO>>(playLists);
        }

        public async Task InsertPlaylist(CreatePlaylistDTO playlist)
        {
            var playList = _mapper.Map<TbdPlaylist>(playlist);
            await _playlistRepository.InsertPlaylist(playList);
        }

    }
}
