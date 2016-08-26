using System;
using Angular2AutoSaveCommands.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular2AutoSaveCommands
{
    // >dotnet ef migration add testMigration
    public class DomainModelMsSqlServerContext : DbContext
    {
        public DomainModelMsSqlServerContext(DbContextOptions<DomainModelMsSqlServerContext> options) : base(options)
        { }

        public DbSet<AboutData> AboutDataItems { get; set; }

        public DbSet<HomeData> HomeDataItems { get; set; }

        public DbSet<CommandEntity> CommandDtoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AboutData>().HasKey(m => m.Id);
            builder.Entity<HomeData>().HasKey(m => m.Id);
            builder.Entity<CommandEntity>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        } 
    }
}