using System.Collections.Generic;

namespace StageRaceFantasy.Shared.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FantasyTeamSize { get; set; }
        public List<RiderRaceEntry> RiderEntries { get; set; }
    }
}
