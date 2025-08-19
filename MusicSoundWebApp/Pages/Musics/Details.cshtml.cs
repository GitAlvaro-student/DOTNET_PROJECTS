using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicSoundWebApp.Data;
using MusicSoundWebApp.Models;

namespace MusicSoundWebApp.Pages.Musics
{
    public class DetailsModel : PageModel
    {
        private readonly MusicSoundWebApp.Data.ModelContext _context;

        public DetailsModel(MusicSoundWebApp.Data.ModelContext context)
        {
            _context = context;
        }

        public TbdSong TbdSong { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbdsong = await _context.TbdSongs.FirstOrDefaultAsync(m => m.IdMusic == id);
            if (tbdsong == null)
            {
                return NotFound();
            }
            else
            {
                TbdSong = tbdsong;
            }
            return Page();
        }
    }
}
