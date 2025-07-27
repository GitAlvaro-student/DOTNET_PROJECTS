class Titular
{
    public string Informacoes => $"Nome: {this.Nome}, CPF: {this.Cpf}, Telefone: {this.Telefone}";

    public Titular(string nome, string cpf, string telefone)
    {
        Nome = nome;
        Cpf = cpf;
        Telefone = telefone;
    }

    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Telefone {  get; set; }

}