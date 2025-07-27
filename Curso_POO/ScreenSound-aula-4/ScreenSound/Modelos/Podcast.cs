namespace ScreenSound.Modelos;

internal class Podcast
{
    private List<Episodio> episodios = new List<Episodio>();
    public string Host { get; }
    public string Name { get; }
    public int TotalEpisodios { get => episodios.Count; }

    public Podcast(string host, string name)
    {
        Host = host;
        Name = name;
    }
    public void AdicionarEpisodio(Episodio episodio)
    {
        episodios.Add(episodio);
    }
    public void AddVariosEpisodios(List<Episodio> episodiosList)
    {
        foreach (var item in episodiosList)
        {
            episodios.Add(item);
        }
    }
    public void ExibirDetalhes()
    {
        Console.WriteLine($"Podcast: {Name} => Apresentador: {Host}");
        foreach (Episodio item in episodios.OrderBy(x => x.Ordem))
        {
            Console.WriteLine($"    {item.Resumo}");
        }
        Console.WriteLine($"\nTotal de Episodios: {TotalEpisodios}");
    }


}