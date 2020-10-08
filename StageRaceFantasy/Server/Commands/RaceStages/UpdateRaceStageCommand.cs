namespace StageRaceFantasy.Server.Commands.RaceStages
{
    public record UpdateRaceStageCommand : IApplicationCommand
    {
        public int RaceId { get; init; }
        public int StageId { get; init; }
        public string StartLocation { get; init; }
        public string FinishLocation { get; init; }
    }
}
