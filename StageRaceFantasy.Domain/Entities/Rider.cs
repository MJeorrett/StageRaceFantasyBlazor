using StageRaceFantasy.Domain.Common;
using System.Collections.Generic;

namespace StageRaceFantasy.Domain.Entities
{
    public class Rider : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<FantasyTeamRaceEntryRider> FantasyTeamRaceEntryRiders { get; set; }
    }
}
