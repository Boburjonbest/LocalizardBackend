﻿// <auto-generated />
using System;
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
    [Migration("20240924105634_AddLanguage2")]
    partial class AddLanguage2
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

                    b.Property<string>("AvailableLanguage")
                        .HasColumnType("text");

                    b.Property<string>("DefaultLanguage")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("EmpClasses");
                });

            modelBuilder.Entity("Localizard.Models.Language1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PluralForms")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("languages");
                });

            modelBuilder.Entity("Localizard.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AvailableLanguage")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasAnnotation("Relational:JsonPropertyName", "CreatedAt");

                    b.Property<string>("DefaultLAnguage")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasAnnotation("Relational:JsonPropertyName", "UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("MyEntities");
                });

            modelBuilder.Entity("Localizard.Models.Translation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("English")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Namekeys")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<string>("Russian")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SomeValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Translations");
                });
#pragma warning restore 612, 618
        }
    }
}
