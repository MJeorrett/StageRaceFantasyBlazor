using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.RiderRaceEntries.Commands.Create
{
    public class CreateRiderRaceEntryCommand :
        CreateRiderRaceEntryDto,
        IApplicationCommand
    {
    }

    public class CreateRiderRaceEntryHandler : ApplicationRequestHandler<CreateRiderRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateRiderRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(
            CreateRiderRaceEntryCommand request,
            CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var riderId = request.RiderId;

            var raceEntryExists = await _dbContext.RiderRaceEntries
                .AnyAsync(x => x.RaceId == raceId && x.RiderId == riderId, cancellationToken);

            if (raceEntryExists) return BadRequest();

            var raceExists = await _dbContext.Races.AnyAsync(x => x.Id == raceId, cancellationToken);
            var riderExists = await _dbContext.Riders.AnyAsync(x => x.Id == riderId, cancellationToken);

            if (!raceExists || !riderExists) return NotFound();

            var riderRaceEntry = new RiderRaceEntry()
            {
                RaceId = raceId,
                RiderId = riderId,
            };

            await _dbContext.RiderRaceEntries.AddAsync(riderRaceEntry, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
