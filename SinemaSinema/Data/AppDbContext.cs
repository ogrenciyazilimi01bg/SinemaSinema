using Microsoft.EntityFrameworkCore;
using SinemaSinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaSinema.Data
{

    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= ..\\..\\Data\\SinemaSinemaDb.db");
        }

        public DbSet<Film> Film { get; set; }
        public DbSet<Salon> Salon { get; set; }
        public DbSet<Seans> Seans { get; set; }
        public DbSet<BiletBilgi> BiletBilgi { get; set; }
       
    }
    
}
