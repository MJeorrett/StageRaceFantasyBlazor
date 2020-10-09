using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;

namespace StageRaceFantasy.Application.RiderRaceEntries.Commands.Create
{
    public class CreateRiderRaceEntryDto : IMapFrom<RiderRaceEntry>
    {
        public int RaceId { get; set; }
        public int RiderId { get; set; }
    }
}
