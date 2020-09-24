using AutoMapper;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.AutoMapperProfiles
{
    public class RiderRaceEntryProfile : Profile
    {
        public RiderRaceEntryProfile()
        {
            CreateMap<Race, GetRiderRaceEntryRaceDto>();
            CreateMap<RiderRaceEntry, GetRiderRaceEntryDto>();
        }
    }
}
