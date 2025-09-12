using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicSoundAPI.Data.Dtos.Artist;
using MusicSoundAPI.Models;
using MusicSoundAPI.Services.Artist;

namespace MusicSoundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly ILogger<ArtistController> _logger;

        public ArtistController(IArtistService artistService, ILogger<ArtistController> logger)
        {
            _artistService = artistService;
            _logger = logger;
        }

        /// <summary>
        /// Mostra informações de um Artista de acordo com o Id
        /// </summary>
        /// <param name="idArtist">Id do Artista a ser Mostrado</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a requisição seja feita com sucesso</response>
        [HttpGet("{idArtist}")]
        public async Task<IActionResult> GetArtistById(int idArtist)
        {
            var artist = await _artistService.GetArtistById(idArtist);
            _logger.LogInformation($"Buscando Artista pelo Id {idArtist}");

            if (artist == null)
            {
                _logger.LogInformation($"Artista de Id {idArtist} nâo encontrado");
                return NotFound("Artista Não Encontrado!!");
            }

            return Ok(artist);
        }

        /// <summary>
        /// Mostra informações de uma lista de Artistas
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a requisição seja feita com sucesso</response>
        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            var artist = await _artistService.GetArtists();
            var artistCount = artist.Count();

            if (artist == null)
            {
                return NotFound("Artista Não Encontrado!!");
            }

            return Ok(new
            {
                Mensagem = $"{artistCount} Artistas Registrados",
                Dados = artist.OrderBy(m => m.Artista).Take(10)
            });
        }

        /// <summary>
        /// Insere informações de um Artista no Banco de Dados
        /// </summary>
        /// <param name="artist">Objeto necessário para inserir uma Artista</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [Route("RegisterArtist")]
        [HttpPost]
        public async Task<ActionResult<TbdArtist>> PostArtist(CreateArtistDTO artist)
        {
            _logger.LogInformation($"Executando Método {HttpContext.Request.PathBase}");
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"Dados Inválidos Enviados" +
                        $"{artist}");
                    return BadRequest(ModelState);
                }

                await _artistService.PostArtist(artist);
                return CreatedAtAction(nameof(GetAllArtists), new { name = artist.Artista }, artist);

            }
            catch (Exception ex)
            {
                _logger.LogError($"O seguinte erro ocorreu {ex.Message}");
                return BadRequest();
            }

        }

        /// <summary>
        /// Atualiza informações de um Artista no Banco de Dados de acordo com o Id
        /// </summary>
        /// <param name="id">Id do Artista a ser atualizado</param>
        /// <param name="artist">Objeto necessário para atualizar um Artista</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso Atualização seja feita com sucesso</response>
        [HttpPut("UpdateArtist")]
        public async Task<IActionResult> PutArtist(int id, UpdateArtistDTO artist)
        {
            var music = await _artistService.GetTbdArtistById(id);

            if (music == null)
            {
                return NotFound("Artista Não Encontrado!!");
            }

            await _artistService.PutArtist(music, artist);
            return StatusCode(201, artist);
        }

        /// <summary>
        /// Deleta informações de um Artista no Banco de Dados de acordo com o Id
        /// </summary>
        /// <param name="id">Id do Artista a ser Deletado</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a Remoção seja feita com sucesso</response>
        [HttpDelete("DeleteArtist")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _artistService.GetTbdArtistById(id);
            if (artist == null)
                return NotFound("Artista Nao Encontrado");

            await _artistService.DeleteArtist(artist);
            return Ok(new
            {
                Mensagem = $"Artista de Id {id} Apagado!"
            });
        }
    }
}
