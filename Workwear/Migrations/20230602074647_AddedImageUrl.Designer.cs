﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workwear.Data;

#nullable disable

namespace Workwear.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230602074647_AddedImageUrl")]
    partial class AddedImageUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Workwear.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Штаны"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Обувь"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Комбинезон"
                        });
                });

            modelBuilder.Entity("Workwear.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "sdadasd",
                            ImageUrl = "",
                            Price = 500.0,
                            Title = "Штаны"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "aaaaaaaaaa",
                            ImageUrl = "",
                            Price = 200.0,
                            Title = "Обувь"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "bbbbbb",
                            ImageUrl = "",
                            Price = 350.0,
                            Title = "Комбинезон"
                        });
                });

            modelBuilder.Entity("Workwear.Models.Product", b =>
                {
                    b.HasOne("Workwear.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
