using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VGListRazor.Model;

namespace VGListRazor.Pages.VGList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel (ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Game Game {get; set;}
        public async Task OnGet(int id)
        {
            Game = await _db.Game.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var GameFromDb = await _db.Game.FindAsync(Game.id);
                GameFromDb.Name = Game.Name;
                GameFromDb.platform = Game.platform;
                GameFromDb.publisher = Game.publisher;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}