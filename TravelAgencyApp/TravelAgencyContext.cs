using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using TravelAgency;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace TravelAgencyApp
{
    public class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options) 
            : base(options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-1SJSHK2\\MSSQLSERVER_2;Database=TravelAgency;Trusted_Connection=True;");
        }

        Microsoft.EntityFrameworkCore.DbSet<Countrie> Countries { get; set; }
        Microsoft.EntityFrameworkCore.DbSet<Hotel> Hotels { get; set; }
        Microsoft.EntityFrameworkCore.DbSet<TravelType> TravelTypes { get; set; }
    }
}
