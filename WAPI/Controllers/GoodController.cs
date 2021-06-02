using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodCategoryController : ControllerBase
    {
        // GET: api/GoodCategory
        [HttpGet]
        public IEnumerable<GoodDTO> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GoodCategory/5
        [HttpGet("{id}", Name = "Get")]
        public GoodDTO Get(int id)
        {
            return "value";
        }

        // POST: api/GoodCategory
        [HttpPost]
        public void Post(GoodDTO value)
        {
        }

        // PUT: api/GoodCategory/5
        [HttpPut("{id}")]
        public void Put(int id, GoodDTO value)
        {
        }

        // DELETE: api/GoodCategory/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
