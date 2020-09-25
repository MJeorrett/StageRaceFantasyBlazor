using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Shared.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Commands.FanasyTeamRaceEntries
{
    public class CreateFantasyTeamRaceEntryHandler : IApplicationCommandHandler<CreateFantasyTeamRaceEntryCommand, GetFantasyTeamRaceEntryDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateFantasyTeamRaceEntryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CommandResult<GetFantasyTeamRaceEntryDto>> Handle(CreateFantasyTeamRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var teamId = request.FantasyTeamId;

            if (FantasyTeamRaceEntryExists(raceId, teamId))
            {
                return new()
                {
                    IsBadRequest = true,
                };
            }

            var raceExists = await _dbContext.Races.AnyAsync(x => x.Id == raceId);
            var teamExists = await _dbContext.FantasyTeams.AnyAsync(x => x.Id == teamId);

            if (!raceExists || !teamExists)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            var entry = new FantasyTeamRaceEntry()
            {
                RaceId = raceId,
                FantasyTeamId = teamId,
            };

            await _dbContext.FantasyTeamRaceEntries.AddAsync(entry);
            await _dbContext.SaveChangesAsync();

            return new(_mapper.Map<GetFantasyTeamRaceEntryDto>(entry));
        }

        public bool FantasyTeamRaceEntryExists(int raceId, int teamId)
        {
            return _dbContext.FantasyTeamRaceEntries
                .Any(x => x.RaceId == raceId && x.FantasyTeamId == teamId);
        }
    }
}
