using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            // appsettings.json dosyasını yükle
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(currentDirectory).FullName + "/ScrumPoker.WebApi") // Geçerli dizin
                .AddJsonFile("appsettings.json") // appsettings.json dosyasını ekle
                .Build();

            // ConnectionString'i al
            var connectionString = config.GetConnectionString("DefaultConnection");

            // DbContextOptions'u oluştur
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
