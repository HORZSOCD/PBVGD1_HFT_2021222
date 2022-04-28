using PBVGD1_HFT_2021222.Logic;
using PBVGD1_HFT_2021222.Models;
using PBVGD1_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PBVGD1_HFT_2021222.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var ctx = new SportDbContext();
            IRepository<Sport> repo = new SportRepository(ctx);
            var logic = new SportLogic(repo);
        }
    }
}
