using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PBVGD1_HFT_2021222.Logic;
using PBVGD1_HFT_2021222.Models;
using PBVGD1_HFT_2021222.Repository;

namespace PBVGD1_HFT_2021222.Test
{
    [TestFixture]
    public class Test
    {
        SportLogic sportlogic;
        BrandLogic brandlogic;
        ProductLogic productlogic;

        Mock<IRepository<Sport>> mockSportRepo;
        Mock<IRepository<Brand>> mockBrandRepo;
        Mock<IRepository<Product>> mockProductRepo;

        [SetUp]
        public void Init()
        {
            // Repos init
            mockSportRepo = new Mock<IRepository<Sport>>();
            mockBrandRepo = new Mock<IRepository<Brand>>();
            mockProductRepo = new Mock<IRepository<Product>>();

            Sport fakeSport = new Sport();
            fakeSport.SportId = 1;
            fakeSport.SportName = "Soccer";
            var brands = new List<Brand>()
            {
                new Brand(){
                    BrandId = 1,
                    BrandName="Kipsta",
                    Sport = fakeSport,
                    SportId = 1
                },
                new Brand(){
                    BrandId = 2,
                    BrandName="Kipsta2",
                    Sport = fakeSport,
                    SportId = 1
                }
            };

            var sports = new List<Sport>()
            {
                new Sport() {
                    SportId=1,
                    SportName = "Soccer"
                }
            };

            Brand fakeBrand = new Brand();
            fakeBrand.BrandId = 1;
            fakeBrand.BrandName = "Kipsta";
            var products = new List<Product>()
            {
                new Product(){
                    ProductId = 1,
                    Price = 1000,
                    ProductName = "Kipsta soccer socks",
                    Brand = fakeBrand,
                    BrandId = 1

                },
                new Product(){
                    ProductId = 2,
                    Price = 1590,
                    ProductName = "Kipsta soccer shoes red",
                    Brand = fakeBrand,
                    BrandId = 1
                }
            };

            // Logics
            sportlogic = new SportLogic(mockSportRepo.Object);
            brandlogic = new BrandLogic(mockBrandRepo.Object);
            productlogic = new ProductLogic(mockProductRepo.Object);

            // Repo setup
            mockSportRepo.Setup(x => x.ReadAll()).Returns(sports);
            mockBrandRepo.Setup(x => x.ReadAll()).Returns(brands);
            mockProductRepo.Setup(x => x.ReadAll()).Returns(products);
        }

        [Test]
        public void ReadAllSports()
        {
            Assert.That(mockSportRepo.Object.ReadAll().Count, Is.EqualTo(1));
        }

        [Test]
        public void ReadAllBrands()
        {
            Assert.That(mockBrandRepo.Object.ReadAll().Count, Is.EqualTo(2));
        }

        [Test]
        public void ReadAllProducts()
        {
            Assert.That(mockProductRepo.Object.ReadAll().Count, Is.EqualTo(2));
        }

        [Test]
        public void CreateTrowsException()
        {
            Sport sport = new Sport();
            sport.SportName = "Sp";
            Assert.Throws<ArgumentException>(() =>
            {
                sportlogic.Create(sport);
            });
        }

        [Test]
        public void CreateNotTrowsException()
        {
            Sport sport = new Sport();
            sport.SportName = "Spo";
            sportlogic.Create(sport);
            mockSportRepo.Verify(x=>x.Create(sport),Times.Once);
            
        }

        [Test]
        public void CreateTrowsException2()
        {
            Brand brand = new Brand();
            brand.BrandName = "Sp";
            Assert.Throws<ArgumentException>(() =>
            {
                brandlogic.Create(brand);
            });
        }

        [Test]
        public void CreateNotTrowsException2()
        {
            Brand brand = new Brand();
            brand.BrandName = "Spo";
            brandlogic.Create(brand);
            mockBrandRepo.Verify(x => x.Create(brand), Times.Once);

        }

        [Test]
        public void CreateTrowsException3()
        {
            Product product= new Product();
            product.ProductName = "Sp";
            Assert.Throws<ArgumentException>(() =>
            {
                productlogic.Create(product);
            });
        }

        [Test]
        public void CreateNotTrowsException3()
        {
            Product product = new Product();
            product.ProductName = "Spo";
            productlogic.Create(product);
            mockProductRepo.Verify(x => x.Create(product), Times.Once);

        }
    }

}
