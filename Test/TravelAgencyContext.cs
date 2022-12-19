using Microsoft.EntityFrameworkCore;
using TravelAgency;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace TravelAgencyApp
{
    public class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext()
        {
            Database.EnsureCreated();
        }

        public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Server=TravelAgency;Database=master;User=sa;Password=TestPassword123;TrustServerCertificate=True");
        }

        public DbSet<Countrie> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<TravelType> TravelTypes { get; set; }
        public DbSet<Offer> Offers { get; set; }

    
    }
}
