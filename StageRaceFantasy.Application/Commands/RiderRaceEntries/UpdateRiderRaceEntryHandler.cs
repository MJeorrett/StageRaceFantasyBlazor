using StageRaceFantasy.Application.Common;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Commands
{
    public class UpdateRiderRaceEntryHandler : IApplicationCommandHandler<UpdateRiderRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateRiderRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommandResult> Handle(UpdateRiderRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var riderId = request.RiderId;

            var riderRaceEntry = await _dbContext.RiderRaceEntries.FindAsync(raceId, riderId);

            if (riderRaceEntry == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            riderRaceEntry.BibNumber = request.dto.BibNumber;
            riderRaceEntry.StarValue = request.dto.StarValue;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new();
        }
    }
}
