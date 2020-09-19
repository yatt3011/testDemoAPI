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
    public class DashboardController : ControllerBase
    {
        private readonly testDemoContext _context;

        public DashboardController(testDemoContext context)
        {
            _context = context;
        }

        // GET: api/Dashboard
        [HttpGet]
        public IEnumerable<Dashboard> Getdashboards()
        {
            //return _context.dashboards;
            return _context.dashboards
                .Include(d => d.chartDonut)
                .Include(b => b.chartBar)
                .Include(u => u.tableUsers);
        }

        // GET: api/Dashboard/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDashboard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dashboard = await _context.dashboards.FindAsync(id);

            if (dashboard == null)
            {
                return NotFound();
            }

            return Ok(dashboard);
        }

        // PUT: api/Dashboard/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDashboard([FromRoute] int id, [FromBody] Dashboard dashboard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dashboard.dashboardId)
            {
                return BadRequest();
            }

            _context.Entry(dashboard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DashboardExists(id))
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

        // POST: api/Dashboard
        [HttpPost]
        public async Task<IActionResult> PostDashboard([FromBody] Dashboard dashboard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.dashboards.Add(dashboard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDashboard", new { id = dashboard.dashboardId }, dashboard);
        }

        // DELETE: api/Dashboard/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDashboard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dashboard = await _context.dashboards.FindAsync(id);
            if (dashboard == null)
            {
                return NotFound();
            }

            _context.dashboards.Remove(dashboard);
            await _context.SaveChangesAsync();

            return Ok(dashboard);
        }

        private bool DashboardExists(int id)
        {
            return _context.dashboards.Any(e => e.dashboardId == id);
        }
    }
}