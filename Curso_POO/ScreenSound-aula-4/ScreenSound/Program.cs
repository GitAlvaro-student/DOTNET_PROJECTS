using ScreenSound.Modelos;
using ScreenSound.Menus;
using OpenAI;

//var client = new OpenAIAPI("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");

Avaliacao a1 = new(10);
Avaliacao a2 = new(9);
Avaliacao a3 = new(8);
Banda acdc = new("ACDC");
acdc.AdicionarNota(a1);
acdc.AdicionarNota(a2);
acdc.AdicionarNota(a3);

Dictionary<string, Banda> bandasRegistradas = new();
bandasRegistradas.Add(acdc.Nome, acdc );
Dictionary<int, Menu> menuOpcoes = new();
menuOpcoes.Add(1, new RegistarBanda());
menuOpcoes.Add(2, new RegistrarAlbum());
menuOpcoes.Add(3, new MostrarBandas());
menuOpcoes.Add(4, new AvaliarBanda());
menuOpcoes.Add(5, new MenuAvaliarAlbum());
menuOpcoes.Add(6, new ExibirDetalhes());
menuOpcoes.Add(-1, new MenuSair()); 
void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para avaliar um album");
    Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    if (menuOpcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuEscolhido = menuOpcoes[opcaoEscolhidaNumerica];
        menuEscolhido.Executar(bandasRegistradas);
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

