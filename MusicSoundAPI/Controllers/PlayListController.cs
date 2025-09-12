using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicSoundAPI.Data.Dtos.PlayList;
using MusicSoundAPI.Repository.Playlist;
using MusicSoundAPI.Services.Playlist;
using System.Diagnostics.Contracts;

namespace MusicSoundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlayListController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet("PlaylistById")]
        public async Task<IActionResult> GetPlaylistById(int id)
        {
            var playlist = await _playlistService.GetPlaylistById(id);
            return Ok(playlist);
        }

        [HttpGet("AllPlaylists")]
        public async Task<IActionResult> GetAllPlaylists()
        {
            var playlists = await _playlistService.GetPlayLists();
            return Ok(playlists);
        }

        [HttpPost("InsertPlaylist")]
        public async Task<IActionResult> PostPlaylist(CreatePlaylistDTO playlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _playlistService.InsertPlaylist(playlist);
            return CreatedAtAction(nameof(PostPlaylist), playlist);
        }
    }
}
