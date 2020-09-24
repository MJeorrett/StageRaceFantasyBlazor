using AutoMapper;
using MediatR;
using StageRaceFantasy.Server.Commands;
using StageRaceFantasy.Server.Commands.RiderRaceEntry;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Shared.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.CommandHandlers
{
    public class CreateRiderRaceEntryHandler : IRequestHandler<CreateRiderRaceEntryCommand, CommandResult<GetRiderRaceEntryDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateRiderRaceEntryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CommandResult<GetRiderRaceEntryDto>> Handle(CreateRiderRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var riderId = request.RiderId;
            var bibNumber = request.BibNumber;

            if (RiderRaceEntryExists(raceId, riderId))
            {
                return new()
                {
                    IsBadRequest = true,
                };
            }

            var race = await _dbContext.Races.FindAsync(raceId);
            var rider = await _dbContext.Riders.FindAsync(riderId);

            if (race == null || rider == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            var riderRaceEntry = new RiderRaceEntry()
            {
                Race = race,
                Rider = rider,
                BibNumber = bibNumber,
            };

            await _dbContext.RiderRaceEntries.AddAsync(riderRaceEntry);
            await _dbContext.SaveChangesAsync();

            var getRiderRaceEntryDto = _mapper.Map<GetRiderRaceEntryDto>(riderRaceEntry);
            getRiderRaceEntryDto.IsEntered = true;

            return new (getRiderRaceEntryDto);
        }

        private bool RiderRaceEntryExists(int raceId, int riderId)
        {
            return _dbContext.RiderRaceEntries
                .Any(x => x.RaceId == raceId && x.RiderId == riderId);
        }
    }
}
