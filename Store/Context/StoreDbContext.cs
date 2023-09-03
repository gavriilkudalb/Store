using Microsoft.EntityFrameworkCore;
using Store.Entities;

namespace Store.Context
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
 
                
        }
        public StoreDbContext()
        {
                
        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Basket> Basket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(bc => new { bc.UserId, bc.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(bc => bc.Role)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(bc => bc.RoleId);
            
            modelBuilder.Entity<Product>()
                .HasKey(bc => new { bc.ProductTypeId, bc.ProductBrandId,  });
            modelBuilder.Entity<Product>()
                .HasOne(bc => bc.ProductType)
                .WithMany(b => b.Products)
                .HasForeignKey(bc => bc.ProductTypeId);
            modelBuilder.Entity<Product>()
                .HasOne(bc => bc.ProductBrand)
                .WithMany(c => c.Products)
                .HasForeignKey(bc => bc.ProductBrandId);

        }
    }
}
