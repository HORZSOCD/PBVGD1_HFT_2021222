using PBVGD1_HFT_2021222.Models;
using PBVGD1_HFT_2021222.Repository;
using System;
using System.Linq;

namespace PBVGD1_HFT_2021222.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRepository<Sport> repo = new SportRepository(new SportDbContext());
            var items = repo.ReadAll().ToArray();
            ;
        }
    }
}
