using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Server.Commands.FanasyTeamRaceEntries;
using StageRaceFantasy.Server.Controllers.Utils;
using StageRaceFantasy.Server.Queries.FantasyTeamRaceEntries;
using StageRaceFantasy.Shared.Models;
using StageRaceFantasy.Shared.Models.FantasyTeamRaceEntries;

namespace StageRaceFantasy.Server.Controllers
{
    [Route("api/fantasy-teams/{fantasyTeamId}/race-entries")]
    [ApiController]
    public class FantasyTeamRaceEntriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FantasyTeamRaceEntriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetFantasyTeamRaceEntryDto>>> GetFantasyTeamRaceEntries(int fantasyTeamId)
        {
            var query = new GetAllFantasyTeamRaceEntriesQuery(fantasyTeamId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpGet("{raceId}")]
        public async Task<ActionResult<GetFantasyTeamRaceEntryDto>> GetFantasyTeamRaceEntry(int fantasyTeamId, int raceId)
        {
            var query = new GetFantasyTeamRaceEntryQuery(fantasyTeamId, raceId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpPut("{raceId}")]
        public async Task<IActionResult> PutFantasyTeamRaceEntry(int fantasyTeamId, int raceId, UpdateFantasyTeamRaceEntryDto updateFantasyTeamRaceEntryDto)
        {
            var command = new UpdateFantasyTeamRaceEntryCommand(fantasyTeamId, raceId, updateFantasyTeamRaceEntryDto.RiderIds);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetFantasyTeamRaceEntryDto>> PostFantasyTeamRaceEntry(int fantasyTeamId, CreateFantasyTeamRaceEntryDto createFantasyTeamRaceEntryDto)
        {
            var command = new CreateFantasyTeamRaceEntryCommand(fantasyTeamId, createFantasyTeamRaceEntryDto.RaceId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildCreatedAtResponse(
                this,
                result,
                nameof(GetFantasyTeamRaceEntry),
                () => new { result.Content.FantasyTeamId, result.Content.RaceId });
        }

        [HttpDelete("{raceId}")]
        public async Task<IActionResult> DeleteFantasyTeamRaceEntry(int fantasyTeamId, int raceId)
        {
            var command = new DeleteFantasyTeamRaceEntryCommand(fantasyTeamId, raceId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }
    }
}
