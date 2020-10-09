using AutoMapper;
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

    public class GetAllFantasyTeamsHandler : IApplicationQueryHandler<GetAllFantasyTeamsQuery, GetAllFantasyTeamsVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllFantasyTeamsHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationRequestResult<GetAllFantasyTeamsVm>> Handle(GetAllFantasyTeamsQuery request, CancellationToken cancellationToken)
        {
            var fantasyTeams = await _dbContext.FantasyTeams.ToListAsync();

            return new(_mapper.Map<GetAllFantasyTeamsVm>(fantasyTeams));
        }
    }
}
