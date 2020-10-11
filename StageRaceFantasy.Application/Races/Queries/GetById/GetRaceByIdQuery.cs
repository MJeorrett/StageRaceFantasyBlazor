using AutoMapper;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Races.Queries.GetById
{
    public record GetRaceByIdQuery(int Id) : IApplicationQuery<GetRaceByIdVm>
    {
    }

    public class GetRaceByIdQueryHandler : ApplicationRequestHandler<GetRaceByIdQuery, GetRaceByIdVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRaceByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetRaceByIdVm>> Handle(GetRaceByIdQuery request, CancellationToken cancellationToken)
        {
            var raceId = request.Id;

            var race = await _dbContext.Races.FindAsync(new object[] { raceId }, cancellationToken);

            if (race == null) return NotFound();

            return Success(_mapper.Map<GetRaceByIdVm>(race));
        }
    }
}
