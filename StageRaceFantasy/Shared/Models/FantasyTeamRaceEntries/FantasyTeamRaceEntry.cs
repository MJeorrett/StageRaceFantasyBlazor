using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StageRaceFantasy.Shared.Models
{
    public class FantasyTeamRaceEntry
    {
        public int Id { get; set; }
        public int FantasyTeamId { get; set; }
        public FantasyTeam FantasyTeam { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public List<FantasyTeamRaceEntryRider> FantasyTeamRaceEntryRiders { get; set; }

        [NotMapped]
        public List<int> RiderIds => FantasyTeamRaceEntryRiders.Select(x => x.RiderId).ToList();
    }
}
