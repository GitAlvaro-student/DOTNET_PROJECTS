
namespace AluraFlix.Filmes;

class Artista
{
    public Artista(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
        Filmes = new List<Filme>();
    }

    public string Nome { get; set; }
    public int Idade { get; set; }
    public List<Filme> Filmes { get; set; }

    public void FilmeAtuado(Filme filme)
    {
        Filmes.Add(filme);
        if (!filme.Elenco.Contains(this))
        {
            filme.AdicionarAtor(this);
        }

    }

    public void DetalhesDoAtor()
    {
        Console.WriteLine($"Detalhes de {this.Nome}\n" +
            $"  Idade: {this.Idade}\n" +
            $"  Filmes Participados: ");

        foreach (var item in Filmes)
        {
            Console.WriteLine($"     {item.Titulo}");
        }
    }
}