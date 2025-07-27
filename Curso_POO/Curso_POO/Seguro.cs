class Seguro
{
    public Seguro(Classificacao tipoSeguro, string nome)
    {
        this.Tipo = tipoSeguro;
        this.Nome = nome;
    }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public Classificacao Tipo { get; }
    public string Cobertura { get; set; }
    public bool Vigencia { get; set; }
    public string NomeFantasia => $"{Nome} - {Tipo.Name}";
    

    public void ExibirFicha()
    {
        Console.WriteLine($"Nome do Seguro: {Nome}");
        Console.WriteLine($"Tipo do Seguro: {Tipo.Name}");
        Console.WriteLine($"Preco: R${Preco}");
        Console.WriteLine($"Cobertura: {Cobertura}");
        if (Vigencia == true)
        {
            Console.WriteLine("Vigencia: Seguro esta Vigente");
        }
        else 
        {
            Console.WriteLine($"Vigencia: Seguro não Está Vigente");
        }
    }
}

