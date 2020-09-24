using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Server.Queries;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Controllers
{
    [Route("api/races/{raceId}/entries")]
    [ApiController]
    public class RiderRaceEntriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RiderRaceEntriesController(
            ApplicationDbContext context,
            IMapper mapper,
            IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetRiderRaceEntryDto>>> GetRiderRaceEntries(int raceId)
        {
            var query = new GetAllRiderRaceEntriesQuery(raceId);
            var result = await _mediator.Send(query);

            return result.IsNotFound ? NotFound() : result.Content;
        }

        [HttpGet("{riderId}")]
        public async Task<ActionResult<GetRiderRaceEntryDto>> GetRiderRaceEntry(int raceId, int riderId)
        {
            var query = new GetRiderRaceEntryQuery(raceId, riderId);
            var result = await _mediator.Send(query);

            return result.IsNotFound ? NotFound() : result.Content;
        }

        [HttpPut("{riderId}")]
        public async Task<IActionResult> PutRiderRaceEntry(int raceId, int riderId, UpdateRiderRaceEntryDto riderRaceEntryDto)
        {
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
