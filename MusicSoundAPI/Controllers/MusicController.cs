using Microsoft.AspNetCore.Mvc;
using MusicSoundAPI.Models;
using MusicSoundAPI.Repository.Artist;
using MusicSoundAPI.Repository.Music;
using MusicSoundAPI.Services;
using MusicSoundAPIStandard.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicSoundAPI.Controllers
{
    /// <summary>
    /// Controla as Requisições para Músicas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicRepository _musicRepository;
        private readonly IArtistRepository _artistRepository;

        public MusicController(IMusicRepository musicRepository, IArtistRepository artistRepository)
        {
            _musicRepository = musicRepository;
            _artistRepository = artistRepository;
        }

        /// <summary>
        /// <summary>
        /// Mostra informações de uma Música de acordo com o Id
        /// </summary>
        /// <param name="id">Id da Música a ser Mostrada</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a requisição seja feita com sucesso</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<TbdSong>> GetMusicById(int id)
        {
            var music = await _musicRepository.GetMusicById(id);

            if (music == null)
            {
                return NotFound("Musica Não Encontrada!!");
            }

            return Ok(music);
        }


        [HttpGet]
        [Route("Artist")]
        public async Task<ActionResult<TbdSong>> GetArtistMusicsById(int idArtist)
        {
            var music = await _musicRepository.GetMusicsByArtist(idArtist);

            if (music == null)
            {
                return NotFound("Musicas Não Encontradas!!");
            }

            return Ok(music);
        }

        [HttpGet]
        [Route("ArtistName")]
        public async Task<ActionResult<TbdSong>> GetArtistMusicsByName(string artistName)
        {
            var idArtist =  _artistRepository.GetIdArtistByName(artistName);

            if (idArtist == 0)
                return NotFound("Artista Não Encontrado!!");

            var music = await _musicRepository.GetMusicsByArtist(idArtist);

            if (music == null)
                return NotFound("Musicas Não Encontradas!!");


            return Ok(music);
        }

        /// <summary>
        /// Mostra informações de uma lista de Músicas
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a requisição seja feita com sucesso</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbdSong>>> GetAllMusics()
        {
            var musics = await _musicRepository.GetMusics();
            var musicCount = musics.Count();

            if (musics == null)
            {
                return NotFound("Musica Não Encontrada!!");
            }

            return Ok(new
            {
                Mensagem = $"{musicCount} Musicas Registradas",
                Dados = musics.OrderBy(m => m.IdMusic).Take(10)
            });
        }

        /// <summary>
        /// Insere informações de uma Música no Banco de Dados
        /// </summary>
        /// <param name="music">Objeto necessário para inserir uma Música</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        public async Task<ActionResult<TbdSong>> PostMusic(TbdSong music)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _musicRepository.InsertMusic(music);
            return CreatedAtAction(nameof(GetAllMusics), new { id = music.IdMusic }, music);

        }

        /// <summary>
        /// Atualiza informações de uma Música no Banco de Dados de acordo com o Id
        /// </summary>
        /// <param name="id">Id da Música a ser atualizada</param>
        /// <param name="song">Objeto necessário para atualizar uma Música</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso Atualização seja feita com sucesso</response>
        [HttpPut]
        public async Task<ActionResult<TbdSong>> PutMusic(int id, TbdSong song)
        {
            var music = await _musicRepository.GetMusicById(id);

            if (music == null)
            {
                return NotFound("Musica Não Encontrada!!");
            }

            await _musicRepository.UpdateMusic(music, song);
            return StatusCode(201, music);
        }

        /// <summary>
        /// Deleta informações de uma Música no Banco de Dados de acordo com o Id
        /// </summary>
        /// <param name="id">Id da Música a ser Deletada</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a Remoção seja feita com sucesso</response>
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await _musicRepository.DeleteMusic(id);
        //    return Ok(new
        //    {
        //        Mensagem = $"Musica de {id} Apagada!"
        //    });
        //}
    }
}
