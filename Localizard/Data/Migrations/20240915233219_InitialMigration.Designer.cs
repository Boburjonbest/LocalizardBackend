﻿// <auto-generated />
using Localizard._context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Localizard.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240915233219_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Localizard.Models.EmpClass", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Array>("AvailableLanguage")
                        .HasColumnType("text");

                    b.Property<string>("DefaultLanguage")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("EmpClasses");
                });
#pragma warning restore 612, 618
        }
    }
}
