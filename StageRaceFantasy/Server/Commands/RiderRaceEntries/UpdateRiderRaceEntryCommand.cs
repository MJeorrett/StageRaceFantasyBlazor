using MediatR;

namespace StageRaceFantasy.Server.Commands
{
    public record UpdateRiderRaceEntryCommand(int RaceId, int RiderId, int BibNumber)
        : IRequest<CommandResult>
    {
    }
}
