using AutoMapper;
using MusicSoundAPI.Data.Dtos.Music;
using MusicSoundAPI.Data.Dtos.PlayList;
using MusicSoundAPI.Models;

namespace MusicSoundAPI.Profiles
{
    public class PlaylistProfile : Profile
    {
        public PlaylistProfile()
        {
            CreateMap<TbdPlaylist, CreatePlaylistDTO>();
            CreateMap<CreatePlaylistDTO, TbdPlaylist>();
            CreateMap<ReadPlaylistDTO, TbdPlaylist>();
            CreateMap<TbdPlaylist, ReadPlaylistDTO>();
            CreateMap<UpdatePlaylistDTO, TbdPlaylist>();
            CreateMap<TbdPlaylist, UpdatePlaylistDTO>();
        }
    }
}
