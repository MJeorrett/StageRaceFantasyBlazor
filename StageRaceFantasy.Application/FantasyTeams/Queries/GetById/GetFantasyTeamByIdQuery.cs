using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeams.Queries.GetById
{
    public record GetFantasyTeamByIdQuery(int TeamId) : IApplicationQuery<GetFantasyTeamByIdVm>
    {
    }

    public class GetFantasyTeamByIdHandler : ApplicationRequestHandler<GetFantasyTeamByIdQuery, GetFantasyTeamByIdVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFantasyTeamByIdHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetFantasyTeamByIdVm>> Handle(GetFantasyTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var teamId = request.TeamId;

            var fantasyTeam = await _dbContext.FantasyTeams
                .Include(x => x.RaceEntries)
                    .ThenInclude(x => x.Race)
                .FirstOrDefaultAsync(x => x.Id == teamId);

            if (fantasyTeam == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            return new(_mapper.Map<GetFantasyTeamByIdVm>(fantasyTeam));
        }
    }
}
