using Microsoft.AspNetCore.Mvc;
using MusicSoundAPI.ApplicationDbContext;
using MusicSoundAPI.Models;
using MusicSoundAPI.Repository.Artist;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicSoundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistsController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        /// <summary>
        /// Mostra informações de um Artista de acordo com o Id
        /// </summary>
        /// <param name="id">Id do Artista a ser Mostrado</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a requisição seja feita com sucesso</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<TbdArtist>> GetArtistById(int id)
        {
            var artist = await _artistRepository.GetArtistById(id);

            if (artist == null)
            {
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
        public async Task<ActionResult<IEnumerable<TbdArtist>>> GetAllArtists()
        {
            var artist = await _artistRepository.GetArtists();
            var artistCount = artist.Count();

            if (artist == null)
            {
                return NotFound("Artista Não Encontrado!!");
            }

            return Ok(new
            {
                Mensagem = $"{artistCount} Artistas Registrados",
                Dados = artist.OrderBy(m => m.IdArtist).Take(10)
            });
        }

        /// <summary>
        /// Insere informações de um Artista no Banco de Dados
        /// </summary>
        /// <param name="artist">Objeto necessário para inserir uma Artista</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [Route("api/[controller]/music")]
        [HttpPost]
        public async Task<ActionResult<TbdArtist>> PostArtist(TbdArtist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _artistRepository.InsertArtist(artist);
            return CreatedAtAction(nameof(GetAllArtists), new { id = artist.IdArtist }, artist);

        }

        /// <summary>
        /// Atualiza informações de um Artista no Banco de Dados de acordo com o Id
        /// </summary>
        /// <param name="id">Id do Artista a ser atualizado</param>
        /// <param name="artist">Objeto necessário para atualizar um Artista</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso Atualização seja feita com sucesso</response>
        [HttpPut]
        public async Task<ActionResult<TbdArtist>> PutArtist(int id, TbdArtist artist)
        {
            var music = await _artistRepository.GetArtistById(id);

            if (music == null)
            {
                return NotFound("Artista Não Encontrado!!");
            }

            await _artistRepository.UpdateArtist(music, artist);
            return StatusCode(201, artist);
        }

        /// <summary>
        /// Deleta informações de um Artista no Banco de Dados de acordo com o Id
        /// </summary>
        /// <param name="id">Id do Artista a ser Deletado</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a Remoção seja feita com sucesso</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _artistRepository.DeleteArtist(id);
            return Ok(new
            {
                Mensagem = $"Artista de Id {id} Apagado!"
            });
        }
    }
}
