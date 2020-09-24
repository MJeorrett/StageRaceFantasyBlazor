using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Server.Db;
using StageRaceFantasy.Server.Queries;
using StageRaceFantasy.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Server.QueryHandlers.RiderRaceEntry
{
    public class GetAllRiderRaceEntriesHandler : IRequestHandler<GetAllRiderRaceEntriesQuery, QueryResult<List<GetRiderRaceEntryDto>>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllRiderRaceEntriesHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QueryResult<List<GetRiderRaceEntryDto>>> Handle(GetAllRiderRaceEntriesQuery request, CancellationToken cancellationToken)
        {
            var raceId = request.raceId;

            var raceExists = await _dbContext.Races.AnyAsync(x => x.Id == raceId);

            if (!raceExists)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            var riderRaceEntries = await _dbContext.RiderRaceEntries
                .AsNoTracking()
                .Include(x => x.Race)
                .Include(x => x.Rider)
                .Where(x => x.RaceId == raceId)
                .OrderBy(x => x.Rider.LastName)
                .ToListAsync();

            var enteredRiderIds = riderRaceEntries.Select(x => x.RiderId);

            var notEnteredRiders = await _dbContext.Riders
                .Where(x => !enteredRiderIds.Contains(x.Id))
                .OrderBy(x => x.LastName)
                .ToListAsync();

            var enteredRiderRaceEntries = _mapper.Map<List<GetRiderRaceEntryDto>>(riderRaceEntries);
            enteredRiderRaceEntries.ForEach(x => x.IsEntered = true);

            var notEnteredRiderRaceEntries = _mapper.Map<List<GetRiderRaceEntryDto>>(notEnteredRiders);
            notEnteredRiderRaceEntries.ForEach(x => x.RaceId = raceId);

            return new(enteredRiderRaceEntries
                .Concat(notEnteredRiderRaceEntries)
                .ToList());
        }
    }
}
