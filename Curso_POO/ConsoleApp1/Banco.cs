class ContaBancanria
{
    public ContaBancanria(int contaId, string nrAgencia, Titular titular, decimal saldo, decimal limite, string senha)
    {
        ContaId = contaId;
        NrAgencia = nrAgencia;
        Titular = titular;
        Saldo = saldo;
        Limite = limite;
        Senha = senha;
    }

    public int ContaId { get; set; }
    public string NrAgencia { get; set; }
    public Titular Titular { get; set; }
    public decimal Saldo { get; set; }
    public decimal Limite { get; set; }
    public string Senha { get; set; }

    public string Informacoes => $"Conta nº {this.ContaId}, Agência {this.NrAgencia}, Titular: {this.Titular.Nome} - Saldo: {this.Saldo}";

    public void ExibirInfo()
    {
        Console.WriteLine("Informações do Conta: ");
        Console.WriteLine($"Número da Agência: {NrAgencia}\n" +
            $"Número da Conta: {ContaId}\n" +
            $"Titular: {Titular.Nome}\n" +
            $"Saldo: R${Saldo}\n" +
            $"Limite: {Limite}\n");
    }

    public void ExibirInfoTitular()
    {
        Console.WriteLine("Informações do Titular: ");
        Console.WriteLine($"Nome: {Titular.Nome}\n" +
            $"CPF: {Titular.Cpf}\n" +
            $"Telefone: {Titular.Telefone}\n");
    }

}

/*Modelar uma classe Conta, que tenha como atributos uma classe Titular, 
 * além de informações da conta, como agência, número da conta, saldo e limite, bem como um método que devolva as informações da conta de forma detalhada.
Instanciar um objeto do tipo Conta e um do tipo Titular e mostrar as informações de Titular, a partir da Conta.

Modelar o sistema de uma escola. Crie classes para Aluno, Professor e Disciplina. A classe Aluno deve ter informações como nome, 
idade e notas. A classe Professor deve ter informações sobre nome e disciplinas lecionadas. A classe Disciplina deve armazenar o nome da disciplina e a 
lista de alunos matriculados.
Modelar um sistema para um restaurante com classes como Restaurante, Mesa, Pedido e Cardapio. A classe Restaurante deve ter mesas que podem 
ser reservadas e um cardápio com itens que podem ser pedidos. Os pedidos podem estar associados a uma mesa.
*/