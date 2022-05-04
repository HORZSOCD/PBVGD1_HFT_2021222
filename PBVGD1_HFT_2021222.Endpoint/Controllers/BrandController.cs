using Microsoft.AspNetCore.Mvc;
using PBVGD1_HFT_2021222.Logic;
using PBVGD1_HFT_2021222.Models;
using System.Collections.Generic;

namespace PBVGD1_HFT_2021222.Endpoint.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic logic;
        public BrandController(IBrandLogic logic)
        {
            this.logic = logic;
        }
        
        [HttpGet]
        public IEnumerable<Brand> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Brand value)
        {
            this.logic.Create(value);
        }

        
        [HttpPut]
        public void Update([FromBody] Brand value)
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
