using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.RiderRaceEntries.Commands.Delete
{
    public record DeleteRiderRaceEntryCommand(int RaceId, int RiderId) :
        IApplicationCommand
    {
    }

    public class DeleteRiderRaceEntryHandler : ApplicationRequestHandler<DeleteRiderRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteRiderRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<ApplicationRequestResult> Handle(DeleteRiderRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var riderId = request.RiderId;

            var riderRaceEntry = await _dbContext.RiderRaceEntries
                .FindAsync(new object[] { raceId, riderId }, cancellationToken: cancellationToken);

            if (riderRaceEntry == null) return NotFound();

            _dbContext.RiderRaceEntries.Remove(riderRaceEntry);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
