namespace StageRaceFantasy.Shared.Models
{
    public class GetRiderRaceEntryDto
    {
        public Rider Rider { get; set; }
        public GetRiderRaceEntryRaceDto Race { get; set; }
        public bool IsEntered { get; set; }
        public int BibNumber { get; set; }
    }

    public class GetRiderRaceEntryRaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
