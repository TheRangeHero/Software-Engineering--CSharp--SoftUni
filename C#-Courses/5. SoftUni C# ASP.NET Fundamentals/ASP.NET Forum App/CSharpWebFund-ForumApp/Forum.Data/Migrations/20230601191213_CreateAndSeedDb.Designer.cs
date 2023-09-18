﻿// <auto-generated />
using System;
using ForumApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForumApp.Data.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    [Migration("20230601191213_CreateAndSeedDb")]
    partial class CreateAndSeedDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ForumApp.Data.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bd8d53e9-508d-484c-a9ba-23c4409f011e"),
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at libero maximus, gravida diam ac, blandit nisl. Curabitur vehicula diam.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at libero maximus, gravida diam ac, blandit nisl. Curabitur vehicula diam.",
                            Title = "My first post"
                        },
                        new
                        {
                            Id = new Guid("a0563f9a-90dd-445a-b598-ee39b77ab875"),
                            Content = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                            Title = "My second post"
                        },
                        new
                        {
                            Id = new Guid("4b938849-3b01-4440-ab79-eb7d644ad5cf"),
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin tristique urna neque, a porta libero volutpat ac. Nulla pulvinar.",
                            Title = "My third"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
