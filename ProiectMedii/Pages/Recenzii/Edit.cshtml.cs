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

namespace ProiectMedii.Pages.Recenzii
{
    [Authorize(Roles = "Admin")]

    public class EditModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public EditModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recenzie Recenzie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recenzie == null)
            {
                return NotFound();
            }

            var recenzie =  await _context.Recenzie.FirstOrDefaultAsync(m => m.ID == id);
            if (recenzie == null)
            {
                return NotFound();
            }
            Recenzie = recenzie;
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Recenzie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecenzieExists(Recenzie.ID))
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

        private bool RecenzieExists(int id)
        {
          return (_context.Recenzie?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
