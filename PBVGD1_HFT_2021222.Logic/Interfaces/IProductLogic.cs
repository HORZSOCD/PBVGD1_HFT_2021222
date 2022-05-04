using PBVGD1_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace PBVGD1_HFT_2021222.Logic
{
    public interface IProductLogic
    {
        //Crud
        void Create(Product item);
        void Delete(int id);
        Product Read(int id);
        IEnumerable<Product> ReadAll();
        void Update(Product item);
        //Non-crud
        IEnumerable<PriceAverage> AveragePricePerBrand();


    }
}