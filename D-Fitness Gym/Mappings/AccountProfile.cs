using AutoMapper;
using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            // Create DTO → Entity
            CreateMap<CreateAccountDto, Account>().ReverseMap();

            // Update DTO → Entity
            // Null values do NOT overwrite existing database fields
            CreateMap<UpdateAccountDto, Account>().ForAllMembers(opt => opt.Condition((src, dest, srcValue) => srcValue != null));

            // Entity → Retrieve DTO
            CreateMap<Account, RetrieveAccountDto>().ReverseMap();
        }

    }
}
