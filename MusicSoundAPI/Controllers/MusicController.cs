using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MusicSoundAPI.Data.Dtos.Music;
using MusicSoundAPI.Models;
using MusicSoundAPI.Services.Music;
using Newtonsoft.Json;
using Serilog;

namespace MusicSoundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;


        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        /// <summary>
        /// Mostra informações de uma Música de acordo com o Id
        /// </summary>
        /// <param name="idMusic">Id da Música a ser Mostrada</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a requisição seja feita com sucesso</response>
        [HttpGet("byMusicId")]
        public async Task<IActionResult> GetMusicById(int idMusic)
        {
            var song = await _musicService.GetMusicById(idMusic);

            var log = SetLog(LogLevel.Information.ToString(), "Sucesso!", "GetMusicById", idMusic);
            Log.Information(log);

            return Ok(song);
        }

        /// <summary>
        /// Mostra informações de uma lista de Músicas
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a requisição seja feita com sucesso</response>
        [HttpGet("AllMusics")]
        public async Task<IActionResult> GetAllMusics()
        {
            var song = await _musicService.GetMusics();

            var log = SetLog(LogLevel.Information.ToString(), "Sucesso!", "GetAllMusics");
            Log.Information(log);

            return Ok(song);
        }

        /// <summary>
        /// Insere informações de uma Música no Banco de Dados
        /// </summary>
        /// <param name="music">Objeto necessário para inserir uma Música</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost("RegisterMusic")]
        public async Task<IActionResult> PostMusic(CreateMusicDTO music)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _musicService.InsertMusic(music);

            var log = SetLog(LogLevel.Information.ToString(), "Sucesso!", "PostMusic", music);
            Log.Information(log);

            return CreatedAtAction(nameof(PostMusic), music);

        }

        /// <summary>
        /// Atualiza informações de uma Música no Banco de Dados de acordo com o Id
        /// </summary>
        /// <param name="id">Id da Música a ser atualizada</param>
        /// <param name="music">Objeto necessário para atualizar uma Música</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso Atualização seja feita com sucesso</response>
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

        /// <summary>
        /// Deleta informações de uma Música no Banco de Dados de acordo com o Id
        /// </summary>
        /// <param name="idMusic">Id da Música a ser Deletada</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a Remoção seja feita com sucesso</response>
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

        private string SetLog(string level, string message, string source, object parameters = null)
        {
            HttpContext.Items["Message"] = $"{HttpContext.Request.Method} {HttpContext.Request.Path} responded {HttpContext.Response.StatusCode}";
            HttpContext.Items["Source"] = source;
            HttpContext.Items["Properties"] = new Dictionary<string, object>()
            {
                {"Properties", parameters }
            };
            var dict = new Dictionary<string, object>();
            dict.Add("Properties", parameters);

            var log = new LogEntry
            {
                Timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                Level = level,
                Message = message,
                Source = source,
                Properties = dict
            };

            var newLog = JsonConvert.SerializeObject(log);

            return newLog;
        }
    }
}
