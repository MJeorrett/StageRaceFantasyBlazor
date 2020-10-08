using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Mediatr;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeams.Queries.GetAll
{
    public class GetAllFantasyTeamsQuery : IApplicationQuery<GetAllFantasyTeamsVm>
    {
    }

    public class GetAllFantasyTeamsHandler : IApplicationQueryHandler<GetAllFantasyTeamsQuery, GetAllFantasyTeamsVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllFantasyTeamsHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QueryResult<GetAllFantasyTeamsVm>> Handle(GetAllFantasyTeamsQuery request, CancellationToken cancellationToken)
        {
            var fantasyTeams = new GetAllFantasyTeamsVm()
            {
                FantasyTeams = await _dbContext.FantasyTeams
                    .ProjectTo<FantasyTeamDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(),
            };

            return new(fantasyTeams);
        }
    }
}
