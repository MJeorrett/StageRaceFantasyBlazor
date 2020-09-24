using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Server.Commands.RiderRaceEntries;
using StageRaceFantasy.Server.Controllers.Utils;
using StageRaceFantasy.Server.Queries;
using StageRaceFantasy.Server.Queries.RiderRaceEntries;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Controllers
{
    [Route("api/races/{raceId}/entries")]
    [ApiController]
    public class RiderRaceEntriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RiderRaceEntriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetRiderRaceEntryDto>>> GetRiderRaceEntries(int raceId)
        {
            var query = new GetAllRiderRaceEntriesQuery(raceId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpGet("{riderId}")]
        public async Task<ActionResult<GetRiderRaceEntryDto>> GetRiderRaceEntry(int raceId, int riderId)
        {
            var query = new GetRiderRaceEntryQuery(raceId, riderId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpPut("{riderId}")]
        public async Task<IActionResult> PutRiderRaceEntry(int raceId, int riderId, UpdateRiderRaceEntryDto updateRiderRaceEntryDto)
        {
            var command = new UpdateRiderRaceEntryCommand(raceId, riderId, updateRiderRaceEntryDto);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
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

            return ResponseHelpers.BuildCreatedAtResponse(
                this,
                result,
                nameof(GetRiderRaceEntry),
                () => new { raceId = result.Content.RaceId, riderId = result.Content.RiderId });
        }

        [HttpDelete("{riderId}")]
        public async Task<IActionResult> DeleteRiderRaceEntry(int raceId, int riderId)
        {
            var command = new DeleteRiderRaceEntryCommand(raceId, riderId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }
    }
}
