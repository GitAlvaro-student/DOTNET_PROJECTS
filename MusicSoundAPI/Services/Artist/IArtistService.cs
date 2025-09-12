using MusicSoundAPI.Data.Dtos.Artist;
using MusicSoundAPI.Models;

namespace MusicSoundAPI.Services.Artist
{
    public interface IArtistService
    {
        Task<TbdArtist> GetTbdArtistById(int id);
        Task<ReadArtistDTO> GetArtistById(int id);
        Task<IEnumerable<ReadArtistDTO>> GetArtists();
        Task PostArtist(CreateArtistDTO artist);
        Task PutArtist(TbdArtist oldArtist, UpdateArtistDTO newArtist);
        Task DeleteArtist(TbdArtist artist);
    }
}
