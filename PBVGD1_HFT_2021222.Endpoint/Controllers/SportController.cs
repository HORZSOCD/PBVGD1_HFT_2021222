using Microsoft.AspNetCore.Mvc;
using PBVGD1_HFT_2021222.Logic;
using PBVGD1_HFT_2021222.Models;
using System.Collections.Generic;

namespace PBVGD1_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        ISportLogic logic;

        public SportController(ISportLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Sport> ReadAll()
        {
            return this.logic.ReadAll();
        }

        
        [HttpGet("{id}")]
        public Sport Read(int id)
        {
            return this.logic.Read(id);
        }

        
        [HttpPost]
        public void Create([FromBody] Sport value)
        {
            this.logic.Create(value);
        }

        
        [HttpPut]
        public void Update([FromBody] Sport value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<SportController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
