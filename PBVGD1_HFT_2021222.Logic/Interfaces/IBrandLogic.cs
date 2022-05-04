using PBVGD1_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace PBVGD1_HFT_2021222.Logic
{
    public interface IBrandLogic
    {
        //Crud
        void Create(Brand item);
        void Delete(int id);
        Brand Read(int id);
        IEnumerable<Brand> ReadAll();
        void Update(Brand item);
        //Non-crud
        
        IEnumerable<AverageBrand> AverageProductPerBrand();
        
    }
}