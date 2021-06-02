using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BLL.DataLandfill;

namespace WAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataItemsController : ControllerBase
    {
        private readonly DataLandfillContext _context;

        public DataItemsController(DataLandfillContext context)
        {
            _context = context;
        }

        // GET: api/DataItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataItem>>> GetImages()
        {
            return await _context.Images.ToListAsync();
        }

        // GET: api/DataItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataItem>> GetDataItem(string id)
        {
            var dataItem = await _context.Images.FindAsync(id);

            if (dataItem == null)
            {
                return NotFound();
            }

            return dataItem;
        }

        // PUT: api/DataItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataItem(string id, DataItem dataItem)
        {
            if (id != dataItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(dataItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DataItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataItem>> PostDataItem(DataItem dataItem)
        {
            _context.Images.Add(dataItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DataItemExists(dataItem.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDataItem", new { id = dataItem.Id }, dataItem);
        }

        // DELETE: api/DataItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataItem(string id)
        {
            var dataItem = await _context.Images.FindAsync(id);
            if (dataItem == null)
            {
                return NotFound();
            }

            _context.Images.Remove(dataItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataItemExists(string id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
