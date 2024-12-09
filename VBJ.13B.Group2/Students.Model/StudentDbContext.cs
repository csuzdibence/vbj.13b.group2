using Microsoft.EntityFrameworkCore;

namespace Students.Model
{
    public class StudentDbContext : DbContext
    {
        // ez egy adatbázis táblát jelöl
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Ha még nem volt konfigurálva az adatbázis
            if (!optionsBuilder.IsConfigured)
            {
                // akkor állítsuk be a connection stringet -> csatlakozás
                // (localdb)\\MSSQLLocalDB -> beépített Visual Studio lokál MSSQL server
                // StudentsDatabase -> adatbázis neve
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StudentsDatabase");
            }
        }
    }
}
