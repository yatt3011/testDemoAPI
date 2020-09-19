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
    public class ChartDashboardsController : ControllerBase
    {
        private readonly testDemoContext _context;

        public ChartDashboardsController(testDemoContext context)
        {
            _context = context;
        }

        // GET: api/ChartDashboards
        [HttpGet]
        public IEnumerable<ChartDashboard> GetchartDashboards()
        {
            return _context.chartDashboards;
        }

        // GET: api/ChartDashboards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChartDashboard([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chartDashboard = await _context.chartDashboards.FindAsync(id);

            if (chartDashboard == null)
            {
                return NotFound();
            }

            return Ok(chartDashboard);
        }

        // PUT: api/ChartDashboards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChartDashboard([FromRoute] string id, [FromBody] ChartDashboard chartDashboard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chartDashboard.name)
            {
                return BadRequest();
            }

            _context.Entry(chartDashboard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChartDashboardExists(id))
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

        // POST: api/ChartDashboards
        [HttpPost]
        public async Task<IActionResult> PostChartDashboard([FromBody] ChartDashboard chartDashboard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.chartDashboards.Add(chartDashboard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChartDashboard", new { id = chartDashboard.name }, chartDashboard);
        }

        // DELETE: api/ChartDashboards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChartDashboard([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chartDashboard = await _context.chartDashboards.FindAsync(id);
            if (chartDashboard == null)
            {
                return NotFound();
            }

            _context.chartDashboards.Remove(chartDashboard);
            await _context.SaveChangesAsync();

            return Ok(chartDashboard);
        }

        private bool ChartDashboardExists(string id)
        {
            return _context.chartDashboards.Any(e => e.name == id);
        }
    }
}