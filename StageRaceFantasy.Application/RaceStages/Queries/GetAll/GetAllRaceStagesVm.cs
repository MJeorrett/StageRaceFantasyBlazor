using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.RaceStages.Queries.GetAll
{
    public class GetAllRaceStagesVm
    {
        public List<RaceStageDto> RaceStages { get; set; }
    }

    public class RaceStageDto : IMapFrom<RaceStage>
    {
        public int Id { get; set; }
        public string StartLocation { get; set; }
        public string FinishLocation { get; set; }
    }
}
