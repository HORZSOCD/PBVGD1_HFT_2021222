using ConsoleTools;
using PBVGD1_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PBVGD1_HFT_2021222.Client
{
    public class Program
    {

        static RestService rest;
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:44553/");

            var sportSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Sport"))
                .Add("Create", () => Create("Sport"))
                .Add("Delete", () => Delete("Sport"))
                .Add("Update", () => Update("Sport"))
                .Add("Exit", ConsoleMenu.Close);

            var brandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Brand"))
                .Add("Create", () => Create("Brand"))
                .Add("Delete", () => Delete("Brand"))
                .Add("Update", () => Update("Brand"))
                .Add("Exit", ConsoleMenu.Close);

            var productSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Product"))
                .Add("Create", () => Create("Product"))
                .Add("Delete", () => Delete("Product"))
                .Add("Update", () => Update("Product"))
                .Add("Exit", ConsoleMenu.Close);

            var nonCrud = new ConsoleMenu(args, level: 1)
                .Add("Brand Sum", () => BrandSum())
                .Add("Average Price", () => AveragePricePerBrand())
                .Add("Average products per brand", () => AverageProductPerBrand())
                .Add("Products under 10000Huf", () => PruductsUnder10000Huf())
                .Add("Products in order by name", ()=> ProductsInOrder())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Sports", () => sportSubMenu.Show())
                .Add("Brands", () => brandSubMenu.Show())
                .Add("Products", () => productSubMenu.Show())
                .Add("Non-crud", () => nonCrud.Show())
                .Add("Exit", ConsoleMenu.Close);

            

            menu.Show();
        }

        private static void Update(string entity)
        {
            Console.Clear();
            if (entity == "Sport")
            {
                Console.Write("Enter sport's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Sport sport = rest.Get<Sport>(id, "sport");
                Console.WriteLine($"Current name: {sport.SportName}. Enter new name: ");
                string newName = Console.ReadLine();
                sport.SportName = newName;
                rest.Put(sport, "sport");
            }else if (entity == "Brand")
            {
                Console.Write("Enter brand's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Brand brand = rest.Get<Brand>(id, "brand");
                Console.WriteLine($"Current name: {brand.BrandName}. Enter new name: ");
                string newName = Console.ReadLine();
                brand.BrandName = newName;
                rest.Put(brand, "brand");
            }else if (entity == "Product")
            {
                Console.Write("Enter product's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Product product = rest.Get<Product>(id, "product");
                Console.WriteLine($"Current name: {product.ProductName}. Enter new name: ");
                string newName = Console.ReadLine();
                product.ProductName = newName;
                rest.Put(product, "product");
            }
        }

        private static void Delete(string entity)
        {
            Console.Clear();
            if (entity == "Sport")
            {
                Console.Write("Enter sport's id to delete: ");
                int sportId = int.Parse(Console.ReadLine());
                rest.Delete(sportId, "sport");
                
            }else if (entity == "Brand")
            {
                Console.Write("Enter brand's id to delete: ");
                int brandId = int.Parse(Console.ReadLine());
                rest.Delete(brandId, "brand");

            }else if (entity == "Product")
            {
                Console.Write("Enter product's id to delete: ");
                int productId = int.Parse(Console.ReadLine());
                rest.Delete(productId, "product");

            }
        }

        private static void Create(string entity)
        {
            Console.Clear();
            if (entity == "Sport")
            {
                Console.Write("Enter sport name: ");
                string name = Console.ReadLine();
                rest.Post(new Sport() { SportName = name }, "sport");
            }else if (entity == "Brand")
            {
                Console.Write("Enter brand name: ");
                string name = Console.ReadLine();
                Console.Write("Enter sport id: ");
                int id= int.Parse(Console.ReadLine());
                rest.Post(new Brand() { BrandName = name, SportId=id }, "brand");
            }else if (entity == "Product")
            {
                Console.Write("Enter product name: ");
                string name = Console.ReadLine();
                Console.Write("Enter brand Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter price: ");
                int price= int.Parse(Console.ReadLine());
                rest.Post(new Product() { ProductName = name, BrandId = id, Price= price }, "product");
            }
        }

        private static void List(string entity)
        {
            Console.Clear();
            if (entity== "Sport")
            {
                List<Sport> sports = rest.Get<Sport>("sport");
                foreach (Sport sport in sports)
                {
                    Console.WriteLine($"\nID:\t{sport.SportId}\nName: {sport.SportName}");
                }
            }else if (entity == "Brand")
            {
                List<Brand> brands = rest.Get<Brand>("brand");
                foreach (Brand brand in brands)
                {
                    Console.WriteLine($"\nID:\t{brand.BrandId}\nSport: {brand.Sport.SportName}\nName: {brand.BrandName}");
                }
            }else if (entity == "Product")
            {
                List<Product> products = rest.Get<Product>("product");
                foreach (Product product in products)
                {
                    Console.WriteLine($"\nID:\t{product.ProductId}\nName: {product.ProductName}\nPrice: {product.Price}\nBrand: {product.Brand.BrandName}");
                }
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }


        public static void BrandSum()
        {
            var brands = rest.Get<Brands>("/stat/BrandSum");
            foreach (var item in brands)
            {
                Console.WriteLine(item.Name+" "+item.BrandSum);
            }
            Console.ReadKey();
        }

        public static void AveragePricePerBrand()
        {
            var brands = rest.Get<PriceAverage>("/stat/AveragePricePerBrand");
            foreach (var item in brands)
            {
                Console.WriteLine(item.Name + ": " + Math.Round(item.AveragePrice,2)+"Huf");
            }
            Console.ReadKey();
        }

        
        public static void AverageProductPerBrand()
        {
            var products = rest.Get<AverageBrand>("/stat/AverageProductPerBrand");
            foreach (var item in products)
            {
                Console.WriteLine(item.Name + ": " + item.Proucts);
            }
            Console.ReadKey();
        }

        public static void PruductsUnder10000Huf()
        {
            var products = rest.Get<ProductsSum>("/stat/PruductsUnder10000Huf");
            foreach (var item in products)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }

        public static void ProductsInOrder()
        {
            var products = rest.Get<Product>("/stat/ProductsInOrder");
            foreach (var item in products)
            {
                Console.WriteLine(item.ProductName);
            }
            Console.ReadKey();
        }
    }
}
