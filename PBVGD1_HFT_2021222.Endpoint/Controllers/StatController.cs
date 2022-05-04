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
        public IEnumerable<AverageBrand> AverageProductPerBrand()
        {
            return this.brandLogic.AverageProductPerBrand();
        }

        [HttpGet]
        public IEnumerable<PriceAverage> AveragePricePerBrand()
        {
            return this.productLogic.AveragePricePerBrand();
        }

        [HttpGet]
        public IEnumerable<Brands> BrandSum()
        {
            return this.sportLogic.BrandSum();
        }

        [HttpGet]
        public IEnumerable<ProductsSum> PruductsUnder10000Huf()
        {
            return this.brandLogic.PruductsUnder10000Huf();
        }

        [HttpGet]
        public IEnumerable<Product> ProductsInOrder()
        {
            return this.productLogic.ProductsInOrder();
        }
    }
}
