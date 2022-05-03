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
                new Sport(){SportId = 2, SportName = "Running" },
                new Sport(){SportId = 3, SportName = "SportWalking" },
                new Sport(){SportId = 4, SportName = "Hiking" },
                new Sport(){SportId = 5, SportName = "Hunting" },
                new Sport(){SportId = 6, SportName = "Soccer" },
                new Sport(){SportId = 7, SportName = "Swimming" }



            };

            var brands = new List<Brand>()
            {
                new Brand(){BrandId = 1, BrandName = "RockRider", SportId = 1},
                new Brand(){BrandId = 2, BrandName = "Triban", SportId = 1},
                new Brand(){BrandId = 3, BrandName = "Van Ryzel", SportId = 1},
                new Brand(){BrandId = 4, BrandName = "Kalenji", SportId = 2},
                new Brand(){BrandId = 5, BrandName = "Geonaute", SportId = 2},
                new Brand(){BrandId = 6, BrandName = "Aptonia", SportId = 2},
                new Brand(){BrandId = 7, BrandName = "Newfeel", SportId = 3},
                new Brand(){BrandId = 8, BrandName = "Asics", SportId = 3},
                new Brand(){BrandId = 9, BrandName = "Reebok", SportId = 3},
                new Brand(){BrandId = 10, BrandName = "Quechua", SportId = 4},
                new Brand(){BrandId = 11, BrandName = "Solognac", SportId = 5},
                new Brand(){BrandId = 12, BrandName = "Kipsta", SportId = 6},
                new Brand(){BrandId = 13, BrandName = "Arena", SportId = 7}

            };
            var products = new List<Product>()
            {
               new Product(){ProductId = 1, ProductName = "Rockrider ST 50",Price = 89900, BrandId = 1},
               new Product(){ProductId = 2, ProductName = "Triban RC 120",Price = 199990, BrandId = 2},
               new Product(){ProductId = 3, ProductName = "Rockrider ST 100",Price = 109990, BrandId = 1},
               new Product(){ProductId = 4, ProductName = "Kalenji Run Active Man shoes",Price = 9990, BrandId = 4},
               new Product(){ProductId = 5, ProductName = "Aptonia strawberry-raspberry",Price = 1790, BrandId = 6},
               new Product(){ProductId = 6, ProductName = "Man city walk shoes soft 140 mesh, black, white",Price = 5990, BrandId = 7},
               new Product(){ProductId = 7, ProductName = "Woman sport sock for walking",Price = 1790, BrandId = 7},
               new Product(){ProductId = 8, ProductName = "Kid sport walking shoes, super-light, black, green",Price = 13500, BrandId = 7},
               new Product(){ProductId = 9, ProductName = "Quantum lyte man sport walking shoes",Price = 21990, BrandId = 8},
               new Product(){ProductId = 10, ProductName = "Woman tiger shoes black",Price = 17990, BrandId = 8},
               new Product(){ProductId = 11, ProductName = "Woman tiger shoes gold",Price = 17900, BrandId = 8},
               new Product(){ProductId = 12, ProductName = "Man walking shoes blue",Price = 12990, BrandId = 9},
               new Product(){ProductId = 13, ProductName = "Baby walking shoes, pink, white",Price = 9990, BrandId = 9},
               new Product(){ProductId = 14, ProductName = "Woman walking shorts",Price = 5990, BrandId = 9},
               new Product(){ProductId = 15, ProductName = "Quechua hiking bag 50L",Price = 24990, BrandId = 10},
               new Product(){ProductId = 16, ProductName = "Belt for hunting trousers",Price = 3490, BrandId = 11},
               new Product(){ProductId = 17, ProductName = "Kipsta pump for balls",Price = 1990, BrandId = 12},
               new Product(){ProductId = 18, ProductName = "Kipsta soccer socks, blue",Price = 2490, BrandId = 12},
               new Product(){ProductId = 19, ProductName = "Woman swimming dress spotlight",Price = 9990, BrandId = 13}



            };

            modelBuilder.Entity<Sport>().HasData(sports);
            modelBuilder.Entity<Brand>().HasData(brands);
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
