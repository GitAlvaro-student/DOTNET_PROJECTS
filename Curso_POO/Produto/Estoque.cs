class Estoque
{
    public List<Produto> Produto = new List<Produto>();

    public void ExibirProdutos()
    {
        Console.WriteLine("Produtos em Estoque");
        Console.WriteLine("************************************");
        foreach (Produto produto in Produto)
        {
            Console.WriteLine($"-> {produto.DescProd}");
        }
    }

    public void AdicionarProdutos(Produto produto)
    {
        Produto.Add(produto);
        Console.WriteLine("Produto Adicionado com Sucesso");
    }
}
/*Desenvolver uma classe que represente um estoque de produtos, e que tenha as funcionalidades de adicionar novos produtos, 
e exibir todos os produtos no estoque..*/