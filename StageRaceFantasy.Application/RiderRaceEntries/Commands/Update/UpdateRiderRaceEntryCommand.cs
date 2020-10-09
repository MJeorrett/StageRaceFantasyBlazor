using MediatR;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.RiderRaceEntries.Commands.Update
{
    public record UpdateRiderRaceEntryCommand(int RaceId, int RiderId, int BibNumber, int StarValue)
        : IRequest<ApplicationRequestResult>
    {
    }

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

            var riderRaceEntry = await _dbContext.RiderRaceEntries
                .FindAsync(new object[] { raceId, riderId }, cancellationToken: cancellationToken);

            if (riderRaceEntry == null) return NotFound();

            riderRaceEntry.BibNumber = request.BibNumber;
            riderRaceEntry.StarValue = request.StarValue;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
