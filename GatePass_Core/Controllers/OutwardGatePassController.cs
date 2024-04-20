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
    public class OutwardGatePassController : ControllerBase
    {
        private readonly AppDBContext _context;

        public OutwardGatePassController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/OutwardGatePass
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutwardGatePassModel>>> GetoutwardGatePass()
        {
            if (_context.outwardGatePass == null)
            {
                return NotFound();
            }
            return await _context.outwardGatePass.ToListAsync();
        }

        // GET: api/OutwardGatePass/5
        [HttpPost]
        public async Task<ActionResult<OutwardGatePassModel>> GetOutwardGatePassModel(getOutwardGatePassById obj)
        {
            if (_context.outwardGatePass == null)
            {
                return NotFound();
            }
            var outwardGatePassModel = await _context.outwardGatePass.FindAsync(obj.dispatchId);
            outwardGatePassModel.dispatchItems = await _context.dispatchItems.Where(x => x.OutwardGatePassModeldispatchId == outwardGatePassModel.dispatchId).ToListAsync();
            outwardGatePassModel.hoistingByName = _context.userFullName.Where(x => x.userId == outwardGatePassModel.hoistingBy).FirstOrDefault().fullName;
            foreach(var data in outwardGatePassModel.dispatchItems)
            {
                data.uomName = _context.UOM.Find(data.uom).unitName;
            }
            if (outwardGatePassModel == null)
            {
                return NotFound();
            }

            return outwardGatePassModel;
        }

        // PUT: api/OutwardGatePass/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOutwardGatePassModel(int id, OutwardGatePassModel outwardGatePassModel)
        {
            if (id != outwardGatePassModel.dispatchId)
            {
                return BadRequest();
            }

            _context.Entry(outwardGatePassModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OutwardGatePassModelExists(id))
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

        // POST: api/OutwardGatePass
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OutwardGatePassModel>> PostOutwardGatePassModel(OutwardGatePassModel outwardGatePassModel)
        {
            if (_context.outwardGatePass == null)
            {
                return Problem("Entity set 'AppDBContext.outwardGatePass'  is null.");
            }
            _context.outwardGatePass.Add(outwardGatePassModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOutwardGatePassModel", new { id = outwardGatePassModel.dispatchId }, outwardGatePassModel);
        }

        // DELETE: api/OutwardGatePass/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOutwardGatePassModel(int id)
        {
            if (_context.outwardGatePass == null)
            {
                return NotFound();
            }
            var outwardGatePassModel = await _context.outwardGatePass.FindAsync(id);
            if (outwardGatePassModel == null)
            {
                return NotFound();
            }

            _context.outwardGatePass.Remove(outwardGatePassModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public IActionResult GetOutwardGatePassPaginated(PaginationModel obj)
        {
            int startRowNum = obj.itemsPerPage * (obj.pageNum == 0 ? 1 : (obj.pageNum - 1));
            int endRowNum = obj.itemsPerPage * obj.pageNum;

            if(_context.outwardGatePass.Count() == 0)
            {
                return Ok(Array.Empty<OutwardGatePassModel>());
            }

            var lastId = _context.outwardGatePass.Max(x => x.dispatchId);
            if (obj.pageNum > 1)
            {
                for (var i = 1; i < obj.pageNum; i++)
                {
                    lastId -= obj.itemsPerPage;
                }
            }

            var outwardGatePass = _context.outwardGatePass
            .OrderByDescending(x => x.dispatchId)
            .Where(x => x.dispatchId <= lastId)
            .Take(obj.itemsPerPage)
            .ToList();

            foreach (var data in outwardGatePass)
            {
                data.dispatchItems = _context.dispatchItems.Where(x => x.OutwardGatePassModeldispatchId == data.dispatchId).ToList();
                data.hoistingByName = _context.userFullName.Where(x => x.userId == data.hoistingBy).FirstOrDefault().fullName;
            }

            return Ok(outwardGatePass);
        }

        [HttpGet]
        public IActionResult GetOutwardGatePassCount()
        {
            //return Ok(_context.outwardGatePass.Count(x => x.addedOn.Date == DateTime.UtcNow.Date));
            return Ok(_context.outwardGatePass.Count(x => x.addedOn.AddHours(5).Date == DateTime.UtcNow.AddHours(5).Date));
        }

        [HttpGet]
        public IActionResult GetOutwardGatePassCountTotal()
        {
            return Ok(_context.outwardGatePass.Count());
        }


        private bool OutwardGatePassModelExists(int id)
        {
            return (_context.outwardGatePass?.Any(e => e.dispatchId == id)).GetValueOrDefault();
        }
    }
}
