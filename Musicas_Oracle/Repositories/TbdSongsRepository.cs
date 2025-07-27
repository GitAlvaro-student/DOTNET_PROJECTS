using Musicas_Oracle.Context;
using Musicas_Oracle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Musicas_Oracle.Repositories
{
    public class TbdSongsRepository : ITbdSongsRepository
    {
        private readonly ModelContext _context;
        
        public TbdSongsRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task InserirMusicasFromJsonAsync(string jsonMusics)
        {
            try
            {
                var musicasJson = JsonSerializer.Deserialize<List<MusicaJson>>(jsonMusics);
                var musicsToInsert = new List<TbdSong>();

                foreach (var music in musicasJson)
                {
                    int i = 0;
                    var musicaFormatada = TbdSong.FromJson(music);
                    musicsToInsert.Add(musicaFormatada);
                    i++;
                    if (i >= 1)
                    {
                        break;
                    }
                }
                if (musicsToInsert.Any())
                {
                    var mus = TbdSong.FromJson(musicasJson[0]);
                    _context.TbdSongs.Add(mus);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"O seguinte erro ocorreu: {ex.Message}");
                throw;
            }
        }
    }
}
