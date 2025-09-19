using AutoMapper;
using D_Fitness_Gym.Models.DTO.AccountDto;
using D_Fitness_Gym.Models.Entities;

namespace D_Fitness_Gym.Mappings
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            // DTO → Entity
            CreateMap<CreateAccountDto, Account>().ReverseMap();
            CreateMap<UpdateAccountDto, Account>().ReverseMap();

            // Entity → DTO
            CreateMap<Account, RetrieveAccountDto>().ReverseMap();
        }
    }
}
