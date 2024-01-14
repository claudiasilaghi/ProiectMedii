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
    public class IndexModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public IndexModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IList<Rezervare> Rezervare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rezervare != null)
            {
                Rezervare = await _context.Rezervare
                    .Include(b => b.Restaurant)
                      .ThenInclude(b => b.Adresa)
                    .Include(b => b.Membru).ToListAsync();
            }
        }
    }
}
