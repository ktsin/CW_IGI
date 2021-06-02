using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BLL.Services.GoodsService _goodsService;

        public CategoriesController(GoodsService goodsService)
        {
            _goodsService = goodsService;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetCategories()
        {
            return new ActionResult<IEnumerable<CategoryDTO>>(_goodsService.GetCategories());
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var category = _goodsService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDTO category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            if(!CategoryExists(id))
                return NotFound();

            _goodsService.UpdateCategory(category);
            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> AddCategory(CategoryDTO category)
        {
            _goodsService.AddCategory(category);
            return CreatedAtAction("GetCategory", new {id = category.Id}, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!CategoryExists(id))
            {
                return NotFound();
            }
            _goodsService.DeleteCategory(id);
            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _goodsService.GetCategoryById(id) != null;
        }
    }
}