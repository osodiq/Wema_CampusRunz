using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wema.CampusRunz.Core.Configurations;
using Wema.CampusRunz.Core.Models;

namespace Wema.CampusRunz.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new RoleConfiguration());
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Tokens> Tokens { get; set; }
        public DbSet<ServicePictures> ServicePictures { get; set; }
        //public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        #region ProductOrder
        public DbSet<MediaAndProductionOrder> MediaAndProductionOrders { get; set; }
        public DbSet<OrderCategory> OrderCategories { get; set; }
        public DbSet<HotelOrder> HotelOrders { get; set; }
        public DbSet<EventTicketOrder> EventTicketOrders { get; set; }
        public DbSet<FastFoodOrder> FastFoodOrders { get; set; }
        public DbSet<GassRefillOrder> GassRefillOrders { get; set; }

        #endregion

    }
}

