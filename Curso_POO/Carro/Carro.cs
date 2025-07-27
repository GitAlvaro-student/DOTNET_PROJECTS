//Reescrever os atributos da classe Carro, de modo que eles sejam properties, e adicionar uma nova propertie 
//DescricaoDetalhada, que mostra o fabricante, modelo e ano do carro.
//Reescrever a propriedade Ano da classe carro, para que ela apenas aceite valores entre 1960 e 2023.
class Carro
{
    private int ano;
    public string Fabricante { get; set; }
    public string Modelo { get; set; }
    public int AnoCarro { get => ano;
        set {
            if (value > 2025 || value < 1960)
            {
                Console.WriteLine("Ano do Carro deve estar entre 1960 e 2025");
            }
            else 
            {
                ano = value;
            }
        } 
    }
    public string DescricaoDetalhada { get => $"{Fabricante} - {Modelo} - {AnoCarro}"; }

}