using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AudtingAPI.Models;

namespace AudtingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeModelsController : ControllerBase
    {
        private readonly AuditDB _context;

        public EmployeeModelsController(AuditDB context)
        {
            _context = context;
        }

        // GET: api/EmployeeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployeeModels()
        {
          if (_context.EmployeeModels == null)
          {
              return NotFound();
          }
            return await _context.EmployeeModels.ToListAsync();
        }

        // GET: api/EmployeeModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeModel(Guid id)
        {
          if (_context.EmployeeModels == null)
          {
              return NotFound();
          }
            var employeeModel = await _context.EmployeeModels.FindAsync(id);

            if (employeeModel == null)
            {
                return NotFound();
            }

            return employeeModel;
        }

        // PUT: api/EmployeeModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeModel(Guid id, EmployeeModel employeeModel)
        {
            if (id != employeeModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeModelExists(id))
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

        // POST: api/EmployeeModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> PostEmployeeModel(EmployeeModel employeeModel)
        {
          if (_context.EmployeeModels == null)
          {
              return Problem("Entity set 'AuditDB.EmployeeModels'  is null.");
          }
            _context.EmployeeModels.Add(employeeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeModel", new { id = employeeModel.Id }, employeeModel);
        }

        // DELETE: api/EmployeeModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeModel(Guid id)
        {
            if (_context.EmployeeModels == null)
            {
                return NotFound();
            }
            var employeeModel = await _context.EmployeeModels.FindAsync(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            _context.EmployeeModels.Remove(employeeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeModelExists(Guid id)
        {
            return (_context.EmployeeModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
