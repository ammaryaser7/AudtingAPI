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
    public class DepartmentModelsController : ControllerBase
    {
        private readonly AuditDB _context;

        public DepartmentModelsController(AuditDB context)
        {
            _context = context;
        }

        // GET: api/DepartmentModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartmentModels()
        {
          if (_context.DepartmentModels == null)
          {
              return NotFound();
          }
            return await _context.DepartmentModels.ToListAsync();
        }

        // GET: api/DepartmentModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModel>> GetDepartmentModel(Guid id)
        {
          if (_context.DepartmentModels == null)
          {
              return NotFound();
          }
            var departmentModel = await _context.DepartmentModels.FindAsync(id);

            if (departmentModel == null)
            {
                return NotFound();
            }

            return departmentModel;
        }

        // PUT: api/DepartmentModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentModel(Guid id, DepartmentModel departmentModel)
        {
            if (id != departmentModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(departmentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentModelExists(id))
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

        // POST: api/DepartmentModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentModel>> PostDepartmentModel(DepartmentModel departmentModel)
        {
          if (_context.DepartmentModels == null)
          {
              return Problem("Entity set 'AuditDB.DepartmentModels'  is null.");
          }
            _context.DepartmentModels.Add(departmentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartmentModel", new { id = departmentModel.Id }, departmentModel);
        }

        // DELETE: api/DepartmentModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentModel(Guid id)
        {
            if (_context.DepartmentModels == null)
            {
                return NotFound();
            }
            var departmentModel = await _context.DepartmentModels.FindAsync(id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            _context.DepartmentModels.Remove(departmentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentModelExists(Guid id)
        {
            return (_context.DepartmentModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
