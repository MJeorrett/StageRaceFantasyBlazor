using System.Collections.Generic;

namespace StageRaceFantasy.Shared.Models
{
    public class GetRaceStagesDto
    {
        public class Stage
        {
            public int Id { get; set; }
            public string StartLocation { get; set; }
            public string FinishLocation { get; set; }
        }

        public string RaceName { get; set; }
        public List<Stage> Stages { get; set; }

        public GetRaceStagesDto()
        {
            Stages = new List<Stage>();
        }
    }
}
