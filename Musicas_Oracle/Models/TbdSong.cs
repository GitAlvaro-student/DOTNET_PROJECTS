using System;
using System.Collections.Generic;

namespace Musicas_Oracle.Models;

public partial class TbdSong
{
    public int IdMusic { get; set; }

    public string Artista { get; set; } = null!;

    public string Musica { get; set; } = null!;

    public string? Genero { get; set; }

    public int? Popularidade { get; set; }

    public int Duracao { get; set; }

    public int Ano { get; set; }

    public static TbdSong FromJson(MusicaJson musicaJson)
    {
        return new TbdSong
        {
            Artista = musicaJson.artist,
            Musica = musicaJson.song,
            Duracao = musicaJson.duration_ms,
            Ano = int.TryParse(musicaJson.year, out int ano) ? ano : 0,
            Popularidade = int.TryParse(musicaJson.popularity, out int pop) ? pop : 0,
            Genero = musicaJson.genre
        };
    }
}
