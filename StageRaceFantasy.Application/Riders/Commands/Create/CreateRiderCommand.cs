using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Riders.Commands.Create
{
    public record CreateRiderCommand : IApplicationRequest<int>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }

    public class CreateRiderCommandHandler : ApplicationRequestHandler<CreateRiderCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateRiderCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async override Task<ApplicationRequestResult<int>> Handle(CreateRiderCommand request, CancellationToken cancellationToken)
        {
            var rider = new Rider()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            _dbContext.Riders.Add(rider);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Success(rider.Id);
        }
    }
}
