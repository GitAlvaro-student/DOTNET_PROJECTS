using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ScreenSoundAPI.Models
{
    internal class Preferidas
    {

        public string Nome { get; set; }
        public List<Musica> ListaMusicasFavoritas { get; set; }
        public Preferidas(string nome)
        {
            Nome = nome;
            ListaMusicasFavoritas = new List<Musica>();
        }
        public void AddMusic(Musica musica)
        {
            ListaMusicasFavoritas.Add(musica);
        }
        public void ExibirMusicasFavoritas()
        {
            Console.WriteLine($"Essas são as músicas favoritas {Nome}");
            foreach (var music in ListaMusicasFavoritas)
            {
                Console.WriteLine($"{music.Name} -> {music.Artista}");
            }
        }
        public void GerarArquivoJson()
        {
            string json = JsonSerializer.Serialize(new
            {
                nome = Nome,
                musicas = ListaMusicasFavoritas
            });
            string nomeDoArquivo = $"musicas_favoritas_{Nome}.json";
            File.WriteAllText(nomeDoArquivo, json);
            Console.WriteLine($"Arquivo Criado com Sucesso! Caminho: {Path.GetFullPath(nomeDoArquivo)}");
        }
    }
}
