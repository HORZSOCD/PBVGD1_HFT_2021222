using Microsoft.AspNetCore.Mvc;
using PBVGD1_HFT_2021222.Logic;
using PBVGD1_HFT_2021222.Models;
using System.Collections.Generic;

namespace PBVGD1_HFT_2021222.Endpoint.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ISportLogic sportLogic;
        IBrandLogic brandLogic;
        IProductLogic productLogic;

        public StatController(ISportLogic sportLogic, IBrandLogic brandLogic, IProductLogic productLogic)
        {
            this.sportLogic = sportLogic;
            this.brandLogic = brandLogic;
            this.productLogic = productLogic;
        }


        [HttpGet]
        public double? AverageProductPerBrand()
        {
            return this.brandLogic.AverageProductPerBrand();
        }


        [HttpGet]
        public IEnumerable<ProductLogic.PriceAverage> AveragePricePerBrand()
        {
            return this.productLogic.AveragePricePerBrand();
        }

        


        [HttpGet]
        public IEnumerable<Brands> BrandSum()
        {
            return this.sportLogic.BrandSum();
        }

        [HttpGet]
        public IEnumerable<BrandLogic.Products> ProductSum()
        {
            return this.brandLogic.PruductSum();
        }
    }
}
