namespace AluraFlix.Filmes;

class Filme
{
    public Filme(string titulo, int duracao, List<Artista> elenco)
    {
        Titulo = titulo;
        Duracao = duracao;
        Elenco = elenco;
        if (elenco == null)
        {
            Elenco = new List<Artista>();
        }
        else
        {
            Elenco = elenco;
            foreach (var artista in Elenco)
            {
                artista.FilmeAtuado(this);
            }
        }
    }

    public string Titulo { get; set; }
    public int Duracao { get; set; }
    public List<Artista> Elenco {  get; set; }

    public void Detalhes()
    {
        Console.WriteLine($"=> {this.Titulo} -> {this.Duracao}min\n" +
            $"  Elenco:");
        foreach (var ator in Elenco)
        {
            Console.WriteLine($"        {ator.Nome}");
        }
    }
    public void AdicionarAtor(Artista ator)
    {
        Elenco.Add(ator);
        if (!ator.Filmes.Contains(this))
        {
            ator.FilmeAtuado(new Filme(this.Titulo, this.Duracao, this.Elenco));
        }
    }
}
