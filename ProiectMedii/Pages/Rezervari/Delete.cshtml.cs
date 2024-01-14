using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Rezervari
{
    [Authorize(Roles = "Admin")]

    public class DeleteModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public DeleteModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Rezervare Rezervare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rezervare == null)
            {
                return NotFound();
            }

            var rezervare = await _context.Rezervare
                .Include(i => i.Adresa)
                .Include(i => i.Restaurant)
                .Include(i => i.Membru)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (rezervare == null)
            {
                return NotFound();
            }
            else 
            {
                Rezervare = rezervare;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Rezervare == null)
            {
                return NotFound();
            }
            var rezervare = await _context.Rezervare.FindAsync(id);

            if (rezervare != null)
            {
                Rezervare = rezervare;
                _context.Rezervare.Remove(Rezervare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
