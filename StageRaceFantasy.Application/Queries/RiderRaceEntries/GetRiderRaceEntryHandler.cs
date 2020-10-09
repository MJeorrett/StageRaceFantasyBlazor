﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Queries
{
    public class GetRiderRaceEntryHandler : IApplicationQueryHandler<GetRiderRaceEntryQuery, GetRiderRaceEntryDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRiderRaceEntryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QueryResult<GetRiderRaceEntryDto>> Handle(GetRiderRaceEntryQuery request, CancellationToken cancellationToken)
        {
            var raceId = request.raceId;
            var riderId = request.riderId;

            var riderRaceEntry = await _dbContext.RiderRaceEntries
                .Include(x => x.Race)
                .Include(x => x.Rider)
                .Where(x => x.RaceId == raceId && x.RiderId == riderId)
                .FirstOrDefaultAsync();

            if (riderRaceEntry != null)
            {
                var riderRaceEntryDto = _mapper.Map<GetRiderRaceEntryDto>(riderRaceEntry);
                riderRaceEntryDto.IsEntered = true;

                return new(riderRaceEntryDto);
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

            // TODO: This should be handled int automapper.
            return new(new GetRiderRaceEntryDto
            {
                RaceId = raceId,
                RiderId = rider.Id,
                RiderFirstName = rider.FirstName,
                RiderLastName = rider.LastName,
            });
        }
    }
}
