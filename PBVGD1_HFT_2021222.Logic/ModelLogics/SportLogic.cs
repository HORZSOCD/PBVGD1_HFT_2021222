using System;
using System.Collections.Generic;
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
            if (item.SportName.Length < 3)
                throw new ArgumentException("Sport name must be at least 3 characher long.");
            this.sportRepo.Create(item);
        }

        public void Delete(int id)
        {
            try
            {
                this.sportRepo.Delete(id);

            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Id does not exist.");
            }
            
        }

        public Sport Read(int id)
        {
            var sport = this.sportRepo.Read(id);
            if (sport == null)
                throw new ArgumentException("Sport does not exist.");
            return sport;
        }

        public IEnumerable<Sport> ReadAll()
        {
            return this.sportRepo.ReadAll();
        }

        public void Update(Sport item)
        {
            this.sportRepo.Update(item);
        }

        //Non-crud methods
        public int BrandSum()
        {
            return this.sportRepo
                 .ReadAll()
                 .Sum(b => b.Brands.Count);
        }

    }
}