using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.RiderRaceEntries.Commands.Create
{
    public class CreateRiderRaceEntryCommand :
        CreateRiderRaceEntryDto,
        IApplicationCommand<CreateRiderRaceEntryDto>
    {
    }

    public class CreateRiderRaceEntryHandler : ApplicationRequestHandler<CreateRiderRaceEntryCommand, CreateRiderRaceEntryDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateRiderRaceEntryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<CreateRiderRaceEntryDto>> Handle(
            CreateRiderRaceEntryCommand request,
            CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var riderId = request.RiderId;

            var raceEntryExists = await _dbContext.RiderRaceEntries
                .AnyAsync(x => x.RaceId == raceId && x.RiderId == riderId, cancellationToken);

            if (raceEntryExists) return BadRequest();

            var raceExists = await _dbContext.Races.AnyAsync(x => x.Id == raceId, cancellationToken);
            var riderExists = await _dbContext.Riders.AnyAsync(x => x.Id == riderId, cancellationToken);

            if (!raceExists || !riderExists) return NotFound();

            var riderRaceEntry = new RiderRaceEntry()
            {
                RaceId = raceId,
                RiderId = riderId,
            };

            await _dbContext.RiderRaceEntries.AddAsync(riderRaceEntry, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var getRiderRaceEntryDto = _mapper.Map<CreateRiderRaceEntryDto>(riderRaceEntry);

            return Success(getRiderRaceEntryDto);
        }
    }
}
