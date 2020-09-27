namespace StageRaceFantasy.Shared.Models
{
    public class RiderRaceEntry
    {
        public int RiderId { get; set; }
        public Rider Rider { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int BibNumber { get; set; }
        public int StarValue { get; set; }
    }
}
