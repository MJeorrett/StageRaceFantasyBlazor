namespace StageRaceFantasy.Shared.Models
{
    public class AddRiderRaceEntryDto
    {
        public int RiderId { get; set; }
        public int RaceId { get; set; }
        public int BibNumber { get; set; } = -1;
    }
}
