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
    public class PlatformWellController : ControllerBase
    {
        private readonly testDemoContext _context;

        public PlatformWellController(testDemoContext context)
        {
            _context = context;
        }

        // GET: api/PlatformWell/GetPlatformWellActual
        [HttpGet("GetPlatformWellActual")]
        public IEnumerable<Platform> Getplatforms()
        {            
            return _context.platforms
                .Include(w => w.wells);
        }

        // GET: api/PlatformWell/GetPlatformWellDummy
        [HttpGet("GetPlatformWellDummy")]
        public IEnumerable<PlatformDummy> GetplatformDummies()
        {            
            return _context.platformDummies
                .Include(wd => wd.wellDummies);
        }

        #region
        /**
         * 
        // GET: api/PlatformWell/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatform([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var platform = await _context.platforms.FindAsync(id);

            if (platform == null)
            {
                return NotFound();
            }

            return Ok(platform);
        }

        // PUT: api/PlatformWell/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlatform([FromRoute] int id, [FromBody] Platform platform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != platform.platformId)
            {
                return BadRequest();
            }

            _context.Entry(platform).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatformExists(id))
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

        // POST: api/PlatformWell
        [HttpPost]
        public async Task<IActionResult> PostPlatform([FromBody] Platform platform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.platforms.Add(platform);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlatform", new { id = platform.platformId }, platform);
        }

        // DELETE: api/PlatformWell/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatform([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var platform = await _context.platforms.FindAsync(id);
            if (platform == null)
            {
                return NotFound();
            }

            _context.platforms.Remove(platform);
            await _context.SaveChangesAsync();

            return Ok(platform);
        }

        private bool PlatformExists(int id)
        {
            return _context.platforms.Any(e => e.platformId == id);
        }
        */
        #endregion
    }
}