using System.Collections.Generic;

namespace StageRaceFantasy.Shared.Models
{
    public class FantasyTeamRaceEntry
    {
        public int Id { get; set; }
        public int FantasyTeamId { get; set; }
        public FantasyTeam FantasyTeam { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public List<Rider> Riders { get; set; }
    }
}
