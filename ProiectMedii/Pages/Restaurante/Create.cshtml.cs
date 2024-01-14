using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Restaurante
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public CreateModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var str = _context.Adresa
               .Select(x => new
               {
                   x.ID,
                   strnr = x.Strada + " "+ x.Numar
               });
            var oras = _context.Adresa
               .Select(x => new
               {
                   x.ID,
                   orasjud = x.Oras + ", " + x.Judet
               });
            ViewData["StradaNr"] = new SelectList(str, "ID", "strnr");
            ViewData["OrasJudet"] = new SelectList(oras, "ID", "orasjud");
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Restaurant == null || Restaurant == null)
            {
                return Page();
            }

            _context.Restaurant.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
