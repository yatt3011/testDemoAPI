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
    public class WellDummiesController : ControllerBase
    {
        private readonly testDemoContext _context;

        public WellDummiesController(testDemoContext context)
        {
            _context = context;
        }

        // GET: api/WellDummies
        [HttpGet]
        public IEnumerable<WellDummy> GetwellDummies()
        {
            return _context.wellDummies;
        }

        // GET: api/WellDummies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWellDummy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wellDummy = await _context.wellDummies.FindAsync(id);

            if (wellDummy == null)
            {
                return NotFound();
            }

            return Ok(wellDummy);
        }

        // PUT: api/WellDummies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWellDummy([FromRoute] int id, [FromBody] WellDummy wellDummy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wellDummy.id)
            {
                return BadRequest();
            }

            _context.Entry(wellDummy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WellDummyExists(id))
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

        // POST: api/WellDummies
        [HttpPost]
        public async Task<IActionResult> PostWellDummy([FromBody] WellDummy wellDummy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.wellDummies.Add(wellDummy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWellDummy", new { id = wellDummy.id }, wellDummy);
        }

        // DELETE: api/WellDummies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWellDummy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wellDummy = await _context.wellDummies.FindAsync(id);
            if (wellDummy == null)
            {
                return NotFound();
            }

            _context.wellDummies.Remove(wellDummy);
            await _context.SaveChangesAsync();

            return Ok(wellDummy);
        }

        private bool WellDummyExists(int id)
        {
            return _context.wellDummies.Any(e => e.id == id);
        }
    }
}