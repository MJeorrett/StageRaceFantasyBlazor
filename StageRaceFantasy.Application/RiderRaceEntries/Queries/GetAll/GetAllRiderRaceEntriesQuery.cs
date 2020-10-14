using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.RiderRaceEntries.Queries.GetAll
{
    public record GetAllRiderRaceEntriesQuery(int RaceId) : IApplicationRequest<GetAllRiderRaceEntriesVm>
    {
    }

    public class GetAllRiderRaceEntriesHandler : ApplicationRequestHandler<GetAllRiderRaceEntriesQuery, GetAllRiderRaceEntriesVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllRiderRaceEntriesHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override async Task<ApplicationRequestResult<GetAllRiderRaceEntriesVm>> Handle(
            GetAllRiderRaceEntriesQuery request,
            CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;

            var raceExists = await _dbContext.Races.AnyAsync(x => x.Id == raceId, cancellationToken);

            if (!raceExists) return NotFound();

            var riderRaceEntries = await _dbContext.RiderRaceEntries
                .AsNoTracking()
                .Include(x => x.Race)
                .Include(x => x.Rider)
                .Where(x => x.RaceId == raceId)
                .OrderBy(x => x.Rider.LastName)
                .ProjectTo<RiderRaceEntryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var enteredRiderIds = riderRaceEntries.Select(x => x.RiderId);

            var notEnteredRiders = await _dbContext.Riders
                .Where(x => !enteredRiderIds.Contains(x.Id))
                .OrderBy(x => x.LastName)
                .Select(x => new RiderRaceEntryDto()
                {
                    RiderId = x.Id,
                    RiderFirstName = x.FirstName,
                    RiderLastName = x.LastName,
                })
                .ToListAsync(cancellationToken);


            riderRaceEntries.ForEach(x => x.IsEntered = true);
            notEnteredRiders.ForEach(x => x.RaceId = raceId);

            return Success(new GetAllRiderRaceEntriesVm()
            {
                Entries = riderRaceEntries
                    .Concat(notEnteredRiders)
                    .ToList(),
            });
        }
    }
}
