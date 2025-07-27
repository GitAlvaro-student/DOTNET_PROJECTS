using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace ScreenSound.Menus;

internal class ExibirDetalhes : Menu
{
    
    public override async void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Exibir detalhes da banda");
        Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            // Gera e exibe o resumo antes da média
            string resumo = await GerarResumoIAAsync(nomeDaBanda);
            Console.WriteLine($"\nResumo IA: {resumo}\n");

            Banda notasDaBanda = bandasRegistradas[nomeDaBanda];
            Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Media}.");
            foreach(Album album in notasDaBanda.Albuns)
            {
                Console.WriteLine($"{album.Nome} -> {album.Media}");
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
    async Task<string> GerarResumoIAAsync(string nomeBanda)
    {
        var apiKey = "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";
        var endpoint = "https://api.openai.com/v1/chat/completions";
        var prompt = $"Resuma em um Paragrafo e de maneira descontraída a seguinte banda: {nomeBanda}";

        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
            new { role = "user", content = prompt }
        },
            max_tokens = 100
        };

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        var response = await client.PostAsync(endpoint, content);
        var responseString = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(responseString);
        var resumo = doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return resumo;
    }
}