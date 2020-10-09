using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Commands
{
    public class CreateRiderRaceEntryHandler : ApplicationCommandHandler<CreateRiderRaceEntryCommand, GetRiderRaceEntryDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateRiderRaceEntryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetRiderRaceEntryDto>> Handle(CreateRiderRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var riderId = request.RiderId;

            if (RiderRaceEntryExists(raceId, riderId)) return BadRequest();

            var raceExists = await _dbContext.Races.AnyAsync(x => x.Id == raceId);
            var riderExists = await _dbContext.Riders.AnyAsync(x => x.Id == riderId);

            if (!raceExists || !riderExists) return NotFound();

            var riderRaceEntry = new RiderRaceEntry()
            {
                RaceId = raceId,
                RiderId = riderId,
            };

            await _dbContext.RiderRaceEntries.AddAsync(riderRaceEntry);
            await _dbContext.SaveChangesAsync();

            var getRiderRaceEntryDto = _mapper.Map<GetRiderRaceEntryDto>(riderRaceEntry);
            getRiderRaceEntryDto.IsEntered = true;

            return Success(getRiderRaceEntryDto);
        }

        private bool RiderRaceEntryExists(int raceId, int riderId)
        {
            return _dbContext.RiderRaceEntries
                .Any(x => x.RaceId == raceId && x.RiderId == riderId);
        }
    }
}
