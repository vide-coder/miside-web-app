using Microsoft.EntityFrameworkCore;
using MiSide.Models;

namespace MiSide.Domain
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<GameCharacter> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameCharacter>().HasKey(x => x.Id);
            modelBuilder.Entity<GameCharacter>().Property(x => x.Name);
            modelBuilder.Entity<GameCharacter>().Property(x => x.Description);
            base.OnModelCreating(modelBuilder);
        }
    }
}
