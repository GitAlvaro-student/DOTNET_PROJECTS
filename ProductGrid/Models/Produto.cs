namespace ProductGrid.Models;
public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Categoria { get; set; }
    public decimal Preco { get; set; }
    public string LojaVendedora { get; set; }
    public string Marca { get; set; }
    public DateTime DataLancamento { get; set; }
    public int QuantidadeEstoque { get; set; }
}