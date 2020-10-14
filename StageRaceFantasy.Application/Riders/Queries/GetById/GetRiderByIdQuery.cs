using AutoMapper;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Riders.Queries.GetById
{
    public record GetRiderByIdQuery(int RiderId) : IApplicationRequest<GetRiderByIdVm>
    {
    }

    public class GetRiderByIdQueryHandler : ApplicationRequestHandler<GetRiderByIdQuery, GetRiderByIdVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRiderByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async override Task<ApplicationRequestResult<GetRiderByIdVm>> Handle(GetRiderByIdQuery request, CancellationToken cancellationToken)
        {
            var riderId = request.RiderId;

            var rider = await _dbContext.Riders.FindAsync(new object[] { riderId }, cancellationToken: cancellationToken);

            if (rider == null) return NotFound();

            return Success(_mapper.Map<GetRiderByIdVm>(rider));
        }
    }
}
