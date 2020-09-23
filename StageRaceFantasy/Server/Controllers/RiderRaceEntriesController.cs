using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Controllers
{
    [Route("api/races/{raceId}/entries")]
    [ApiController]
    public class RiderRaceEntriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RiderRaceEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RiderRaceEntry>>> GetRiderRaceEntries()
        {
            return await _context.RiderRaceEntries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RiderRaceEntry>> GetRiderRaceEntry(int id)
        {
            var riderRaceEntry = await _context.RiderRaceEntries.FindAsync(id);

            if (riderRaceEntry == null)
            {
                return NotFound();
            }

            return riderRaceEntry;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRiderRaceEntry(int id, RiderRaceEntry riderRaceEntry)
        {
            if (id != riderRaceEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(riderRaceEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiderRaceEntryExists(id))
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

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RiderRaceEntry>> PostRiderRaceEntry(RiderRaceEntry riderRaceEntry)
        {
            _context.RiderRaceEntries.Add(riderRaceEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRiderRaceEntry", new { id = riderRaceEntry.Id }, riderRaceEntry);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRiderRaceEntry(int id)
        {
            var riderRaceEntry = await _context.RiderRaceEntries.FindAsync(id);
            if (riderRaceEntry == null)
            {
                return NotFound();
            }

            _context.RiderRaceEntries.Remove(riderRaceEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RiderRaceEntryExists(int id)
        {
            return _context.RiderRaceEntries.Any(e => e.Id == id);
        }
    }
}
