namespace StageRaceFantasy.Domain.Entities
{
    public class RaceStage
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public string StartLocation { get; set; }
        public string FinishLocation { get; set; }
    }
}
