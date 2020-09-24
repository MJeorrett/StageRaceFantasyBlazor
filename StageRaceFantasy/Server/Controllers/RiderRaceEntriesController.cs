using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public RiderRaceEntriesController(
            ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RiderRaceEntry>>> GetRiderRaceEntries(int raceId)
        {
            if (!RaceExists(raceId))
            {
                return NotFound();
            }

            return await _context.RiderRaceEntries
                .Where(x => x.RaceId == raceId)
                .ToListAsync();
        }

        [HttpGet("{riderId}")]
        public async Task<ActionResult<RiderRaceEntry>> GetRiderRaceEntry(int raceId, int riderId)
        {
            var riderRaceEntry = await FindRiderRaceEntry(raceId, riderId);

            if (riderRaceEntry == null)
            {
                return NotFound();
            }

            return riderRaceEntry;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{riderId}")]
        public async Task<IActionResult> PutRiderRaceEntry(int raceId, int riderId, RiderRaceEntry riderRaceEntry)
        {
            if (raceId != riderRaceEntry.RaceId || riderId != riderRaceEntry.RiderId)
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
                if (!RiderRaceEntryExists(raceId, riderId))
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
        public async Task<ActionResult<RiderRaceEntry>> PostRiderRaceEntry(int raceId, AddRiderRaceEntryDto riderRaceEntryDto)
        {
            if (raceId != riderRaceEntryDto.RaceId)
            {
                return BadRequest();
            }

            if (RiderRaceEntryExists(raceId, riderRaceEntryDto.RiderId))
            {
                return BadRequest();
            }

            var race = await _context.Races.FindAsync(riderRaceEntryDto.RaceId);
            var rider = await _context.Riders.FindAsync(riderRaceEntryDto.RiderId);

            if (race == null || rider == null)
            {
                return NotFound();
            }

            var riderRaceEntry = new RiderRaceEntry()
            {
                Race = race,
                Rider = rider,
                BibNumber = riderRaceEntryDto.BibNumber,
            };

            var getRierRaceEntryDto = _mapper.Map<GetRiderRaceEntryDto>(riderRaceEntry);

            await _context.RiderRaceEntries.AddAsync(riderRaceEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRiderRaceEntry", new { raceId = riderRaceEntryDto.RaceId, riderId = riderRaceEntryDto.RiderId }, getRierRaceEntryDto);
        }

        [HttpDelete("{riderId}")]
        public async Task<IActionResult> DeleteRiderRaceEntry(int raceId, int riderId)
        {
            var riderRaceEntry = await FindRiderRaceEntry(raceId, riderId);

            if (riderRaceEntry == null)
            {
                return NotFound();
            }

            _context.RiderRaceEntries.Remove(riderRaceEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<RiderRaceEntry> FindRiderRaceEntry(int raceId, int riderId)
        {
            return await _context.RiderRaceEntries.FindAsync(raceId, riderId);
        }

        private bool RiderRaceEntryExists(int raceId, int riderId)
        {
            return _context.RiderRaceEntries.Any(x => x.RaceId == raceId && x.RiderId == riderId);
        }

        private bool RaceExists(int raceId)
        {
            return _context.Races.Any(x => x.Id == raceId);
        }
    }
}
