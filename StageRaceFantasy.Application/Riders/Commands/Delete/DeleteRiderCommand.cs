using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Riders.Commands.Delete
{
    public record DeleteRiderCommand(int RiderId) : IApplicationRequest
    {
    }

    public class DeleteRiderCommandHandler : ApplicationRequestHandler<DeleteRiderCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteRiderCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async override Task<ApplicationRequestResult> Handle(DeleteRiderCommand request, CancellationToken cancellationToken)
        {
            var riderId = request.RiderId;

            var rider = await _dbContext.Riders.FindAsync(new object[] { riderId }, cancellationToken: cancellationToken);

            if (rider == null) return NotFound();

            _dbContext.Riders.Remove(rider);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success();
        }
    }
}
