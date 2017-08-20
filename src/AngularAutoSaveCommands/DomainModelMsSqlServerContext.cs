using AngularAutoSaveCommands.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularAutoSaveCommands
{
    // >dotnet ef migration add testMigration
    public class DomainModelMsSqlServerContext : DbContext
    {
        public DomainModelMsSqlServerContext(DbContextOptions<DomainModelMsSqlServerContext> options) : base(options)
        { }

        public DbSet<AboutData> AboutData { get; set; }

        public DbSet<HomeData> HomeData { get; set; }

        public DbSet<CommandEntity> CommandEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AboutData>().HasKey(m => m.Id);
            builder.Entity<HomeData>().HasKey(m => m.Id);
            builder.Entity<CommandEntity>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        } 
    }
}