using System;
using System.Linq;
using PBVGD1_HFT_2021222.Models;
using PBVGD1_HFT_2021222.Repository;

namespace PBVGD1_HFT_2021222.Logic
{
    public class SportLogic : ISportLogic
    {
        IRepository<Sport> sportRepo;

        public SportLogic(IRepository<Sport> sportRepo)
        {
            this.sportRepo = sportRepo;
        }
        public void Create(Sport item)
        {
            this.sportRepo.Create(item);
        }

        public void Delete(int id)
        {
            this.sportRepo.Delete(id);
        }

        public Sport Read(int id)
        {
            var sport = this.sportRepo.Read(id);
            if (sport == null)
                throw new ArgumentException("Sport does not exist.");
            return sport;
        }

        public IQueryable<Sport> ReadAll()
        {
            return this.sportRepo.ReadAll();
        }

        public void Update(Sport item)
        {
            this.sportRepo.Update(item);
        }
    }

}
