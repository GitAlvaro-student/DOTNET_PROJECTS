using ScreenSoundAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSoundAPI.Filtros
{
    internal class LinqOrderBy
    {
        public static void OrdenarArtistas(List<Musica> musicas)
        {
            var artistasOrdenados = musicas.OrderBy(artista => 
            artista.Artista).Select(artista => artista.Artista).Distinct();
            Console.WriteLine("Artistas Ordenados de A a Z");
            foreach (var artista in artistasOrdenados)
            {
                Console.WriteLine($"-> {artista}");
            }
        }
    }
}
