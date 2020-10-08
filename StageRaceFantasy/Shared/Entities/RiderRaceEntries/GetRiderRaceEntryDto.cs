namespace StageRaceFantasy.Domain.Entities
{
    public class GetRiderRaceEntryDto
    {
        public int RaceId { get; set; }
        public int RiderId { get; set; }
        public string RiderFirstName { get; set; }
        public string RiderLastName { get; set; }
        public bool IsEntered { get; set; }
        public int BibNumber { get; set; }
        public int StarValue { get; set; }
    }
}
