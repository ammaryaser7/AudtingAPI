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
    public class UserModelsController : ControllerBase
    {
        private readonly AuditDB _context;

        public UserModelsController(AuditDB context)
        {
            _context = context;
        }

        // GET: api/UserModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUserModels()
        {
          if (_context.UserModels == null)
          {
              return NotFound();
          }
            return await _context.UserModels.ToListAsync();
        }

        // GET: api/UserModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserModel(Guid id)
        {
          if (_context.UserModels == null)
          {
              return NotFound();
          }
            var userModel = await _context.UserModels.FindAsync(id);

            if (userModel == null)
            {
                return NotFound();
            }

            return userModel;
        }

        // PUT: api/UserModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserModel(Guid id, UserModel userModel)
        {
            if (id != userModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(userModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(id))
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

        // POST: api/UserModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUserModel(UserModel userModel)
        {
          if (_context.UserModels == null)
          {
              return Problem("Entity set 'AuditDB.UserModels'  is null.");
          }
            _context.UserModels.Add(userModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserModel", new { id = userModel.Id }, userModel);
        }

        // DELETE: api/UserModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserModel(Guid id)
        {
            if (_context.UserModels == null)
            {
                return NotFound();
            }
            var userModel = await _context.UserModels.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }

            _context.UserModels.Remove(userModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserModelExists(Guid id)
        {
            return (_context.UserModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
