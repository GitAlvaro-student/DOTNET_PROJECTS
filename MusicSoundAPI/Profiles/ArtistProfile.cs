using AutoMapper;
using MusicSoundAPI.Data.Dtos.Artist;
using MusicSoundAPI.Models;

namespace MusicSoundAPI.Profiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<TbdArtist, CreateArtistDTO>();
            CreateMap<CreateArtistDTO, TbdArtist>();
            CreateMap<ReadArtistDTO, TbdArtist>();
            CreateMap<TbdArtist, ReadArtistDTO>();
            CreateMap<UpdateArtistDTO, TbdArtist>();
            CreateMap<TbdArtist, UpdateArtistDTO>();
            CreateMap<UpdateArtistDTO, TbdArtist>();
        }

    }
}
