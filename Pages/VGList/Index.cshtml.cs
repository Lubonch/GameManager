using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VGListRazor.Model;

namespace VGListRazor.Pages.VGList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Game> Games {get; set;}

        public async Task OnGet()
        {
            Games = await _db.Game.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
                var game = await _db.Game.FindAsync(id);

                if(game == null)
                {
                    return NotFound();
                }
                _db.Game.Remove(game);
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
        }
    }
}