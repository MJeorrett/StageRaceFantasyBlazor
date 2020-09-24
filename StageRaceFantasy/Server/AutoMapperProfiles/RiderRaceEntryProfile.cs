﻿using AutoMapper;
using StageRaceFantasy.Shared.Models;

namespace StageRaceFantasy.Server.AutoMapperProfiles
{
    public class RiderRaceEntryProfile : Profile
    {
        public RiderRaceEntryProfile()
        {
            CreateMap<RiderRaceEntry, GetRiderRaceEntryDto>();
            CreateMap<Rider, GetRiderRaceEntryDto>()
                .ForMember(dest => dest.RiderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RiderFirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.RiderLastName, opt => opt.MapFrom(src => src.LastName));
        }
    }
}
