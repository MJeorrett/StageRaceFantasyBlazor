using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Riders.Queries.GetAll
{
    public record GetAllRidersQuery : IApplicationQuery<GetAllRidersVm>
    {
    }

    public class GetAllRidersQueryHandler : ApplicationRequestHandler<GetAllRidersQuery, GetAllRidersVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllRidersQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async override Task<ApplicationRequestResult<GetAllRidersVm>> Handle(GetAllRidersQuery request, CancellationToken cancellationToken)
        {
            var riders = await _dbContext.Riders
                .OrderBy(r => r.LastName)
                .ProjectTo<RiderDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Success(new GetAllRidersVm(riders));
        }
    }
}