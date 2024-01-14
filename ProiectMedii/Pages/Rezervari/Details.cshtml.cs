using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Rezervari
{
    public class DetailsModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public DetailsModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

      public Rezervare Rezervare { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rezervare == null)
            {
                return NotFound();
            }

            var rezervare = await _context.Rezervare
                 .Include(i => i.Restaurant)
                .ThenInclude(b => b.Adresa)
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
    }
}
