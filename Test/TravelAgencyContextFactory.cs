using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TravelAgencyApp;

namespace TravelAgencyApi
{
    public class TravelAgencyContextFactory : IDesignTimeDbContextFactory<TravelAgencyContext>
    {

        public TravelAgencyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TravelAgencyContext>();

            // получаем конфигурацию из файла appsettings.json
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            // получаем строку подключения из файла appsettings.json
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
            return new TravelAgencyContext(optionsBuilder.Options);
        }
    }
}
