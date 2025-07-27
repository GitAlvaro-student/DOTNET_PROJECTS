using Filme.Filtros;
using Filme.Modelos;
using Modelos.Cars;
using Modelos.Filme;
using Modelos.Pais;
using System.Diagnostics.Metrics;
using System.Text.Json;
using System.Text.Json.Serialization;

using (HttpClient client = new HttpClient())
{
	try
	{
		//string movies = await client.GetStringAsync("https://raw.githubusercontent.com/ArthurOcFernandes/Exerc-cios-C-/curso-4-aula-2/Jsons/TopMovies.json");
		////var listMovies = new List<Modelos.Filme.Movie>();
		//var jsonMovies = JsonSerializer.Deserialize<List<Movie>>(movies)!;
		//foreach (var item in jsonMovies)
		//{
		//	Console.WriteLine($"Filme: {item.Title} ---> Nota: {item.imDbRating}");
		//}
		//Console.WriteLine();
		//string countries = await client.GetStringAsync("https://raw.githubusercontent.com/ArthurOcFernandes/Exerc-cios-C-/curso-4-aula-2/Jsons/Paises.json");
		//var listCountries = new List<Country>();
		//var jsonCountry = JsonSerializer.Deserialize<List<Country>>(countries)!;
		//foreach (var item in jsonCountry)
		//{
		//	Console.WriteLine($"Pais: {item.Title} ---> Populacao: {item.imDbRating}");
		//}
		//      Console.WriteLine();
		//string cars = await client.GetStringAsync("https://raw.githubusercontent.com/ArthurOcFernandes/Exerc-cios-C-/curso-4-aula-2/Jsons/Carros.json");

		//var jsonCars = JsonSerializer.Deserialize<List<Cars>>(cars)!;
		//foreach (var item in jsonCars)
		//{
		//	Console.WriteLine(item.Marca + " -> " + item.Modelo);
		//}
		//string livro = await client.GetStringAsync("https://raw.githubusercontent.com/ArthurOcFernandes/Exerc-cios-C-/curso-4-aula-2/Jsons/Livros.json");
		//Console.WriteLine();
		//var jsonLivros = JsonSerializer.Deserialize<List<Book>>(livro)!;
		//LinqFilter.FiltrarLivrosPorAno(jsonLivros, 1950);
		//foreach (var item in jsonLivros)
		//{
		//	Console.WriteLine(item.Titulo + " -> " + item.Autor);
		//}
		//List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3 };
		//LinqFilter.FiltrarPares(numeros);
		Pessoa pessoa = new Pessoa()
		{
			Nome = "Silvio",
			Email = "Silvio@br.gmail.com",
			Idade = 43
		};
		Pessoa pessoa2 = new Pessoa()
		{
			Nome = "Leticia",
			Email = "Leticia@br.gmail.com",
			Idade = 27
		};
		Pessoa pessoa3 = new Pessoa()
		{
			Nome = "TCK",
			Email = "TCK_Cloud9@br.gmail.com",
			Idade = 25
		};
		//List<Pessoa> pessoas = new List<Pessoa> { pessoa, pessoa2, pessoa3 };
		//var json = JsonSerializer.Serialize(pessoas);
		string nomeDoArquivo = $"info_Pessoas.json";
		//File.WriteAllText(nomeDoArquivo, json);
		//Console.WriteLine($"Arquivo Gerado. Caminho: {Path.GetFullPath(nomeDoArquivo)}");
		//var arquivo = File.ReadAllText(nomeDoArquivo);
		//var jsonPessoa = JsonSerializer.Deserialize<List<Pessoa>>(arquivo);
		//foreach (var pess in jsonPessoa)
		//{
		//	pess.ExibirInfo();
		//}
		//pessoa.GerarJson(pessoa);
		//pessoa.LerJson($"info_{pessoa.Nome}.json");
		Console.Write("Digite uma Idade: ");
		var idade = int.Parse(Console.ReadLine()!);
        Console.WriteLine($"Pessoas com {idade} Anos");
		LinqFilter.FiltrarPorIdade(nomeDoArquivo, idade);
	}
	catch (Exception ex)
	{
        Console.WriteLine($"O seguinte erro ocorreu: {ex}");
	}
}

//public  void GerarJsonPessoas(List<Pessoa> pessoas)
//{
//    var json = JsonSerializer.Serialize(pessoas);
//    string nomeDoArquivo = $"info_Pessoas.json";
//    File.WriteAllText(nomeDoArquivo, json);
//    Console.WriteLine($"Arquivo Gerado. Caminho: {Path.GetFullPath(nomeDoArquivo)}");
//}
//public static void LerJsonPessoas(string nomeDoArquivo)
//{
//    var arquivo = File.ReadAllText(nomeDoArquivo);
//    var jsonPessoa = JsonSerializer.Deserialize<List<Pessoa>>(arquivo);
//    foreach (var pessoa in jsonPessoa)
//    {
//        pessoa.ExibirInfo();
//    }
//}