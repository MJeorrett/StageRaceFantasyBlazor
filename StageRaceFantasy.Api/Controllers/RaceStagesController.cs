using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Application.RaceStages.Commands.Create;
using StageRaceFantasy.Application.RaceStages.Commands.Update;
using StageRaceFantasy.Application.RaceStages.Queries.GetAll;
using StageRaceFantasy.Application.RaceStages.Queries.GetById;
using StageRaceFantasy.Server.Controllers.Utils;

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
        public async Task<ActionResult<GetAllRaceStagesVm>> GetRaceStages(int raceId)
        {
            var query = new GetAllRaceStagesQuery(raceId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpGet("{stageId}")]
        public async Task<ActionResult<GetRaceStageByIdVm>> GetRaceStage(int raceId, int stageId)
        {
            var query = new GetRaceStageByIdQuery(raceId, stageId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpPut("{stageId}")]
        public async Task<ActionResult> UpdateRaceStage(int raceId, int stageId, UpdateRaceStageCommand command)
        {
            if (command.RaceId != raceId || command.Id != stageId) return BadRequest();

            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        [HttpPost]
        public async Task<ActionResult<GetRaceStageByIdVm>> PostRaceStage(int raceId, CreateRaceStageCommand command)
        {
            if (command.RaceId != raceId) return BadRequest();

            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildCreatedAtResponse(
                this,
                result,
                nameof(GetRaceStage),
                () => new { raceId, stageId = result.Content.Id });
        }
    }
}
