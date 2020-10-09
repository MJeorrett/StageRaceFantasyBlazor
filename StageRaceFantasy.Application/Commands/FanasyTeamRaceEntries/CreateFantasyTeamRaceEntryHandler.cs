using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries
{
    public class CreateFantasyTeamRaceEntryHandler : ApplicationRequestHandler<CreateFantasyTeamRaceEntryCommand, GetFantasyTeamRaceEntryDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateFantasyTeamRaceEntryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetFantasyTeamRaceEntryDto>> Handle(CreateFantasyTeamRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var teamId = request.FantasyTeamId;

            if (FantasyTeamRaceEntryExists(raceId, teamId)) return BadRequest();

            var raceExists = await _dbContext.Races.AnyAsync(x => x.Id == raceId);
            var teamExists = await _dbContext.FantasyTeams.AnyAsync(x => x.Id == teamId);

            if (!raceExists || !teamExists) return NotFound();

            var entry = new FantasyTeamRaceEntry()
            {
                RaceId = raceId,
                FantasyTeamId = teamId,
            };

            await _dbContext.FantasyTeamRaceEntries.AddAsync(entry);
            await _dbContext.SaveChangesAsync();

            return Success(_mapper.Map<GetFantasyTeamRaceEntryDto>(entry));
        }

        public bool FantasyTeamRaceEntryExists(int raceId, int teamId)
        {
            return _dbContext.FantasyTeamRaceEntries
                .Any(x => x.RaceId == raceId && x.FantasyTeamId == teamId);
        }
    }
}
