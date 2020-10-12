using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Riders.Commands.Create;
using StageRaceFantasy.Application.Riders.Commands.Delete;
using StageRaceFantasy.Application.Riders.Queries.GetAll;
using StageRaceFantasy.Domain.Entities;
using StageRaceFantasy.Server.Controllers.Utils;

namespace StageRaceFantasy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidersController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public RidersController(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: api/Riders
        [HttpGet]
        public async Task<ActionResult<GetAllRidersVm>> GetRiders()
        {
            var command = new GetAllRidersQuery();
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rider>> GetRider(int id)
        {
            var rider = await _context.Riders.FindAsync(id);

            if (rider == null)
            {
                return NotFound();
            }

            return rider;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostRider(CreateRiderCommand command)
        {
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildCreatedAtResponse(
                this,
                result,
                nameof(GetRider),
                () => new { id = result.Content });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRider(int id)
        {
            var command = new DeleteRiderCommand(id);

            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        private bool RiderExists(int id)
        {
            return _context.Riders.Any(e => e.Id == id);
        }
    }
}
