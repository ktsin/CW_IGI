using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly BLL.Services.StoreService storeService;

        public StoresController(StoreService storeService)
        {
            this.storeService = storeService;
        }

        // GET: api/<StoresController>
        [HttpGet]
        public IEnumerable<BLL.DTO.StoreDTO> Get()
        {
            return storeService.GetAllStores();
        }

        // GET api/<StoresController>/5
        [HttpGet("{id}")]
        public BLL.DTO.StoreDTO Get(int id)
        {
            return storeService.GetStoreById(id);
        }

        // POST api/<StoresController>
        [HttpPost]
        public void Post(BLL.DTO.StoreDTO value)
        {
            storeService.RegisterStore(value);
        }

        // PUT api/<StoresController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, BLL.DTO.StoreDTO value)
        {
            if (storeService.GetStoreById(id) == null)
                return NotFound();
            storeService.EditStore(value);
            Response.StatusCode = 200;
            return (IActionResult)Response;
        }

        // DELETE api/<StoresController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (storeService.GetStoreById(id) == null)
                return NotFound();
            storeService.DeleteStore(id);
            Response.StatusCode = 200;
            return (IActionResult)Response;
        }
    }
}
