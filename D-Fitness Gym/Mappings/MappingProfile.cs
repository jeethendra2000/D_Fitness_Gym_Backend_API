using AutoMapper;
using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<CreateAccountDto, Account>();
            CreateMap<UpdateAccountDto, Account>();
            CreateMap<Account, RetrieveAccountDto>();
        }
    }
}
