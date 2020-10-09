using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Commands
{
    public class UpdateRiderRaceEntryHandler : ApplicationCommandHandler<UpdateRiderRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateRiderRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(UpdateRiderRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var riderId = request.RiderId;

            var riderRaceEntry = await _dbContext.RiderRaceEntries.FindAsync(raceId, riderId);

            if (riderRaceEntry == null) return NotFound();

            riderRaceEntry.BibNumber = request.dto.BibNumber;
            riderRaceEntry.StarValue = request.dto.StarValue;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
