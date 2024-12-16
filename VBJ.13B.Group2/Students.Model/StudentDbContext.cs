using Microsoft.EntityFrameworkCore;

namespace Students.Model
{
    public class StudentDbContext : DbContext
    {
        // ez egy adatbázis táblát jelöl
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1-N kapcsolatnál ide jön az 1-nél lévő
            // Kapcsoaltot fogunk definiálni a tanár táblán
            modelBuilder.Entity<Teacher>()
                // Egy tanárnak, lehet több diákja
                .HasMany(teacher => teacher.Students)
                // Egy diáknak pontosan egy tanára lehet
                .WithOne(student => student.Teacher)
                // Összekötés az idegen kulcson
                .HasForeignKey(student => student.TeacherId)
                // Kötelező megadni
                .IsRequired();
        }

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
