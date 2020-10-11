using StageRaceFantasy.Domain.Common;
using System.Collections.Generic;

namespace StageRaceFantasy.Domain.Entities
{
    public class Race : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FantasyTeamSize { get; set; }
        public List<RiderRaceEntry> RiderEntries { get; set; }
        public List<RaceStage> Stages { get; set; }

        public Race()
        {
            RiderEntries = new List<RiderRaceEntry>();
            Stages = new List<RaceStage>();
        }
    }
}
