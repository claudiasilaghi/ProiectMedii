using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Recenzii
{
    public class DetailsModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public DetailsModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

      public Recenzie Recenzie { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recenzie == null)
            {
                return NotFound();
            }

            var recenzie = await _context.Recenzie
                .Include(i => i.Restaurant)
                .ThenInclude(i => i.Adresa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recenzie == null)
            {
                return NotFound();
            }
            else 
            {
                Recenzie = recenzie;
            }
            return Page();
        }
    }
}
