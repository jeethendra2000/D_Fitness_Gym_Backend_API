﻿using AutoMapper;
using D_Fitness_Gym.Models.DTO.MembershipDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class MembershipProfile : Profile
    {
        public MembershipProfile() 
        {
            CreateMap<CreateMembershipDto, Membership>().ReverseMap();
            CreateMap<UpdateMembershipDto, Membership>().ReverseMap();
            CreateMap<Membership, RetrieveMembershipDto>().ReverseMap();
        }
    }
}
