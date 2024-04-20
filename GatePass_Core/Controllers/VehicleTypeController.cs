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
    public class VehicleTypeController : ControllerBase
    {
        private readonly AppDBContext _context;

        public VehicleTypeController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/VehicleTypeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleTypeModel>>> GetvehicleTypes()
        {
          if (_context.vehicleTypes == null)
          {
              return NotFound();
          }
            return await _context.vehicleTypes.ToListAsync();
        }

        // GET: api/VehicleTypeModels/5
        [HttpPost]
        public async Task<ActionResult<VehicleTypeModel>> GetVehicleTypeModel(VehicleTypeById obj)
        {
          if (_context.vehicleTypes == null)
          {
              return NotFound();
          }
            var vehicleTypeModel = await _context.vehicleTypes.FindAsync(obj.vehicleTypeId);

            if (vehicleTypeModel == null)
            {
                return NotFound();
            }

            return vehicleTypeModel;
        }

        // PUT: api/VehicleTypeModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleTypeModel(int id, VehicleTypeModel vehicleTypeModel)
        {
            if (id != vehicleTypeModel.vehicleTypeId)
            {
                return BadRequest();
            }

            _context.Entry(vehicleTypeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleTypeModelExists(id))
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

        // POST: api/VehicleTypeModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehicleTypeModel>> PostVehicleTypeModel(VehicleTypeModel vehicleTypeModel)
        {
          if (_context.vehicleTypes == null)
          {
              return Problem("Entity set 'AppDBContext.vehicleTypes'  is null.");
          }
            _context.vehicleTypes.Add(vehicleTypeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleTypeModel", new { id = vehicleTypeModel.vehicleTypeId }, vehicleTypeModel);
        }

        // DELETE: api/VehicleTypeModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleTypeModel(int id)
        {
            if (_context.vehicleTypes == null)
            {
                return NotFound();
            }
            var vehicleTypeModel = await _context.vehicleTypes.FindAsync(id);
            if (vehicleTypeModel == null)
            {
                return NotFound();
            }

            _context.vehicleTypes.Remove(vehicleTypeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleTypeModelExists(int id)
        {
            return (_context.vehicleTypes?.Any(e => e.vehicleTypeId == id)).GetValueOrDefault();
        }
    }
}
