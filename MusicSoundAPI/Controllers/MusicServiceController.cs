using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MusicSoundAPI.Data.Dtos;
using MusicSoundAPI.Models;
using MusicSoundAPI.Services;

namespace MusicSoundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicServiceController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicServiceController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpGet("byMusicId")]
        public async Task<IActionResult> GetMusicById(int idMusic)
        {
            var song = await _musicService.GetMusicById(idMusic);
            return Ok(song);
        }

        [HttpGet("AllMusics")]
        public async Task<IActionResult> GetAllMusics()
        {
            var song = await _musicService.GetMusics();
            return Ok(song);
        }

        [HttpPost("RegisterMusic")]
        public async Task<IActionResult> PostMusic(CreateMusicDTO music)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _musicService.InsertMusic(music);
            return CreatedAtAction(nameof(PostMusic), music);

        }

        [HttpPut("UpdateMusic")]
        public async Task<IActionResult> UpdateMusic(int id, UpdateMusicDTO music)
        {
            var song = await _musicService.GetTbdSongById(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (song == null)
            {
                return NotFound("Musica Não Encontrada!!");
            }

            await _musicService.UpdateMusic(song, music);
            return StatusCode(201, music);
        }

        [HttpDelete("DeleteMusic")]
        public async Task<IActionResult> DeleteMusic(int idMusic)
        {
            var song = await _musicService.GetTbdSongById(idMusic);

            if (song == null)
            {
                return NotFound("Musica Não Encontrada!!");
            }

            await _musicService.DeleteMusic(song);
            return Content("Musica Deletada!!");
        }
    }
}
