using Microsoft.EntityFrameworkCore;
using ToggleApp.Domain.Entities;

namespace ToggleApp.Data.Context
{
    public class ToggleAppDbContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Toggle> Toggles { get; set; }

        public ToggleAppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().Property(a => a.Name).IsRequired();
            modelBuilder.Entity<Toggle>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<Toggle>().Property(t => t.Enable).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
