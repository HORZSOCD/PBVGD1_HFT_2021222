using Microsoft.AspNetCore.Mvc;
using PBVGD1_HFT_2021222.Logic;
using PBVGD1_HFT_2021222.Models;
using System.Collections.Generic;

namespace PBVGD1_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductLogic logic;
        public ProductController(IProductLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Product> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Product Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Product value)
        {
            this.logic.Create(value);
        }


        [HttpPut]
        public void Update([FromBody] Product value)
        {
            this.logic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
