
class Produto
{
    private decimal precoValido;
    private int estoqueValido;
    public string Nome { get; set; }
    public string Marca { get; set; }
    public decimal Preco 
    { get => precoValido;
        set
        {
            if (value > 0)
            {
                precoValido = value; 
            }
            else
            {
                Console.WriteLine("Preço Inválido, o Preço tem que ser maior que 0!");
            }
        }
            
    }
    public int Estoque 
    { get => estoqueValido;
        set
        {
            if (value > 0)
            {
                estoqueValido = value; 
            }
            else
            {
                Console.WriteLine("Estoque Inválido, o Estoque tem que ser maior que 0!");
            }
        }
    }

    public string DescProd  => $"{Nome} - {Marca} - R${Preco} - {Estoque} Unidades";
}