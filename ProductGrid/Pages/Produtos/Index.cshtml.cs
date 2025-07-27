using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ProductGrid.Models;

namespace ProductGrid.Pages.Produtos
{
    public class IndexGridModel : PageModel
    {
        public List<Produto> Produtos { get; set; }

        public void OnGet()
        {
            // Dados fict�cios para demonstra��o
            Produtos = new List<Produto>
            {
            };
        }
    }


    public class IndexModel : PageModel
    {
        public List<Produto> Produtos { get; set; }

        public void OnGet()
        {
            // Example data for demonstration purposes  
            Produtos = new List<Produto>
                {
                new Produto { Id = 1, Nome = "Smartphone Max 12 Camera Frontal Tripla, Processador SnapDragon e Resist�ncia a �gua", Categoria = "Eletr�nicos", Preco = 3599.99M, LojaVendedora = "TechStore", Marca = "Mobix", DataLancamento = new DateTime(2024, 11, 15), QuantidadeEstoque = 25 },
                new Produto { Id = 2, Nome = "Notebook ProBook X", Categoria = "Inform�tica", Preco = 4799.50M, LojaVendedora = "InfoShop", Marca = "CyberTech", DataLancamento = new DateTime(2023, 8, 10), QuantidadeEstoque = 12 },
                new Produto { Id = 3, Nome = "Geladeira Frost 500L com Congelador Incluso - Congelamento em at� 0,5 hora", Categoria = "Eletrodom�sticos", Preco = 2699.00M, LojaVendedora = "EletroTop", Marca = "FrioLar", DataLancamento = new DateTime(2022, 5, 20), QuantidadeEstoque = 8 },
                new Produto { Id = 4, Nome = "TV 4K Ultra HD 55\"", Categoria = "Eletr�nicos", Preco = 3199.90M, LojaVendedora = "MegaEletr�nicos", Marca = "VisionTech", DataLancamento = new DateTime(2024, 2, 12), QuantidadeEstoque = 30 },
                new Produto { Id = 5, Nome = "Cafeteira El�trica Aroma Plus", Categoria = "Eletroport�teis", Preco = 299.99M, LojaVendedora = "UtilLar", Marca = "Caf�Bom", DataLancamento = new DateTime(2021, 9, 5), QuantidadeEstoque = 50 },
                new Produto { Id = 6, Nome = "Bicicleta Speed 700", Categoria = "Esportes", Preco = 1599.00M, LojaVendedora = "BikeMania", Marca = "PedalFit", DataLancamento = new DateTime(2023, 3, 18), QuantidadeEstoque = 15 },
                new Produto { Id = 7, Nome = "Fone de Ouvido Bluetooth Sound X", Categoria = "Acess�rios", Preco = 249.90M, LojaVendedora = "Som&Imagem", Marca = "AudioWave", DataLancamento = new DateTime(2024, 7, 1), QuantidadeEstoque = 60 },
                new Produto { Id = 8, Nome = "Console GameStation 5", Categoria = "Games", Preco = 4299.00M, LojaVendedora = "GameWorld", Marca = "NextPlay", DataLancamento = new DateTime(2023, 11, 22), QuantidadeEstoque = 20 },
                new Produto { Id = 9, Nome = "M�quina de Lavar 11kg TurboWash", Categoria = "Eletrodom�sticos", Preco = 2199.00M, LojaVendedora = "Casa&Cia", Marca = "LavaF�cil", DataLancamento = new DateTime(2022, 6, 30), QuantidadeEstoque = 10 },
                new Produto { Id = 10, Nome = "Smartwatch FitBand 3", Categoria = "Tecnologia", Preco = 399.00M, LojaVendedora = "Wearables Store", Marca = "TimeUp", DataLancamento = new DateTime(2024, 4, 8), QuantidadeEstoque = 40 },
                new Produto { Id = 11, Nome = "Liquidificador PowerMix", Categoria = "Eletroport�teis", Preco = 149.90M, LojaVendedora = "UtilLar", Marca = "MixPlus", DataLancamento = new DateTime(2021, 10, 25), QuantidadeEstoque = 70 },
                new Produto { Id = 12, Nome = "T�nis Corrida AirSpeed", Categoria = "Moda", Preco = 329.90M, LojaVendedora = "SportWear", Marca = "RunPro", DataLancamento = new DateTime(2023, 1, 15), QuantidadeEstoque = 90 },
                new Produto { Id = 13, Nome = "Tablet Android TabX 10", Categoria = "Inform�tica", Preco = 899.99M, LojaVendedora = "TechZone", Marca = "DigiTab", DataLancamento = new DateTime(2024, 5, 20), QuantidadeEstoque = 25 },
                new Produto { Id = 14, Nome = "Aspirador de P� RoboClean 3000 Limpa Castelo e Por�o sem se cansar", Categoria = "Casa Inteligente", Preco = 1499.90M, LojaVendedora = "SmartHome", Marca = "CleanBot", DataLancamento = new DateTime(2023, 7, 10), QuantidadeEstoque = 14 },
                new Produto { Id = 15, Nome = "Ar Condicionado Split 12000 BTUs", Categoria = "Climatiza��o", Preco = 2399.00M, LojaVendedora = "FrioF�cil", Marca = "ArCool", DataLancamento = new DateTime(2022, 12, 1), QuantidadeEstoque = 9 },
                new Produto { Id = 16, Nome = "Produto A", Categoria = "Categoria 1", Preco = 100.00m, LojaVendedora = "Loja X", Marca = "Marca Y", DataLancamento = new DateTime(2023, 1, 1), QuantidadeEstoque = 50 },
                new Produto { Id = 17, Nome = "Produto B", Categoria = "Categoria 2", Preco = 200.00m, LojaVendedora = "Loja Z", Marca = "Marca W", DataLancamento = new DateTime(2023, 2, 1), QuantidadeEstoque = 30 },
                new Produto { Id = 18, Nome = "Smartphone Zeta", Categoria = "Eletr�nicos", Preco = 1500.00m, LojaVendedora = "Tech Store", Marca = "ZetaTech", DataLancamento = new DateTime(2024, 3, 15), QuantidadeEstoque = 20 },
                new Produto { Id = 19, Nome = "Cafeteira El�trica", Categoria = "Eletrodom�sticos", Preco = 350.00m, LojaVendedora = "Casa & Cia", Marca = "Caf�Bom", DataLancamento = new DateTime(2022, 11, 10), QuantidadeEstoque = 12 },
                new Produto { Id = 20, Nome = "T�nis Runner Pro", Categoria = "Cal�ados", Preco = 299.99m, LojaVendedora = "Esporte Total", Marca = "Runner", DataLancamento = new DateTime(2023, 8, 5), QuantidadeEstoque = 40 },
                new Produto { Id = 21, Nome = "Notebook Ultra 15", Categoria = "Inform�tica", Preco = 4200.00m, LojaVendedora = "InfoWorld", Marca = "UltraTech", DataLancamento = new DateTime(2024, 1, 20), QuantidadeEstoque = 8 },
                new Produto { Id = 22, Nome = "Livro: C# Essencial", Categoria = "Livros", Preco = 89.90m, LojaVendedora = "Livraria Central", Marca = "Editora Alpha", DataLancamento = new DateTime(2023, 5, 12), QuantidadeEstoque = 100 },
                new Produto { Id = 23, Nome = "Fone de Ouvido Bluetooth", Categoria = "Acess�rios", Preco = 159.90m, LojaVendedora = "Tech Store", Marca = "SoundMax", DataLancamento = new DateTime(2024, 2, 28), QuantidadeEstoque = 60 },

                };
        }
    }

}