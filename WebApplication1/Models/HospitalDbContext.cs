using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using System.Data.SQLite;
using Microsoft.Extensions.Options;


namespace WebApplication1.Models
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        // Diğer DbSet'ler ve konfigürasyonlar buraya eklenebilir.

        //var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HospitalDbContext>(options =>
            {
                // Configure connection string and other options here
                // options.UseSqlite("Data Source=C:\\Users\\Administrator\\Desktop\\hastane.sqbpro");
                options.UseSqlite("Data Source = C:\\Program Files\\SQLiteStudio\\hastane.db;Version=3;");
            });
            // ... other service registrations
        }


    }
}
