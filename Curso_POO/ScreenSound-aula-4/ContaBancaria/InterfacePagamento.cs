namespace ContaBancaria
{
    internal interface IInterfacePagamento
    {
        double CalcularPagamento();
    }

    internal class Produto : IInterfacePagamento
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }
        public double CalcularPagamento()
        {
            return Preco * Quantidade;
        }
    }
    internal class Servico : IInterfacePagamento
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Horas { get; set; }
        public Servico(string nome, double precoPorHora)
        {
            Nome = nome;
            Preco = precoPorHora;
        }
        public double CalcularPagamento()
        {
            return Preco * Horas;
        }
    }
}
