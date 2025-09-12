using AutoMapper;
using MusicSoundAPI.Data.Dtos.Music;
using MusicSoundAPI.Models;

namespace MusicSoundAPI.Profiles
{
    public class MusicProfile: Profile 
    {
        public MusicProfile()
        {
            CreateMap<TbdSong, CreateMusicDTO>();
            CreateMap<CreateMusicDTO, TbdSong>();
            CreateMap<ReadMusicDTO, TbdSong>();
            CreateMap<TbdSong, ReadMusicDTO>();
            CreateMap<UpdateMusicDTO, TbdSong>();
            CreateMap<TbdSong, UpdateMusicDTO>();
            CreateMap<UpdateMusicDTO, TbdSong>();
        }
    }
}
