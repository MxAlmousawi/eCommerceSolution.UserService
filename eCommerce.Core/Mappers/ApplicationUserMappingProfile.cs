﻿using AutoMapper;
using eCommerce.Core.Dto;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {
            CreateMap<ApplicationUser, AuthenticationResponse>();
            CreateMap<RegisterRequest, ApplicationUser>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));
        }
    }
}
