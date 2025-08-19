using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using MusicSoundAPI.ApplicationDbContext;
using MusicSoundAPI.Data.Dtos;
using MusicSoundAPI.Models;
using System.Threading.Tasks;

namespace MusicSoundAPI.Repository.Music
{
    /// <summary>
    /// Representa o Repositório de Músicas
    /// </summary>
    public class MusicRepository : IMusicRepository
    {
        private ModelContext appDbContext;
        public MusicRepository(ModelContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<TbdSong>> GetMusics()
        {
            return await appDbContext.TbdSongs.ToListAsync();
        }

        public async Task<TbdSong> GetMusicById(int id)
        {
            return await appDbContext.TbdSongs.FindAsync(id);
        }

        public async Task<IEnumerable<TbdSong>> GetMusicsByArtist(int idArtist)
        {
            return await appDbContext.TbdSongs.Where(x => x.IdArtist == idArtist)
                .Select(x => new TbdSong
                {
                    IdMusic = x.IdMusic,
                    Musica = x.Musica,
                    Popularidade = x.Popularidade,
                    Duracao = x.Duracao,
                    Ano = x.Ano,
                    IdArtist = x.IdArtist
                })
                .ToListAsync();
        }
        public async Task InsertMusic(TbdSong song)
        {
            appDbContext.TbdSongs.Add(song);
            await appDbContext.SaveChangesAsync();
        }
        public async Task UpdateMusic(TbdSong music, TbdSong newMusic)
        {
            appDbContext.Entry(music).CurrentValues.SetValues(newMusic);
            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteMusic(TbdSong music)
        {
            appDbContext.TbdSongs.Remove(music);
            await appDbContext.SaveChangesAsync();
        }
    }
}
