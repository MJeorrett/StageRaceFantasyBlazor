namespace StageRaceFantasy.Shared.Models
{
    public class FantasyTeamRaceEntryRider
    {
        public int FantasyTeamRaceEntryId { get; set; }
        public FantasyTeamRaceEntry FantasyTeamRaceEntry { get; set; }
        public int RiderId { get; set; }
        public Rider Rider { get; set; }
    }
}
