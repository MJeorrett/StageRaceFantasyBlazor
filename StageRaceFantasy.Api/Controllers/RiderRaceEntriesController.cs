using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Application.RiderRaceEntries.Commands.Create;
using StageRaceFantasy.Application.RiderRaceEntries.Commands.Delete;
using StageRaceFantasy.Application.RiderRaceEntries.Commands.Update;
using StageRaceFantasy.Application.RiderRaceEntries.Queries.GetAll;
using StageRaceFantasy.Server.Controllers.Utils;

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
        public async Task<ActionResult<GetAllRiderRaceEntriesVm>> GetRiderRaceEntries(int raceId)
        {
            var query = new GetAllRiderRaceEntriesQuery(raceId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpPut("{riderId}")]
        public async Task<ActionResult> PutRiderRaceEntry(int raceId, int riderId, UpdateRiderRaceEntryCommand command)
        {
            if (command.RaceId != raceId || command.RiderId != riderId) return BadRequest();

            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        [HttpPost]
        public async Task<ActionResult> PostRiderRaceEntry(int raceId, CreateRiderRaceEntryCommand command)
        {
            if (command.RaceId != raceId) return BadRequest();

            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildStatusCodeResult(this, result, 201);
        }

        [HttpDelete("{riderId}")]
        public async Task<ActionResult> DeleteRiderRaceEntry(int raceId, int riderId)
        {
            var command = new DeleteRiderRaceEntryCommand(raceId, riderId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }
    }
}
