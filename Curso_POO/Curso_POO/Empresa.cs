class Empresa
{
    private List<Portifolio> portifolios = new List<Portifolio>();

    public Empresa(string nome)
    {
        this.Name = nome;
    }
    public string Name { get; }
    public void AdicionarPortifolio(Portifolio portifolio)
    {
        portifolios.Add(portifolio);
    }
    public void ExibirPortfolios()
    {
        Console.WriteLine($"Portifolios da {this.Name}");
        foreach(Portifolio port in portifolios)
        {
            Console.WriteLine($"-> {port.Nome} =>" +
                $" {port.TotalSeguros} Seguros Disponiveis em {port.Nome}");
        }
    }
}