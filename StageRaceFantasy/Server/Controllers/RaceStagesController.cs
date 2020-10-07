using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Server.Commands.RaceStages;
using StageRaceFantasy.Server.Controllers.Utils;
using StageRaceFantasy.Server.Queries.GetRaceStages;
using StageRaceFantasy.Server.Queries.RaceStages;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.Controllers
{
    [Route("api/races/{raceId}/stages")]
    [ApiController]
    public class RaceStagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RaceStagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetRaceStagesDto>> GetRaceStages(int raceId)
        {
            var query = new GetRaceStagesQuery(raceId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpGet("{stageId}")]
        public async Task<ActionResult<GetRaceStageDto>> GetRaceStage(int raceId, int stageId)
        {
            var query = new GetRaceStageQuery(raceId, stageId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetRaceStageDto>> PostRiderRaceEntry(int raceId, CreateRaceStageDto createRaceStageDto)
        {
            var command = new CreateRaceStageCommand(
                raceId,
                createRaceStageDto.StartLocation,
                createRaceStageDto.FinishLocation);

            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildCreatedAtResponse(
                this,
                result,
                nameof(GetRaceStage),
                () => new { raceId, stageId = result.Content.Id });
        }
    }
}
