using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeamRaceEntries.Queries.GetById
{
    public record GetFantasyTeamRaceEntryByIdQuery(int FantasyTeamId, int RaceId)
        : IApplicationQuery<GetFantasyTeamRaceEntryByIdVm>
    {
    }

    public class GetFantasyTeamRaceEntryByIdHandler : ApplicationRequestHandler<GetFantasyTeamRaceEntryByIdQuery, GetFantasyTeamRaceEntryByIdVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFantasyTeamRaceEntryByIdHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetFantasyTeamRaceEntryByIdVm>> Handle(GetFantasyTeamRaceEntryByIdQuery request,
                                                                                                   CancellationToken cancellationToken)
        {
            var teamId = request.FantasyTeamId;
            var raceId = request.RaceId;

            var entry = await _dbContext.FantasyTeamRaceEntries
                .Include(x => x.FantasyTeamRaceEntryRiders)
                    .ThenInclude(x => x.Rider)
                .Include(x => x.Race)
                .FirstOrDefaultAsync(
                    x => x.FantasyTeamId == teamId && x.RaceId == raceId,
                    cancellationToken);

            if (entry == null) return NotFound();

            var result = _mapper.Map<GetFantasyTeamRaceEntryByIdVm>(entry);

            var race = await _dbContext.Races.FindAsync(raceId);
            result.FantasyTeamSize = race.FantasyTeamSize;

            return new(result);
        }
    }
}
