using Microsoft.EntityFrameworkCore;
using Wema.CampusRunz.Core.Configurations;
using Wema.CampusRunz.Core.Models;

namespace Wema.CampusRunz.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServicePictures> ServicePictures { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}

