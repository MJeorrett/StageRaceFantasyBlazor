using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeams.Queries.GetAll
{
    public class GetAllFantasyTeamsQuery : IApplicationQuery<GetAllFantasyTeamsVm>
    {
    }

    public class GetAllFantasyTeamsHandler : ApplicationRequestHandler<GetAllFantasyTeamsQuery, GetAllFantasyTeamsVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllFantasyTeamsHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetAllFantasyTeamsVm>> Handle(GetAllFantasyTeamsQuery request, CancellationToken cancellationToken)
        {
            var fantasyTeamDtos = await _dbContext.FantasyTeams
                .ProjectTo<FantasyTeamDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Success(new GetAllFantasyTeamsVm()
            {
                FantasyTeams = fantasyTeamDtos,
            });
        }
    }
}
