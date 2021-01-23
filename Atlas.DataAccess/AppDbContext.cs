using Atlas.Domain.Entities;
using Atlas.Infrastructure.Abstraction.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Atlas.DataAccess
{
    internal class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<RacingClass> Measures { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RacingClass>().HasData(new RacingClass { Id = 1, Name = "PROD-32" });
            modelBuilder.Entity<RacingClass>().HasData(new RacingClass { Id = 2, Name = "PROD-24" });
            modelBuilder.Entity<RacingClass>().HasData(new RacingClass { Id = 3, Name = "ES-24U", Description = "Чайник" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
