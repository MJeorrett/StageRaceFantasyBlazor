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
        public async Task<ActionResult<IEnumerable<GetRiderRaceEntryDto>>> GetRiderRaceEntries(int raceId)
        {
            var race = await _context.Races.FindAsync(raceId);

            if (race == null)
            {
                return NotFound();
            }

            var riderRaceEntries = await _context.RiderRaceEntries
                .AsNoTracking()
                .Include(x => x.Race)
                .Include(x => x.Rider)
                .Where(x => x.RaceId == raceId)
                .ToListAsync();

            var enteredRiderIds = riderRaceEntries.Select(x => x.RiderId);

            var notEnteredRiders = await _context.Riders
                .Where(x => !enteredRiderIds.Contains(x.Id))
                .ToListAsync();

            var enteredRiderRaceEntries = _mapper.Map<List<GetRiderRaceEntryDto>>(riderRaceEntries);
            enteredRiderRaceEntries.ForEach(x => x.IsEntered = true);

            var notEnteredRiderRaceEntries = notEnteredRiders
                .Select(x => new GetRiderRaceEntryDto
                {
                    Rider = x,
                    Race = _mapper.Map<GetRiderRaceEntryRaceDto>(race),
                    IsEntered = false,
                    BibNumber = -1,
                });

            return enteredRiderRaceEntries
                .Concat(notEnteredRiderRaceEntries)
                .ToList();
        }

        [HttpGet("{riderId}")]
        public async Task<ActionResult<GetRiderRaceEntryDto>> GetRiderRaceEntry(int raceId, int riderId)
        {
            var riderRaceEntry = await _context.RiderRaceEntries
                .Include(x => x.Race)
                .Include(x => x.Rider)
                .Where(x => x.RaceId == raceId && x.RiderId == riderId)
                .FirstOrDefaultAsync();

            if (riderRaceEntry != null)
            {
                var riderRaceEntryDto = _mapper.Map<GetRiderRaceEntryDto>(riderRaceEntry);
                riderRaceEntryDto.IsEntered = true;

                return riderRaceEntryDto;
            }

            var race = await _context.Races.FindAsync(raceId);
            var rider = await _context.Riders.FindAsync(riderId);

            if (race == null || rider == null)
            {
                return NotFound();
            }

            return new GetRiderRaceEntryDto
            {
                Rider = rider,
                Race = _mapper.Map<GetRiderRaceEntryRaceDto>(race),
                IsEntered = false,
                BibNumber = -1,
            };
        }

        [HttpPut("{riderId}")]
        public async Task<IActionResult> PutRiderRaceEntry(int raceId, int riderId, UpdateRiderRaceEntryDto riderRaceEntryDto)
        {
            if (raceId != riderRaceEntryDto.RaceId || riderId != riderRaceEntryDto.RiderId)
            {
                return BadRequest();
            }

            var riderRaceEntry = await _context.RiderRaceEntries.FindAsync(raceId, riderId);

            if (riderRaceEntry == null)
            {
                return NotFound();
            }

            riderRaceEntry.BibNumber = riderRaceEntryDto.BibNumber;
            await _context.SaveChangesAsync();
            
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

            await _context.RiderRaceEntries.AddAsync(riderRaceEntry);
            await _context.SaveChangesAsync();

            var getRiderRaceEntryDto = _mapper.Map<GetRiderRaceEntryDto>(riderRaceEntry);
            getRiderRaceEntryDto.IsEntered = true;

            return CreatedAtAction(
                "GetRiderRaceEntry",
                new { raceId = riderRaceEntryDto.RaceId, riderId = riderRaceEntryDto.RiderId },
                getRiderRaceEntryDto);
        }

        [HttpDelete("{riderId}")]
        public async Task<IActionResult> DeleteRiderRaceEntry(int raceId, int riderId)
        {
            var riderRaceEntry = await _context.RiderRaceEntries.FindAsync(raceId, riderId);

            if (riderRaceEntry == null)
            {
                return NotFound();
            }

            _context.RiderRaceEntries.Remove(riderRaceEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RiderRaceEntryExists(int raceId, int riderId)
        {
            return _context.RiderRaceEntries
                .Any(x =>x.RaceId == raceId && x.RiderId == riderId);
        }
    }
}
