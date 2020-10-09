using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries;
using StageRaceFantasy.Application.FantasyTeamRaceEntries.Commands.Create;
using StageRaceFantasy.Application.FantasyTeamRaceEntries.Commands.Delete;
using StageRaceFantasy.Application.FantasyTeamRaceEntries.Commands.RemoveRider;
using StageRaceFantasy.Application.FantasyTeamRaceEntries.Queries.GetAll;
using StageRaceFantasy.Application.FantasyTeamRaceEntries.Queries.GetById;
using StageRaceFantasy.Domain.Entities;
using StageRaceFantasy.Server.Controllers.Utils;

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
        public async Task<ActionResult<GetAllFantasyTeamRaceEntriesVm>> GetFantasyTeamRaceEntries(int fantasyTeamId)
        {
            var query = new GetAllFantasyTeamRaceEntriesQuery(fantasyTeamId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpGet("{raceId}")]
        public async Task<ActionResult<GetFantasyTeamRaceEntryByIdVm>> GetFantasyTeamRaceEntry(int fantasyTeamId, int raceId)
        {
            var query = new GetFantasyTeamRaceEntryByIdQuery(fantasyTeamId, raceId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpPost]
        public async Task<ActionResult> PostFantasyTeamRaceEntry(int fantasyTeamId, CreateFantasyTeamRaceEntryCommand command)
        {
            if (command.FantasyTeamId != fantasyTeamId) return BadRequest();

            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildStatusCodeResponse(this, result, 201);
        }

        [HttpDelete("{raceId}")]
        public async Task<IActionResult> DeleteFantasyTeamRaceEntry(int fantasyTeamId, int raceId)
        {
            var command = new DeleteFantasyTeamRaceEntryCommand(fantasyTeamId, raceId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        [HttpPost("{raceId}/riders/{riderId}")]
        public async Task<IActionResult> AddRider(int fantasyTeamId, int raceId, int riderId)
        {
            var command = new AddRiderToFantasyTeamRaceEntryCommand(fantasyTeamId, raceId, riderId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        [HttpDelete("{raceId}/riders/{riderId}")]
        public async Task<IActionResult> RemoveRider(int fantasyTeamId, int raceId, int riderId)
        {
            var command = new RemoveRiderFromFantasyTeamRaceEntryCommand(fantasyTeamId, raceId, riderId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }
    }
}
