using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AudtingAPI.Models;
using AudtingAPI.ViewModel;

namespace AudtingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditModelsController : ControllerBase
    {
        private readonly AuditDB _context;

        public AuditModelsController(AuditDB context)
        {
            _context = context;
        }

        // GET: api/AuditModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditViewModel>>> GetAuditModels()
        {
          if (_context.AuditModels == null)
          {
              return NotFound();
          }
            var all= await _context.AuditModels.Include(x => x.UserModel).Include(x => x.EemployeeModel).ToListAsync();

            var auditViewModel = new List<AuditViewModel>();
            auditViewModel = all.Select(e => new AuditViewModel {
            Id =  e.Id,
            Actionname= e.Action,
            Username = e.UserModel?.Name,
            Employeename = e.EemployeeModel?.Name,
            timestamp= e.timestamp

            }).ToList();

            return auditViewModel;
           
            
             
            
        }

        // GET: api/AuditModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SingleAuditViewModel>> GetAuditModel(Guid id)
        {
          if (_context.AuditModels == null)
          {
              return NotFound();
          }
            var auditModel = await _context.AuditModels.FindAsync(id);

            var sa = new SingleAuditViewModel()
            {
                Id = auditModel.Id,
                Action = auditModel.Action,
                UserModelId = auditModel.UserModelId,
                EmployeeModelId= auditModel.EmployeeModelId,    
                 timestamp= auditModel.timestamp

            };

            

			if (auditModel == null)
            {
                return NotFound();
            }

            return sa;
        }

        // PUT: api/AuditModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditModel(Guid id, AuditModel auditModel)
        {
            if (id != auditModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(auditModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditModelExists(id))
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

        // POST: api/AuditModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuditModel>> PostAuditModel(AuditModel auditModel)
        {
          if (_context.AuditModels == null)
          {
              return Problem("Entity set 'AuditDB.AuditModels'  is null.");
          }
           auditModel.Id= Guid.NewGuid();    
            _context.AuditModels.Add(auditModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuditModel", new { id = auditModel.Id }, auditModel);
        }

        // DELETE: api/AuditModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuditModel(Guid id)
        {
            if (_context.AuditModels == null)
            {
                return NotFound();
            }
            var auditModel = await _context.AuditModels.FindAsync(id);
            if (auditModel == null)
            {
                return NotFound();
            }

            _context.AuditModels.Remove(auditModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuditModelExists(Guid id)
        {
            return (_context.AuditModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
