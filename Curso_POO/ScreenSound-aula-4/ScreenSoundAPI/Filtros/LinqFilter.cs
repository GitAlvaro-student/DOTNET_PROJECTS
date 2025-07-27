using ScreenSoundAPI.Models;
namespace ScreenSoundAPI.Filtros
{
    internal class LinqFilter
    {
        public static void FiltrarGeneros(List<Musica> musicas)
        {
            var genMusicais = musicas.Select(generos => generos.Gender).Distinct().ToList();
            foreach (var gen in genMusicais)
            {
                Console.WriteLine($"-> {gen}");
            }
        }

        public static void FiltrarArtistasPorGenero(List<Musica> musica, string genero)
        {
            var artistasPorGenero = musica.Where(musica => musica.Gender.Contains(genero)).Select(musica => musica.Artista).Distinct().ToList();
            Console.WriteLine("Artistas por Genêro Musical");
            foreach (var artista in artistasPorGenero)
            {
                Console.WriteLine($"-> {artista}");
            }
        }
        public static List<Musica> FiltrarMusicasPorArtista(List<Musica> musica, string artista)
        {
            var musicasArtista = musica.Where(musica => musica.Artista!.Equals(artista)).ToList();
            Console.WriteLine($"Musicas do(a): {artista}");
            foreach (var m in musicasArtista)
            {
                Console.WriteLine($"--> {m.Name}");
            }
            return musicasArtista;
        }
        public static void FiltrarMusicasPorAno(List<Musica> musica, int ano)
        {

            var musicasPorAno = musica.Where(b => int.Parse(b.AnoLancamento) == ano).OrderBy(b => b.Name);
            Console.WriteLine("Musicas Filtradas por Ano: ");
            foreach (var music in musicasPorAno)
            {
                Console.WriteLine($"{music.Name} -> {music.Artista} -> {music.AnoLancamento}");
            }
        }
        public static void FiltrarPelaTonalidade(List<Musica> musica, int key)
        {
            var musicasPorTom = musica.Where(t => t.Key == key).OrderBy(t => t.Name);
            Console.WriteLine($"Musicas Filtradas Pela Tonalidade: {key}");
            foreach (var music in musicasPorTom)
            {
                Console.WriteLine($"{music.Name} -> {music.Artista} -> {music.AnoLancamento} -> {music.Tonalidade}");
            }
        }
        public Dictionary<string, int> tons = new Dictionary<string, int>()
        {
            {"C", 0 },
            {"C#", 1},
            {"D", 2},
            {"D#", 3},
            {"E", 4},
            {"F", 5},
        };
        public int EscolherTonalidade()
        {
            while (true)
            {
                Console.WriteLine("Qual Tonalidade Voce Deseja? {C} {C#} {D} {D#} {E} {F}");
                var tom = Console.ReadLine()!;
                if (tons.ContainsKey(tom))
                {
                    var tonalidade = tons[tom];
                    return tonalidade;
                }
                else
                {
                    Console.WriteLine("Valor Invalido!!!");
                }
            }
        }
      
    }
}
