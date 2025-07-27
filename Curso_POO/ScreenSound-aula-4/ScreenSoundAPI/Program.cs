using System.Text.Json;
using ScreenSoundAPI.Models;
using ScreenSoundAPI.Filtros;
using (HttpClient client = new HttpClient())
{
	try
	{
		string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
		var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
		//Console.WriteLine(resposta);

		//LinqFilter.FiltrarGeneros(musicas);
		//LinqOrderBy.OrdenarArtistas(musicas);
		//LinqFilter.FiltrarArtistasPorGenero(musicas, "hip hop");
		//var listaMusicas = LinqFilter.FiltrarMusicasPorArtista(musicas, "Bruno Mars");
		//LinqFilter.FiltrarMusicasPorAno(musicas, 2018);
		//var musicasPreferidas = new Preferidas("Alvaro");
		//foreach (var musica in listaMusicas)
		//{
		//	musicasPreferidas.AddMusic(musica);
		//}
		//musicasPreferidas.ExibirMusicasFavoritas();
		//musicasPreferidas.GerarArquivoJson();
		var tom = new LinqFilter().EscolherTonalidade();
		LinqFilter.FiltrarPelaTonalidade(musicas, tom);
    }
	catch (Exception ex)
	{
		Console.WriteLine($"O seguinte erro ocorreu: {ex.Message}");
	}
}


