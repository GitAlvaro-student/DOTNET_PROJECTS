class Portifolio
{
    private int totSeguros;
    private List<Seguro> seguro = new List<Seguro>();

    public Portifolio(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }
    public int TotalSeguros { get => seguro.Count; }

    public void AdicionarSeguro(Seguro insure)
    {
        seguro.Add(insure);
    }

    public void ExibirSeguros()
    {
        Console.WriteLine($"Seguros em {this.Nome}\n");
        foreach (Seguro seguro in seguro)
        {
            Console.WriteLine(seguro.Nome);
        }
        Console.WriteLine($"\n {TotalSeguros} Seguros Disponíveis em {this.Nome}");
    }
}