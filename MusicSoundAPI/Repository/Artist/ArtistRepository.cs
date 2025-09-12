using Microsoft.EntityFrameworkCore;
using MusicSoundAPI.ApplicationDbContext;
using MusicSoundAPI.Models;
using MusicSoundAPI.Repository.Music;

namespace MusicSoundAPI.Repository.Artist
{
    public class ArtistRepository : IArtistRepository
    {
        private ModelContext appDbContext;
        public ArtistRepository(ModelContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<TbdArtist>> GetArtists()
        {
            return await appDbContext.TbdArtists.ToListAsync();
        }

        public async Task<TbdArtist> GetArtistById(int id)
        {
            return await appDbContext.TbdArtists.FindAsync(id);
        }

        public int GetIdArtistByName(string artistName)
        {
            var artist = appDbContext.TbdArtists.Where(a => a.Artista == artistName).FirstOrDefault();
            return artist.IdArtist;
        }

        public async Task InsertArtist(TbdArtist artist)
        {
            appDbContext.TbdArtists.Add(artist);
            await appDbContext.SaveChangesAsync();
        }
        public async Task UpdateArtist(TbdArtist artist, TbdArtist newArtist)
        {
            appDbContext.Entry(artist).CurrentValues.SetValues(newArtist);
            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteArtist(TbdArtist artist)
        {
            appDbContext.TbdArtists.Remove(artist);
            await appDbContext.SaveChangesAsync();

        }
    }

}
