using MediatR;
using StageRaceFantasy.Application.Common.Mediatr;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.Commands
{
    public record UpdateRiderRaceEntryCommand(int RaceId, int RiderId, UpdateRiderRaceEntryDto dto)
        : IRequest<CommandResult>
    {
    }
}
