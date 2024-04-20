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
    public class InwardGatePassController : ControllerBase
    {
        private readonly AppDBContext _context;

        public InwardGatePassController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/InwardGatePass
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InwardGatePassModel>>> GetinwardGatePass()
        {
          if (_context.inwardGatePass == null)
          {
              return NotFound();
          }
            return await _context.inwardGatePass.ToListAsync();
        }

        // GET: api/InwardGatePass/5
        [HttpPost]
        public async Task<ActionResult<InwardGatePassModel>> GetInwardGatePassModel(InwardGatePassById obj)
        {
          if (_context.inwardGatePass == null)
          {
              return NotFound();
          }
            var inwardGatePassModel = await _context.inwardGatePass.FindAsync(obj.GatePassId);

            inwardGatePassModel.itemDetails = await _context.items.Where(x => x.InwardGatePassModelGatePassId == inwardGatePassModel.GatePassId).ToListAsync();
            inwardGatePassModel.addedByName = _context.userFullName.Where(x => x.userId == inwardGatePassModel.addedBy).FirstOrDefault().fullName;

            if (inwardGatePassModel == null)
            {
                return NotFound();
            }

            return inwardGatePassModel;
        }

        // PUT: api/InwardGatePass/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInwardGatePassModel(int id, InwardGatePassModel inwardGatePassModel)
        {
            if (id != inwardGatePassModel.GatePassId)
            {
                return BadRequest();
            }

            _context.Entry(inwardGatePassModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InwardGatePassModelExists(id))
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

        // POST: api/InwardGatePass
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InwardGatePassModel>> PostInwardGatePassModel(InwardGatePassModel inwardGatePassModel)
        {
          if (_context.inwardGatePass == null)
          {
              return Problem("Entity set 'AppDBContext.inwardGatePass'  is null.");
          }
            _context.inwardGatePass.Add(inwardGatePassModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInwardGatePassModel", new { id = inwardGatePassModel.GatePassId }, inwardGatePassModel);
        }

        // DELETE: api/InwardGatePass/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInwardGatePassModel(int id)
        {
            if (_context.inwardGatePass == null)
            {
                return NotFound();
            }
            var inwardGatePassModel = await _context.inwardGatePass.FindAsync(id);
            if (inwardGatePassModel == null)
            {
                return NotFound();
            }

            _context.inwardGatePass.Remove(inwardGatePassModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public IActionResult GetInwardGatePassPaginated(PaginationModel obj)
        {
            int startRowNum = obj.itemsPerPage * (obj.pageNum == 0 ? 1 : (obj.pageNum - 1));
            int endRowNum = obj.itemsPerPage * obj.pageNum;
            if(_context.inwardGatePass.Count() == 0)
            {
                return Ok(Array.Empty<InwardGatePassModel>());
            }
            var lastId = _context.inwardGatePass.Max(x => x.GatePassId);
            if (obj.pageNum > 1)
            {
                for (var i=1; i<obj.pageNum; i++)
                {
                    lastId -= obj.itemsPerPage;
                }
            }
            var inwardGatePass = _context.inwardGatePass
                .OrderByDescending(x => x.GatePassId)
                .Where(x => x.GatePassId <= lastId)
                .Take(obj.itemsPerPage)
                .ToList();

            foreach(var data in inwardGatePass)
            {
                data.itemDetails = _context.items.Where(x => x.InwardGatePassModelGatePassId == data.GatePassId).ToList();
                data.vehicleTypeName = _context.vehicleTypes.Where(x => x.vehicleTypeId == data.vehicleType).FirstOrDefault().vehicleTypeName;
                data.addedByName = _context.userFullName.Where(x => x.userId == data.addedBy).FirstOrDefault().fullName;
            }

            return Ok(inwardGatePass);
        }

        [HttpGet]
        public IActionResult GetInwardGatePassCount()
        {
            // return Ok(_context.inwardGatePass.Count(x => x.addedOn.Date == DateTime.UtcNow.Date));
            return Ok(_context.inwardGatePass.Count(x => x.addedOn.AddHours(5).Date == DateTime.UtcNow.AddHours(5).Date));
        }


        [HttpGet]
        public IActionResult GetInwardGatePassCountTotal()
        {
            return Ok(_context.inwardGatePass.Count());
        }

        private bool InwardGatePassModelExists(int id)
        {
            return (_context.inwardGatePass?.Any(e => e.GatePassId == id)).GetValueOrDefault();
        }
    }
}
