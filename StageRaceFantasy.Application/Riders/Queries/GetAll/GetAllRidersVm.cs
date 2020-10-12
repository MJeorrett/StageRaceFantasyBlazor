using StageRaceFantasy.Application.Common.AutoMapper;
using StageRaceFantasy.Domain.Entities;
using System.Collections.Generic;

namespace StageRaceFantasy.Application.Riders.Queries.GetAll
{
    public record GetAllRidersVm
    {
        public List<RiderDto> Riders { get; set; }

        public GetAllRidersVm(List<RiderDto> riders)
        {
            Riders = riders;
        }
    }

    public record RiderDto : IMapFrom<Rider>
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}
