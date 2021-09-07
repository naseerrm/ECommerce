using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //AspNetUsers -> User
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("User");
        }

        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductShipmentTracking> ProductShipmentTracking { get; set; }
        public DbSet<ProductShippment> ProductShippment { get; set; }
        public DbSet<ProductUserReview> ProductUserReview { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<Supplierdetails> Supplierdetails { get; set; }
        public DbSet<UserOrderItem> UserOrderItem { get; set; }
    }
}
