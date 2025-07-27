namespace ScreenSound.Modelos;

internal class Episodio
{
    private List<string> convidados = new List<string>();
    public int Ordem { get; }
    public int Duracao {  get; }
    public string Titulo { get; }
    public string Resumo => $"{Ordem} -> {Titulo}({Duracao}min)\n" +
        $"                                  feat. {string.Join(", ", convidados)}";

    public Episodio(int ordem, int duracao, string titulo)
    {
        Ordem = ordem;
        Duracao = duracao;
        Titulo = titulo;
    }

    public void AddConvidado(string convidado)
    {
        convidados.Add(convidado);
    }
}