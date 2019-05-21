using Microsoft.EntityFrameworkCore;

namespace lab4.model
{
    public class Context : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Project> Projects { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=dotnetdatabase;User Id=postgres;Password=postgres");
        }
    }
}