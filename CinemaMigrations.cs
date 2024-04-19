using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SinemaSinema.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20220420000000_InitialCreate")]
    public class CinemaMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Buraya ilk migration kodlarýný ekleyin
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Buraya geri alma kodlarýný ekleyin
        }
    }

    public class CinemaDbContextFactory : IDesignTimeDbContextFactory<CinemaDbContext>
    {
        public CinemaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CinemaDbContext>();
            optionsBuilder.UseSqlite("Data Source=cinema.db");

            return new CinemaDbContext(optionsBuilder.Options);
        }
    }
}