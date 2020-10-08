namespace StageRaceFantasy.Domain.Entities
{
    public record UpdateRiderRaceEntryDto
    {
        public int BibNumber { get; set; }
        public int StarValue { get; set; }
    }
}
