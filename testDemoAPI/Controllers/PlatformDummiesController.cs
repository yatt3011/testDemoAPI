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
    public class PlatformDummiesController : ControllerBase
    {
        private readonly testDemoContext _context;

        public PlatformDummiesController(testDemoContext context)
        {
            _context = context;
        }

        // GET: api/PlatformDummies
        [HttpGet]
        public IEnumerable<PlatformDummy> GetplatformDummies()
        {
            return _context.platformDummies;
        }

        // GET: api/PlatformDummies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatformDummy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var platformDummy = await _context.platformDummies.FindAsync(id);

            if (platformDummy == null)
            {
                return NotFound();
            }

            return Ok(platformDummy);
        }

        // PUT: api/PlatformDummies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlatformDummy([FromRoute] int id, [FromBody] PlatformDummy platformDummy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != platformDummy.platformId)
            {
                return BadRequest();
            }

            _context.Entry(platformDummy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatformDummyExists(id))
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

        // POST: api/PlatformDummies
        [HttpPost]
        public async Task<IActionResult> PostPlatformDummy([FromBody] PlatformDummy platformDummy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.platformDummies.Add(platformDummy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlatformDummy", new { id = platformDummy.platformId }, platformDummy);
        }

        // DELETE: api/PlatformDummies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatformDummy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var platformDummy = await _context.platformDummies.FindAsync(id);
            if (platformDummy == null)
            {
                return NotFound();
            }

            _context.platformDummies.Remove(platformDummy);
            await _context.SaveChangesAsync();

            return Ok(platformDummy);
        }

        private bool PlatformDummyExists(int id)
        {
            return _context.platformDummies.Any(e => e.platformId == id);
        }
    }
}