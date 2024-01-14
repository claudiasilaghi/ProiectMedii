using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Recenzii
{
    public class CreateModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public CreateModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var tott = _context.Restaurant
               .Include(b => b.Adresa)

               .Select(x => new
               {
                   x.ID,
                   tot = x.Nume + " din " + x.Adresa.Strada + " " + x.Adresa.Numar + ", " + x.Adresa.Oras + ", " + x.Adresa.Judet
               });
            ViewData["RestaurantID"] = new SelectList(tott, "ID", "tot");
            return Page();
        }

        [BindProperty]
        public Recenzie Recenzie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Recenzie == null || Recenzie == null)
            {
                return Page();
            }

            _context.Recenzie.Add(Recenzie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
