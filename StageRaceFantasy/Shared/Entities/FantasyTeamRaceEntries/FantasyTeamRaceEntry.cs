using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StageRaceFantasy.Domain.Entities
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
        public List<Rider> Riders => FantasyTeamRaceEntryRiders.Select(x => x.Rider).ToList();

        public FantasyTeamRaceEntry()
        {
            FantasyTeamRaceEntryRiders = new List<FantasyTeamRaceEntryRider>();
        }
    }
}
