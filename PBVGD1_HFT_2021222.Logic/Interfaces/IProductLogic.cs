using PBVGD1_HFT_2021222.Models;
using System.Linq;

namespace PBVGD1_HFT_2021222.Logic
{
    public interface IProductLogic
    {
        void Create(Product item);
        void Delete(int id);
        Product Read(int id);
        IQueryable<Product> ReadAll();
        void Update(Product item);
    }
}