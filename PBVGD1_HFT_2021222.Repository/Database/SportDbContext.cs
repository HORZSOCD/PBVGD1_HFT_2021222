using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PBVGD1_HFT_2021222.Models;

namespace PBVGD1_HFT_2021222.Repository
{
    public class SportDbContext:DbContext
    {
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }

        public SportDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("Sports");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(brand => brand
            .HasOne(brand => brand.Sport)
            .WithMany(sport => sport.Brands)
            .HasForeignKey(brand => brand.SportId)
            .OnDelete(DeleteBehavior.Cascade)
            );

            modelBuilder.Entity<Product>(product => product
            .HasOne(product=>product.Brand)
            .WithMany(brand=>brand.Products)
            .HasForeignKey(product=>product.BrandId)
            .OnDelete(DeleteBehavior.Cascade)
            );

            var sports = new List<Sport>()
            {
                new Sport(){SportId = 1, SportName = "Cycling" },
                new Sport(){SportId = 2, SportName = "Running" }
            };

            var brands = new List<Brand>()
            {
                new Brand(){BrandId = 1, BrandName = "RockRider", SportId = 1},
                new Brand(){BrandId = 2, BrandName = "Triban", SportId = 1},
                new Brand(){BrandId = 3, BrandName = "Van Ryzel", SportId = 1},
                new Brand(){BrandId = 4, BrandName = "Kalenji", SportId = 2},
                new Brand(){BrandId = 5, BrandName = "Geonaute", SportId = 2},
                new Brand(){BrandId = 6, BrandName = "Aptonia", SportId = 2},

            };
            var products = new List<Product>()
            {
               new Product(){ProductId = 1, ProductName = "Rockrider ST 50",Price = 89900, BrandId = 1},
               new Product(){ProductId = 2, ProductName = "Triban RC 120",Price = 199990, BrandId = 2},
               new Product(){ProductId = 3, ProductName = "Rockrider ST 100",Price = 109990, BrandId = 1},
               new Product(){ProductId = 4, ProductName = "Kalenji Run Active Man shoes",Price = 9990, BrandId = 4},
               new Product(){ProductId = 5, ProductName = "Aptonia strawberry-raspberry",Price = 1790, BrandId = 6},
            };

            modelBuilder.Entity<Sport>().HasData(sports);
            modelBuilder.Entity<Brand>().HasData(brands);
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
