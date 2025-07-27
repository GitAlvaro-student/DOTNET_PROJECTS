namespace Animais;

internal class Animais
{
    public string Nome { get; set; }
    public string Especie { get; set; }

    public virtual string EmitirSom()
    {
        return "Som genérico de animal";
    }
}
