﻿// <auto-generated />
using AutoSaveCommandsApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoSaveCommandsApi.Migrations
{
    [DbContext(typeof(DomainModelMsSqlServerContext))]
    [Migration("20180616095050_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoSaveCommandsApi.Models.AboutData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("AboutData");
                });

            modelBuilder.Entity("AutoSaveCommandsApi.Models.CommandEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActualClientRoute");

                    b.Property<string>("CommandType");

                    b.Property<string>("Payload");

                    b.Property<string>("PayloadType");

                    b.HasKey("Id");

                    b.ToTable("CommandEntity");
                });

            modelBuilder.Entity("AutoSaveCommandsApi.Models.HomeData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("HomeData");
                });
#pragma warning restore 612, 618
        }
    }
}
