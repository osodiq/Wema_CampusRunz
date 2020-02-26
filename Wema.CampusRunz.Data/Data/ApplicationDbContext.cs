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
        public DbSet<ServicePictures> ServicePictures { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<MediaOrder> MediaOrders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OrderAggregate> OrderAggregates { get; set; }
        public DbSet<Tokens> Tokens { get; set; }

    }
}

