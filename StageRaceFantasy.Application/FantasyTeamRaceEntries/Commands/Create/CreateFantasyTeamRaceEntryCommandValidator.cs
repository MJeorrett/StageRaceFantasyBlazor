using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StageRaceFantasy.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace StageRaceFantasy.Application.FantasyTeamRaceEntries.Commands.Create
{
    public class CreateFantasyTeamRaceEntryCommandValidator : AbstractValidator<CreateFantasyTeamRaceEntryCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateFantasyTeamRaceEntryCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x)
                .MustAsync(MustNotAlreadyExist)
                    .WithMessage(x => $"Entry for race '{x.RaceId}' by fantasy team '{x.FantasyTeamId}' already exists.");
        }

        private async Task<bool> MustNotAlreadyExist(CreateFantasyTeamRaceEntryCommand command, CancellationToken cancellationToken)
        {
            var raceEntryExists = await _dbContext.FantasyTeamRaceEntries
                    .AnyAsync(
                        x => x.RaceId == command.RaceId && x.FantasyTeamId == command.FantasyTeamId,
                        cancellationToken);

            return !raceEntryExists;
        }
    }
}
