using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeamRaceEntries.Queries.GetAll
{
    public record GetAllFantasyTeamRaceEntriesQuery(int TeamId)
        : IApplicationQuery<GetAllFantasyTeamRaceEntriesVm>
    {
    }
    public class GetAllFantasyTeamRaceEntriesHandler : ApplicationRequestHandler<GetAllFantasyTeamRaceEntriesQuery, GetAllFantasyTeamRaceEntriesVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllFantasyTeamRaceEntriesHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetAllFantasyTeamRaceEntriesVm>> Handle(
            GetAllFantasyTeamRaceEntriesQuery request,
            CancellationToken cancellationToken)
        {
            var teamId = request.TeamId;

            var teamExists = await _dbContext.FantasyTeams.AnyAsync(x => x.Id == teamId);

            if (!teamExists) return NotFound();

            var entries = await _dbContext.FantasyTeamRaceEntries
                .Where(x => x.FantasyTeamId == teamId)
                .OrderBy(x => x.Race.Name)
                .ProjectTo<FantasyTeamRaceEntryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Success(new GetAllFantasyTeamRaceEntriesVm()
            {
                Entries = entries,
            });
        }
    }
}
