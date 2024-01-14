using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Models;

namespace ProiectMedii.Data
{
    public class ProiectMediiContext : DbContext
    {
        public ProiectMediiContext (DbContextOptions<ProiectMediiContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectMedii.Models.Adresa> Adresa { get; set; } = default!;

        public DbSet<ProiectMedii.Models.Membru>? Membru { get; set; }

        public DbSet<ProiectMedii.Models.Recenzie>? Recenzie { get; set; }

        public DbSet<ProiectMedii.Models.Restaurant>? Restaurant { get; set; }

        public DbSet<ProiectMedii.Models.Rezervare>? Rezervare { get; set; }
    }
}
