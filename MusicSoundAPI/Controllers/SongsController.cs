using Microsoft.AspNetCore.Mvc;
using MusicSoundAPIStandard.Interfaces;
using MusicSoundAPIStandard.Models;

namespace MusicSoundAPI.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    //public class SongsController : ControllerBase
    //{
    //    private readonly ISongRepository _repository;

    //    public SongsController(ISongRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    [HttpGet]
    //    public ActionResult<IEnumerable<Song>> GetAll() => _repository.GetAll();

    //    [HttpGet("{id}")]
    //    public ActionResult<Song> Get(int id)
    //    {
    //        var song = _repository.GetById(id);
    //        return song == null ? NotFound() : Ok(song);
    //    }

    //    [HttpPost]
    //    public IActionResult Post(Song song)
    //    {
    //        _repository.Create(song);
    //        return CreatedAtAction(nameof(Get), new { id = song.Id }, song);
    //    }


    //    [HttpPut("{id}")]
    //    public IActionResult Put(int id, Song song)
    //    {
    //        if (id != song.Id)
    //            return BadRequest();

    //        _repository.Update(song);
    //        return NoContent();
    //    }

    //    [HttpDelete("{id}")]
    //    public IActionResult Delete(int id)
    //    {
    //        _repository.Delete(id);
    //        return NoContent();
    //    }
    //}
}
