using System.Text.Json.Nodes;

Console.WriteLine("Digite um numero: ");
long a = long.Parse(Console.ReadLine());
Console.WriteLine("Digite um numero: ");
long b = long.Parse(Console.ReadLine());
try
{
    long result = a / b;
    Console.WriteLine($"Resultado da Divisao: {result}");
}
catch (Exception ex)
{
    Console.WriteLine($"O seguinte erro ocorreu: {ex.Message}");

}

List<int> ints = new List<int>() { 32, 15, 25, 39, 14, 11, 17, 13 };
try
{
    for (int i = 0; i < 9; i++)
    {
        Console.WriteLine(ints[i]);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"O seguinte erro ocorreu: {ex.Message}");
}
//using ScreenSoundAPI.ExerciciosAPI;
//try
//{
//    Promocao jogo = new Promocao();
//    if (jogo.titulo == null)
//    {
//        throw new Exception("O Titulo estava Nulo");
//    }
//    else
//    {
//        Console.WriteLine(jogo.Detalhes());
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"O seguinte erro ocorreu: {ex.Message}");
//}


using (HttpClient client = new HttpClient())
{
    try
    {
        Dictionary<string, string> jogos = new Dictionary<string, string>();
        string resposta = await client.GetStringAsync("https://www.cheapshark.com/api/1.0/deals");
        var jsonArray = JsonNode.Parse(resposta)?.AsArray();
        Console.WriteLine("Lista de Jogos em Promoção");
        for (int i = 0; i < jsonArray.Count; i++)
        {
            var name = jsonArray[i]["title"]?.ToString() ?? "Sem título";
            var price = jsonArray[i]["normalPrice"]?.ToString() ?? "Sem preço";
            var jogo = new Games(name, price);
            if (!jogos.ContainsKey(name))
            {
                jogos.Add(name, price);
                Console.WriteLine($"\n{name} -------------------------------------> {price}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"O Seguinte erro aconteceu: {ex.Message}");
        throw;
    }
}

public class Games
{
    public Games(string title, string normalPrice)
    {
        this.title = title;
        this.normalPrice = normalPrice;
    }

    public string title { get; set; }
    public string normalPrice { get; set; }
}
