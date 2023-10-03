using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data.Models;

namespace SoftUniBazar.Data
{
    public class BazarDbContext : IdentityDbContext
    {
        public BazarDbContext(DbContextOptions<BazarDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Books"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Cars"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Clothes"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Home"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Technology"
                });

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<AdBuyer>()
                .HasKey(x => new
                {
                    x.BuyerId,
                    x.AdId
                });

            modelBuilder.Entity<Ad>()
                .Property(x => x.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<AdBuyer>()
        .HasOne(ep => ep.Ad)
        .WithMany(e => e.AdsBuyers)
        .HasForeignKey(ep => ep.AdId)
        .OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<Ad> Ads { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<AdBuyer> AdsBuyers { get; set; } = null!;
    }
}