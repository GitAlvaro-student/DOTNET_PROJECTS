using MusicSoundAPI.Models;

namespace MusicSoundAPI.Repository.Artist
{
    public interface IArtistRepository
    {
        Task<IEnumerable<TbdArtist>> GetArtists();
        Task<TbdArtist> GetArtistById(int idArtist);
        int GetIdArtistByName(string artistName);
        Task InsertArtist(TbdArtist artist);
        Task UpdateArtist(TbdArtist artist, TbdArtist newArtist);
        Task DeleteArtist(TbdArtist IdArtist);
    }
}
