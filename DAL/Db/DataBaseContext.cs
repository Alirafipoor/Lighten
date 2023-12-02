using DAL.Config;
using DAL.Db.IdnetityEntity;
using Domain.Entities;
using Domain.Entities.Product;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Domain.Db
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {
            
        }
        public  DbSet<Products> products { get; set; }
        public  DbSet<Category> categories { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=185.10.75.52;Initial Catalog=ar79_ir_hi;User ID=ar79_ir_79;Password=aliking94@;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductsConfig());

            
        }
    }
    public class DataBaseContextIdentity :IdentityDbContext<user>
    {
        public DataBaseContextIdentity(DbContextOptions<DataBaseContextIdentity> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=185.10.75.52;Initial Catalog=ar79_ir_hi;User ID=ar79_ir_79;Password=aliking94@;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>()
                 .HasKey(p => new { p.UserId });

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .Ignore(p => p.LoginProvider);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(p => p.UserId);

            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasKey(p => p.UserId);
            modelBuilder.Entity<IdentityUser<string>>()
                .HasIndex(p => p.UserName)
                .IsUnique();
        }
    }
}
