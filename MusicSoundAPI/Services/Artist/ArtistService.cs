using AutoMapper;
using MusicSoundAPI.Data.Dtos.Artist;
using MusicSoundAPI.Data.Dtos.Music;
using MusicSoundAPI.Models;
using MusicSoundAPI.Repository.Artist;
using MusicSoundAPIStandard.Models;

namespace MusicSoundAPI.Services.Artist
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public ArtistService(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        //public async Task<TbdArtist> GetTbdArtistById(int idTbdArtist)
        //{
        //    return await _artistRepository.GetArtistById(idTbdArtist);
        //}

        public async Task<TbdArtist> GetTbdArtistById(int idArtist)
        {
            var artist = await _artistRepository.GetArtistById(idArtist);
            return artist;
        }

        public async Task<ReadArtistDTO> GetArtistById(int idArtist)
        {
            var artist = await _artistRepository.GetArtistById(idArtist);
            return _mapper.Map<ReadArtistDTO>(artist);
        }

        public async Task<IEnumerable<ReadArtistDTO>> GetArtists()
        {
            var artists = await _artistRepository.GetArtists();
            return _mapper.Map<IEnumerable<ReadArtistDTO>>(artists);
        }

        public async Task PostArtist(CreateArtistDTO artist)
        {
            var artista = _mapper.Map<TbdArtist>(artist);
            await _artistRepository.InsertArtist(artista);
        }

        public async Task PutArtist(TbdArtist oldArtist, UpdateArtistDTO newArtist)
        {
            var artistUpdating = _mapper.Map<TbdArtist>(newArtist);
            artistUpdating.IdArtist = oldArtist.IdArtist;

            await _artistRepository.UpdateArtist(oldArtist, artistUpdating);
        }

        public async Task DeleteArtist(TbdArtist artist)
        {
            await _artistRepository.DeleteArtist(artist);
        }

    }
}
