using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        private readonly GoodsService _goodsService;

        public GoodController(GoodsService goodsService)
        {
            _goodsService = goodsService;
        }

        // GET: api/GoodCategory
        [HttpGet]
        public IEnumerable<GoodDTO> Get()
        {
            return _goodsService.GetAllGoods();
        }

        // GET: api/GoodCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoodDTO>> Get(int id)
        {
            var good = _goodsService.GetById(id);
            if (good == null)
                return NotFound();
            return new ActionResult<GoodDTO>(good);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<GoodDTO>>> GetByStore(int id)
        {
            return new ActionResult<IEnumerable<GoodDTO>>(_goodsService.GetGoodsByStoreId(id));
        }
        
        

        // POST: api/GoodCategory
        [HttpPost]
        public void Post(GoodDTO value){
            _goodsService.AddGood(value);
        }

        // PUT: api/GoodCategory/5
        [HttpPut("{id}")]
        public IActionResult EditGood(int id, GoodDTO value)
        {
            var good = _goodsService.GetById(id);
            if (good == null)
                return NotFound();
            else
            {
                _goodsService.UpdateGood(value);
                return NoContent();
            }
        }

        // DELETE: api/GoodCategory/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
