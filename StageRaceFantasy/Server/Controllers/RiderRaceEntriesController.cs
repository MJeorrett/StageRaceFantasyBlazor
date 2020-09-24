using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Server.Commands;
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
        public async Task<IActionResult> PutRiderRaceEntry(int raceId, int riderId, UpdateRiderRaceEntryDto updateRiderRaceEntryDto)
        {
            var command = new UpdateRiderRaceEntryCommand(raceId, riderId, updateRiderRaceEntryDto);
            var result = await _mediator.Send(command);

            // TODO: Extract this into helper method.
            if (result.IsBadRequest) return BadRequest();
            else if (result.IsNotFound) return NotFound();
            else return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetRiderRaceEntryDto>> PostRiderRaceEntry(int raceId, CreateRiderRaceEntryDto createRiderRaceEntryDto)
        {
            var command = new CreateRiderRaceEntryCommand(
                raceId,
                createRiderRaceEntryDto.RiderId,
                createRiderRaceEntryDto.BibNumber);

            var result = await _mediator.Send(command);

            if (result.IsBadRequest) return BadRequest();
            else if (result.IsNotFound) return NotFound();
            else return CreatedAtAction(
                "GetRiderRaceEntry",
                new { raceId = result.Content.RaceId, riderId = result.Content.RiderId },
                result);
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
    }
}
