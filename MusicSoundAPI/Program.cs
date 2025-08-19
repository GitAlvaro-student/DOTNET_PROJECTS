using Microsoft.EntityFrameworkCore;
using MusicSoundAPI.ApplicationDbContext;
using MusicSoundAPI.Repository;
using Microsoft.OpenApi.Models;
using MusicSoundAPIStandard.Repository;
using MusicSoundAPIStandard.Interfaces;
using System.Reflection;
using MusicSoundAPI.Repository.Music;
using MusicSoundAPI.Repository.Artist;
using MusicSoundAPI.Profiles;
using MusicSoundAPI.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DEV");
builder.Services.AddDbContext<ModelContext>(options => options.UseOracle(connectionString));

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(MusicProfile));

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



builder.Services.AddScoped<IMusicRepository, MusicRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IMusicService, MusicService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ISongRepository>(provider => new SongRepository(builder.Configuration.GetConnectionString("DEV")));

var app = builder.Build();

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
