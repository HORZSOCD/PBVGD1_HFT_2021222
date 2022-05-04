using PBVGD1_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace PBVGD1_HFT_2021222.Logic
{
    public interface ISportLogic
    {
        //Crud
        void Create(Sport item);
        void Delete(int id);
        Sport Read(int id);
        IEnumerable<Sport> ReadAll();
        void Update(Sport item);

        //Non-crud
        IEnumerable<Brands> BrandSum();
    }
}