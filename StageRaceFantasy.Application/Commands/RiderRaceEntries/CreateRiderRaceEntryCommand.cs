using StageRaceFantasy.Application.Common.Requests;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.Commands
{
    public record CreateRiderRaceEntryCommand(int RaceId, int RiderId) :
        IApplicationCommand<GetRiderRaceEntryDto>
    {
    }
}
