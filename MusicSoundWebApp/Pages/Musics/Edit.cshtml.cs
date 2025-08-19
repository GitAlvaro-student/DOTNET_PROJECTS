using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicSoundWebApp.Data;
using MusicSoundWebApp.Models;

namespace MusicSoundWebApp.Pages.Musics
{
    public class EditModel : PageModel
    {
        private readonly MusicSoundWebApp.Data.ModelContext _context;

        public EditModel(MusicSoundWebApp.Data.ModelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TbdSong TbdSong { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbdsong =  await _context.TbdSongs.FirstOrDefaultAsync(m => m.IdMusic == id);
            if (tbdsong == null)
            {
                return NotFound();
            }
            TbdSong = tbdsong;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TbdSong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbdSongExists(TbdSong.IdMusic))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TbdSongExists(decimal id)
        {
            return _context.TbdSongs.Any(e => e.IdMusic == id);
        }
    }
}
