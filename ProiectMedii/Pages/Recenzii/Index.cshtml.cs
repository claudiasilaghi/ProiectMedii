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
    public class IndexModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public IndexModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IList<Recenzie> Recenzie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Recenzie != null)
            {
                Recenzie = await _context.Recenzie
                    .Include(b => b.Restaurant)
                    .ThenInclude(b => b.Adresa)
                    .ToListAsync();
            }
        }
    }
}
