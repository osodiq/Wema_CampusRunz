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
    [Migration("20200227124600_InitialSetup")]
    partial class InitialSetup
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

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("BusinessDescription");

                    b.Property<string>("BusinessLogo");

                    b.Property<string>("Businessname");

                    b.Property<string>("Category");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.CustomerOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AggregateId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DeliveryAddress");

                    b.Property<string>("Detail");

                    b.Property<int?>("MediaOrderId");

                    b.Property<int?>("PaymentId");

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("AggregateId");

                    b.HasIndex("MediaOrderId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("ProductId");

                    b.ToTable("CustomerOrders");
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.DeliveryMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DeliveryMethods");
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.MediaOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DeliveryAddress");

                    b.Property<string>("DocumentPath");

                    b.Property<string>("ExtraDetail");

                    b.Property<string>("PrintingType");

                    b.HasKey("Id");

                    b.ToTable("MediaOrders");
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.OrderAggregate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("Category");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("OrderAggregates");
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Method");

                    b.Property<int?>("ProductId");

                    b.Property<bool>("Status");

                    b.Property<decimal>("TotalAmount");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Payments");
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("ImagePath");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ServiceId");

                    b.HasKey("Id");

                    b.ToTable("ServicePictures");
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.Tokens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Token");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Wema.CampusRunz.Core.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Wema.CampusRunz.Core.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Wema.CampusRunz.Core.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Wema.CampusRunz.Core.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.CustomerOrder", b =>
                {
                    b.HasOne("Wema.CampusRunz.Core.Models.OrderAggregate", "Aggregate")
                        .WithMany()
                        .HasForeignKey("AggregateId");

                    b.HasOne("Wema.CampusRunz.Core.Models.MediaOrder", "MediaOrder")
                        .WithMany()
                        .HasForeignKey("MediaOrderId");

                    b.HasOne("Wema.CampusRunz.Core.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.HasOne("Wema.CampusRunz.Core.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.Payment", b =>
                {
                    b.HasOne("Wema.CampusRunz.Core.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.ProductType", b =>
                {
                    b.HasOne("Wema.CampusRunz.Core.Models.Product", "Product")
                        .WithOne("ProductType")
                        .HasForeignKey("Wema.CampusRunz.Core.Models.ProductType", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wema.CampusRunz.Core.Models.Tokens", b =>
                {
                    b.HasOne("Wema.CampusRunz.Core.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
