namespace ScreenSound.Modelos;

internal class Banda : IAvaliavel
{
    private List<Album> albums = new List<Album>();
    private List<Avaliacao> notas = new ();
    public Banda(string nome)
    {
        Nome = nome;
    }
    public double Media
    {
        get
        {
            if (notas.Count == 0) return 0;
            else return notas.Average(a => a.Nota);
        }
    }
    public string? Resumo { get; set; }
    public string Nome { get; }
    public IEnumerable<Album> Albuns => albums;

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }
    public void AdicionarAlbum(Album album) 
    { 
        albums.Add(album);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia da banda {Nome}");
        foreach (Album album in albums)
        {
            Console.WriteLine($"Álbum: {album.Nome} ({album.DuracaoTotal})");
        }
    }
}