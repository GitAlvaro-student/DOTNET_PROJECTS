// Program.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Musicas_Oracle.Context;
using Musicas_Oracle.Repositories;
using Musicas_Oracle.Models;
using System.Text.Json;

var builder = Host.CreateApplicationBuilder(args);

// Configuração
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

// Entity Framework
builder.Services.AddDbContext<ModelContext>();

// Serviços
builder.Services.AddScoped<ITbdSongsRepository, TbdSongsRepository>();

var app = builder.Build();



// Exemplo de uso
var musicImportService = app.Services.GetRequiredService<ITbdSongsRepository>();
var logger = app.Services.GetRequiredService<ILogger<Program>>();

try
{
    // JSON de exemplo - em produção você carregaria de um arquivo ou API
    using (HttpClient client = new HttpClient())
    {
        string jsonMusicas = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        await musicImportService.InserirMusicasFromJsonAsync(jsonMusicas);
        logger.LogInformation("Importação concluída com sucesso!");

    };
}
catch (Exception ex)
{
    logger.LogError(ex, "Erro durante a importação das músicas");
}
