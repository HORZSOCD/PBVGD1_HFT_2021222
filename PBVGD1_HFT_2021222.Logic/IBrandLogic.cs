using PBVGD1_HFT_2021222.Models;
using System.Linq;

namespace PBVGD1_HFT_2021222.Logic
{
    public interface IBrandLogic
    {
        void Create(Brand item);
        void Delete(int id);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand item);
    }
}