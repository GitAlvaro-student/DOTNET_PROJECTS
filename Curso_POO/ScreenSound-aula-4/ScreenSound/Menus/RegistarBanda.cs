using OpenAI;
using ScreenSound.Menus;
using ScreenSound.Modelos;

internal class RegistarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda newBanda = new($"{nomeDaBanda}");
        bandasRegistradas.Add(newBanda.Nome, newBanda);
        Console.WriteLine($"A banda {newBanda.Nome} foi registrada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
    }

}