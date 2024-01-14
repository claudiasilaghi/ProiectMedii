using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Adrese
{

    public class DeleteModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public DeleteModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Adresa Adresa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Adresa == null)
            {
                return NotFound();
            }

            var adresa = await _context.Adresa.FirstOrDefaultAsync(m => m.ID == id);

            if (adresa == null)
            {
                return NotFound();
            }
            else 
            {
                Adresa = adresa;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Adresa == null)
            {
                return NotFound();
            }
            var adresa = await _context.Adresa.FindAsync(id);

            if (adresa != null)
            {
                Adresa = adresa;
                _context.Adresa.Remove(Adresa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
