using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GatePass_DBContext;
using GatePass_Models;

namespace GatePass_Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UOMController : ControllerBase
    {
        private readonly AppDBContext _context;

        public UOMController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/UOM
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UOMModel>>> GetUOM()
        {
          if (_context.UOM == null)
          {
              return NotFound();
          }
            return await _context.UOM.ToListAsync();
        }

        // GET: api/UOM/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UOMModel>> GetUOMModel(int id)
        {
          if (_context.UOM == null)
          {
              return NotFound();
          }
            var uOMModel = await _context.UOM.FindAsync(id);

            if (uOMModel == null)
            {
                return NotFound();
            }

            return uOMModel;
        }

        // PUT: api/UOM/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUOMModel(int id, UOMModel uOMModel)
        {
            if (id != uOMModel.unitId)
            {
                return BadRequest();
            }

            _context.Entry(uOMModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UOMModelExists(id))
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

        // POST: api/UOM
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UOMModel>> PostUOMModel(UOMModel uOMModel)
        {
          if (_context.UOM == null)
          {
              return Problem("Entity set 'AppDBContext.UOM'  is null.");
          }
            _context.UOM.Add(uOMModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUOMModel", new { id = uOMModel.unitId }, uOMModel);
        }

        // DELETE: api/UOM/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUOMModel(int id)
        {
            if (_context.UOM == null)
            {
                return NotFound();
            }
            var uOMModel = await _context.UOM.FindAsync(id);
            if (uOMModel == null)
            {
                return NotFound();
            }

            _context.UOM.Remove(uOMModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UOMModelExists(int id)
        {
            return (_context.UOM?.Any(e => e.unitId == id)).GetValueOrDefault();
        }
    }
}
