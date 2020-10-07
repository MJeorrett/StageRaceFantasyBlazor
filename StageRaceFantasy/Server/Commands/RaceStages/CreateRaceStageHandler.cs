using AutoMapper;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Shared.Models;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.Commands.RaceStages
{
    public class CreateRaceStageHandler : IApplicationCommandHandler<CreateRaceStageCommand, GetRaceStageDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateRaceStageHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CommandResult<GetRaceStageDto>> Handle(CreateRaceStageCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;

            var race = await _dbContext.Races.FindAsync(raceId);

            if (race == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            var raceStage = new RaceStage()
            {
                Race = race,
                StartLocation = request.StartLocation,
                FinishLocation = request.FinishLocation,
            };

            await _dbContext.RaceStages.AddAsync(raceStage);
            await _dbContext.SaveChangesAsync();

            return new(_mapper.Map<GetRaceStageDto>(raceStage));
        }
    }
}
