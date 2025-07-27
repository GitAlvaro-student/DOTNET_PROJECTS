using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Menus
{
    internal class MenuAvaliarAlbum: Menu
    {
        public override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            base.Executar(bandasRegistradas);
            base.Executar(bandasRegistradas);
            ExibirTituloDaOpcao("Avaliar Album");
            Console.Write("Digite o nome da banda que deseja avaliar: ");
            string nomeDaBanda = Console.ReadLine()!;
            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Banda banda = bandasRegistradas[nomeDaBanda];
                Console.Write("Agora digite o título do álbum: ");
                string tituloAlbum = Console.ReadLine()!;
                if (banda.Albuns.Any(a => a.Nome.Equals(tituloAlbum)))
                {
                    Album album = banda.Albuns.First(a => a.Nome.Equals(tituloAlbum));
                    Console.WriteLine($"Qual nota o {album.Nome} merece: ");
                    Avaliacao aval = Avaliacao.Parse(Console.ReadLine()!);
                    album.AdicionarNota(aval);
                    Console.WriteLine("Nota Adicionada com Sucesso!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"\nO álbum {tituloAlbum} não foi encontrado na banda {nomeDaBanda}!");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
