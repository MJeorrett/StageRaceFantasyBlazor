using MediatR;
using StageRaceFantasy.Server.Commands;
using StageRaceFantasy.Server.Commands.RiderRaceEntry;
using StageRaceFantasy.Server.Db;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.CommandHandlers
{
    public class DeleteRiderRaceEntryHandler : IRequestHandler<DeleteRiderRaceEntryCommand, CommandResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteRiderRaceEntryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommandResult> Handle(DeleteRiderRaceEntryCommand request, CancellationToken cancellationToken)
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

            _dbContext.RiderRaceEntries.Remove(riderRaceEntry);
            await _dbContext.SaveChangesAsync();

            return new();
        }
    }
}
