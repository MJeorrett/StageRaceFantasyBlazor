﻿using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.Common.Mediatr;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.Commands
{
    public class DeleteRiderRaceEntryHandler : IApplicationCommandHandler<DeleteRiderRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteRiderRaceEntryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommandResult> Handle(DeleteRiderRaceEntryCommand request, CancellationToken cancellationToken)
        {
            var raceId = request.RaceId;
            var riderId = request.RiderId;

            var riderRaceEntry = await _dbContext.RiderRaceEntries.FindAsync(raceId, riderId);

            if (riderRaceEntry == null)
            {
                return new()
                {
                    IsNotFound = true,
                };
            }

            _dbContext.RiderRaceEntries.Remove(riderRaceEntry);
            await _dbContext.SaveChangesAsync();

            return new();
        }
    }
}
