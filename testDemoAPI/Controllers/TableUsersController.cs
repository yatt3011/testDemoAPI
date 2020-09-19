using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testDemoAPI.Data;
using testDemoAPI.Models;

namespace testDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableUsersController : ControllerBase
    {
        private readonly testDemoContext _context;

        public TableUsersController(testDemoContext context)
        {
            _context = context;
        }

        // GET: api/TableUsers
        [HttpGet]
        public IEnumerable<TableUser> GettableUsers()
        {
            return _context.tableUsers;
        }

        // GET: api/TableUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tableUser = await _context.tableUsers.FindAsync(id);

            if (tableUser == null)
            {
                return NotFound();
            }

            return Ok(tableUser);
        }

        // PUT: api/TableUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTableUser([FromRoute] int id, [FromBody] TableUser tableUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tableUser.id)
            {
                return BadRequest();
            }

            _context.Entry(tableUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableUserExists(id))
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

        // POST: api/TableUsers
        [HttpPost]
        public async Task<IActionResult> PostTableUser([FromBody] TableUser tableUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tableUsers.Add(tableUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTableUser", new { id = tableUser.id }, tableUser);
        }

        // DELETE: api/TableUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTableUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tableUser = await _context.tableUsers.FindAsync(id);
            if (tableUser == null)
            {
                return NotFound();
            }

            _context.tableUsers.Remove(tableUser);
            await _context.SaveChangesAsync();

            return Ok(tableUser);
        }

        private bool TableUserExists(int id)
        {
            return _context.tableUsers.Any(e => e.id == id);
        }
    }
}