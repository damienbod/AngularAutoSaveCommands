using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Angular2AutoSaveCommands;

namespace Angular2AutoSaveCommands.Migrations
{
    [DbContext(typeof(DomainModelMsSqlServerContext))]
    partial class DomainModelMsSqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Angular2AutoSaveCommands.Models.AboutData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("AboutData");
                });

            modelBuilder.Entity("Angular2AutoSaveCommands.Models.CommandEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActualClientRoute");

                    b.Property<string>("CommandType");

                    b.Property<string>("Payload");

                    b.Property<string>("PayloadType");

                    b.HasKey("Id");

                    b.ToTable("CommandEntity");
                });

            modelBuilder.Entity("Angular2AutoSaveCommands.Models.HomeData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("HomeData");
                });
        }
    }
}
