using FailureLogging.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MusicSoundAPI.ApplicationDbContext;
using MusicSoundAPI.Middleware;
using MusicSoundAPI.Profiles;
using MusicSoundAPI.Repository.Artist;
using MusicSoundAPI.Repository.Music;
using MusicSoundAPI.Repository.Playlist;
using MusicSoundAPI.Services.Artist;
using MusicSoundAPI.Services.Azure;
using MusicSoundAPI.Services.Music;
using MusicSoundAPI.Services.Playlist;
using MusicSoundAPIStandard.Interfaces;
using MusicSoundAPIStandard.Repository;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Configurar Serilog
builder.Host.UseSerilog((context, configuration) =>
{
    configuration.WriteTo.Console()
        .WriteTo.File("logs/app-.txt", rollingInterval: RollingInterval.Day);
});

var connectionString = builder.Configuration.GetConnectionString("DEV");
builder.Services.AddDbContext<ModelContext>(options => options.UseOracle(connectionString));

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(MusicProfile));
builder.Services.AddAutoMapper(typeof(ArtistProfile));

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(
    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MusicSoundAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddSingleton<IAzureLogService, AzureLogService>();
builder.Services.AddScoped<IMusicService, MusicService>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IMusicRepository, MusicRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
builder.Services.AddScoped<IPlaylistService, PlaylistService>();
builder.Services.AddScoped<ISongRepository>(provider => new SongRepository(builder.Configuration.GetConnectionString("DEV")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Logging.ClearProviders();
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration()
{
    LogLevel = LogLevel.Information
}));

var app = builder.Build();

app.UseMiddleware<LoggingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
