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
    public class IndexModel : PageModel
    {
        private readonly MusicSoundWebApp.Data.ModelContext _context;

        public IndexModel(MusicSoundWebApp.Data.ModelContext context)
        {
            _context = context;
        }

        public IList<TbdSong> TbdSong { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TbdSong = await _context.TbdSongs
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
