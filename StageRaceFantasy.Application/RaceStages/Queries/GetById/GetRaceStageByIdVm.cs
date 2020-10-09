using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.RaceStages.Queries.GetById
{
    public class GetRaceStageByIdVm : IMapFrom<RaceStage>
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public string StartLocation { get; set; }
        public string FinishLocation { get; set; }
    }
}
