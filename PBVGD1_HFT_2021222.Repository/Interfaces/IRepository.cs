using System.Collections.Generic;
using System.Linq;

namespace PBVGD1_HFT_2021222.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> ReadAll();
        T Read(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
