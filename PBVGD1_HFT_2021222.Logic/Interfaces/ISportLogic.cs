using PBVGD1_HFT_2021222.Models;
using System.Linq;

namespace PBVGD1_HFT_2021222.Logic
{
    public interface ISportLogic
    {
        void Create(Sport item);
        void Delete(int id);
        Sport Read(int id);
        IQueryable<Sport> ReadAll();
        void Update(Sport item);
    }
}