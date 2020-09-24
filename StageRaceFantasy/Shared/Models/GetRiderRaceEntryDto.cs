namespace StageRaceFantasy.Shared.Models
{
    public class GetRiderRaceEntryDto
    {
        public int RaceId { get; set; }
        public int RiderId { get; set; }
        public string RiderFirstName { get; set; }
        public string RiderLastName { get; set; }
        public bool IsEntered { get; set; }
        public int BibNumber { get; set; } = -1;
    }
}
