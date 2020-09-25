using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Server.Commands;
using StageRaceFantasy.Server.Controllers.Utils;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Server.Queries;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Controllers
{
    [Route("api/fantasy-teams")]
    [ApiController]
    public class FantasyTeamsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMediator _mediator;

        public FantasyTeamsController(ApplicationDbContext context, IMediator mediator)
        {
            _dbContext = context;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllFantasyTeamsDto>>> GetFantasyTeams()
        {
            var query = new GetAllFantasyTeamsQuery();
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetFantasyTeamDto>> GetFantasyTeam(int id)
        {
            var query = new GetFantasyTeamQuery(id);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFantasyTeam(int id, UpdateFantasyTeamDto updateFantasyTeamDto)
        {
            var query = new UpdateFantasyTeamCommand(id, updateFantasyTeamDto.Name);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FantasyTeam>> PostFantasyTeam(CreateFantasyTeamDto createFantasyTeamDto)
        {
            var command = new CreateFantasyTeamCommand(createFantasyTeamDto.Name);
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
