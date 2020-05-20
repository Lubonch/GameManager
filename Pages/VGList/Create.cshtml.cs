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
    public class CreateModel : PageModel
    {   
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]//
        public Game Game{get; set;}
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                    await _db.Game.AddAsync(Game);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}