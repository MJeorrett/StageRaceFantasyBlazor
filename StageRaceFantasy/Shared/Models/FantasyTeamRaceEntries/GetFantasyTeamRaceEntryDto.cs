using System.Collections.Generic;

namespace StageRaceFantasy.Shared.Models
{
    public class GetFantasyTeamRaceEntryDto
    {
        public int FantasyTeamId { get; set; }
        public int RaceId { get; set; }
        public List<int> RiderIds { get; set; }
    }
}
