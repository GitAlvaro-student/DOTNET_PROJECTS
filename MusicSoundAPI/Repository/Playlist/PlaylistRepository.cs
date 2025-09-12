using Microsoft.EntityFrameworkCore;
using MusicSoundAPI.ApplicationDbContext;
using MusicSoundAPI.Models;

namespace MusicSoundAPI.Repository.Playlist
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private ModelContext appDbContext;
        public PlaylistRepository(ModelContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<TbdPlaylist>> GetAll()
        {
            return await appDbContext.TbdPlaylists.ToListAsync();
        }

        public async Task<TbdPlaylist> GetById(int id)
        {
            return await appDbContext.TbdPlaylists.FindAsync(id);
        }

        public async Task InsertPlaylist(TbdPlaylist playlist)
        {
            appDbContext.TbdPlaylists.Add(playlist);
            await appDbContext.SaveChangesAsync();
        }
    }
}
