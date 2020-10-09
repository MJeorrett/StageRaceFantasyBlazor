using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Application.FantasyTeams.Commands.Create;
using StageRaceFantasy.Application.FantasyTeams.Queries.GetById;
using StageRaceFantasy.Application.FantasyTeams.Queries.GetAll;
using StageRaceFantasy.Domain.Entities;
using StageRaceFantasy.Server.Controllers.Utils;
using StageRaceFantasy.Application.FantasyTeams.Commands.Delete;
using StageRaceFantasy.Application.FantasyTeams.Commands.Update;

namespace StageRaceFantasy.Server.Controllers
{
    [Route("api/fantasy-teams")]
    [ApiController]
    public class FantasyTeamsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FantasyTeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllFantasyTeamsVm>> GetFantasyTeams()
        {
            var query = new GetAllFantasyTeamsQuery();
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetFantasyTeamByIdVm>> GetFantasyTeam(int id)
        {
            var query = new GetFantasyTeamByIdQuery(id);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFantasyTeam(int id, UpdateFantasyTeamCommand command)
        {
            if (command.Id != id) return BadRequest();

            var query = new UpdateFantasyTeamCommand(id, command.Name);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        [HttpPost]
        public async Task<ActionResult<FantasyTeam>> PostFantasyTeam(CreateFantasyTeamCommand command)
        {
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildCreatedAtResponse(
                this,
                result,
                nameof(GetFantasyTeam),
                () => new { id = result.Content.Id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFantasyTeam(int id)
        {
            var command = new DeleteFantasyTeamCommand(id);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }
    }
}
