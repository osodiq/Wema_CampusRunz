﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wema.CampusRunz.Data.Data;

namespace Wema.CampusRunz.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200225184228_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("IdentityRole");

                    b.HasData(
                        new { Id = "70f42901-f6f6-4386-bcaf-69c4c8941283", ConcurrencyStamp = "179875cc-042a-45e0-804c-ff33a814918b", Name = "User", NormalizedName = "USER" },
                        new { Id = "fc4702f7-dae4-49ca-a058-d7d5b25308c5", ConcurrencyStamp = "01a18061-6a75-43e3-9023-5c9e1c46f863", Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
                    );
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<decimal>("Amount");

                    b.Property<string>("Category");

                    b.Property<string>("Comment");

                    b.Property<decimal>("ConvinienceFee");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Delivery");

                    b.Property<decimal>("DeliveryCost");

                    b.Property<string>("Description");

                    b.Property<string>("EventDate");

                    b.Property<string>("EventTime");

                    b.Property<string>("Name");

                    b.Property<string>("Vendor");

                    b.Property<bool>("Visibility");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.ProductPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("ImagePath");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ProductId");

                    b.HasKey("Id");

                    b.ToTable("ProductPhotos");
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("BusinessDescription");

                    b.Property<string>("BusinessName");

                    b.Property<int>("BusinessPhoneNumber");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("InstagramHandle");

                    b.Property<string>("TwitterHandle");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.ServicePictures", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("ImagePath");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ServiceId");

                    b.HasKey("Id");

                    b.ToTable("ServicePictures");
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.ProductType", b =>
                {
                    b.HasOne("Wema.CampusRunz.Core.Models.Product", "Product")
                        .WithOne("ProductType")
                        .HasForeignKey("Wema.CampusRunz.Core.Models.ProductType", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
