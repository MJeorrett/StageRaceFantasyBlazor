using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Races.Commands.Create;
using StageRaceFantasy.Application.Races.Commands.Delete;
using StageRaceFantasy.Application.Races.Commands.Update;
using StageRaceFantasy.Application.Races.Queries.GetAll;
using StageRaceFantasy.Application.Races.Queries.GetById;
using StageRaceFantasy.Server.Controllers.Utils;

namespace StageRaceFantasy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public RacesController(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllRacesVm>> GetRaces()
        {
            var query = new GetAllRacesQuery();

            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetRaceByIdVm>> GetRace(int id)
        {
            var query = new GetRaceByIdQuery(id);

            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRace(int id, UpdateRaceCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostRace(CreateRaceCommand race)
        {
            var result = await _mediator.Send(race);

            return ResponseHelpers.BuildCreatedAtResponse(
                this,
                result,
                nameof(GetRace),
                () => new { id = result.Content });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRace(int id)
        {
            var command = new DeleteRaceCommand(id);

            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }
    }
}
