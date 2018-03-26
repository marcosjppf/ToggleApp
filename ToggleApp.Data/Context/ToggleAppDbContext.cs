using Microsoft.EntityFrameworkCore;
using ToggleApp.Domain.Entities;
using ToggleApp.Data.Configurations;

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
            modelBuilder.ApplyConfiguration(new ApplicationEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
