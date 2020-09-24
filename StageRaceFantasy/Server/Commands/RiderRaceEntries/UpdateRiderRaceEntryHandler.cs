using MediatR;
using StageRaceFantasy.Server.Db;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Commands.RiderRaceEntries
{
    public class UpdateRiderRaceEntryHandler : IRequestHandler<UpdateRiderRaceEntryCommand, CommandResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateRiderRaceEntryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommandResult> Handle(UpdateRiderRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var riderId = request.RiderId;
            var updateRiderRaceEntryDto = request.UpdateRiderRaceEntryDto;

            var riderRaceEntry = await _dbContext.RiderRaceEntries.FindAsync(raceId, riderId);

            if (riderRaceEntry == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            riderRaceEntry.BibNumber = updateRiderRaceEntryDto.BibNumber;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new();
        }
    }
}
