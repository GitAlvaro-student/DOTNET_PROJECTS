using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicSoundWebApp.Data;
using MusicSoundWebApp.Models;

namespace MusicSoundWebApp.Pages.Musics
{
    public class CreateModel : PageModel
    {
        private readonly MusicSoundWebApp.Data.ModelContext _context;

        public CreateModel(MusicSoundWebApp.Data.ModelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TbdSong TbdSong { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TbdSongs.Add(TbdSong);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
