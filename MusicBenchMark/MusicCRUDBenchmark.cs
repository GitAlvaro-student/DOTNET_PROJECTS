using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using Microsoft.Diagnostics.Tracing.StackSources;
using Microsoft.EntityFrameworkCore;
using MusicSoundAPI.ApplicationDbContext;
using MusicSoundAPI.Data.Dtos;
using MusicSoundAPI.Models;
using MusicSoundAPI.Repository.Music;
using MusicSoundAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBenchMark
{
    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net80)]
    public class MusicCRUDBenchmark
    {
        private ModelContext _context = null!;
        private TbdSong _song = null!;
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;
        private readonly Consumer _consumer = new();


        public MusicCRUDBenchmark(IMusicService musicService, IMapper mapper)
        {
            _musicService = musicService;
            _mapper = mapper;
        }

        [GlobalSetup]
        public void Setup()
        {
            _context = new ModelContext();
            _context.Database.EnsureCreated();
            _song = new TbdSong
            {
                IdMusic = 2,
                Musica = "Just The Way You Are",
                Popularidade = 97,
                Duracao = 134,
                Ano = 2018,
                IdArtist = 1,
                IdArtistNavigation = null
            };
        }
        [Benchmark]
        public void Create()
        {
            var song = new CreateMusicDTO
            {
                Musica = "Benchmark song",
                Popularidade = 50,
                Duracao = 184,
                Ano = 2020,
                IdArtist = 1,
            };

            _musicService.InsertMusic(song);
        }

        [Benchmark]
        public void ReadAll()
        {
            var query = _context.TbdSongs.AsNoTracking().
                Select(s => new ReadMusicDTO { });
            var songs = _musicService.GetMusics();

            _consumer.Consume(query);
            //return (IEnumerable<ReadMusicDTO>)songs;
        }

        [Benchmark]
        public void Update()
        {
            var music = _song;
            var song = _context.TbdSongs.First(s => s.IdMusic == _song.IdMusic);
            song.Popularidade += 2;
            var newSong = _mapper.Map<UpdateMusicDTO>(song);

            _musicService.UpdateMusic(music, newSong);
        }

        [Benchmark]
        public void Delete()
        {
            var song = new CreateMusicDTO
            {
                Musica = "Temp Song",
                Popularidade = 10,
                Duracao = 100,
                Ano = 2019,
                IdArtist = 1
            };
            //var music = _mapper.Map<TbdSong>(song);
            _musicService.InsertMusic(song);

            var music = _mapper.Map<TbdSong>(song);

            _musicService.DeleteMusic(music);
        }

        [GlobalCleanup]
        public void CleanUp()
        {
            _context.Dispose();
        }
    }
}
